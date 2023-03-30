using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Collaress
{
    public partial class VentanaGrafico : Form
    {

        private Series horasComida = new Series("Horas que comió");
        private Series vecesComida = new Series("Veces que comió");
        private Color colorGridGrafica = Color.LightGray;

        //private string rutaCarpetaVacas = @"C:\Users\ossie\Desktop\Vacas\";
        
        public VentanaGrafico()
        {
            InitializeComponent();
        }

        private void VentanaGrafico_Load(object sender, EventArgs e)
        {
            puerto.NewLine = "\r\n";
            ComunicacionSerial.SetPuerto(puerto);
            ComunicacionSerial.AbrirPuerto();

            try
            {
                LlenarListVacas();
                listVacas.SelectedIndex = 0;
                GraficaSetup();
                lblVacaId.Text = ObtenerIdSeleccionada();
            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
            }
        }

        private void VentanaGrafico_FormClosing(object sender, FormClosingEventArgs e)
        {
            ComunicacionSerial.CerrarPuerto();
        }

        private void LlenarListVacas()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(CsvUtileria.csvPath);
            FileInfo[] files = FiltrarArchivos(dirInfo);

            int[] arrayIDs = new int[0];

            foreach (FileInfo file in files)
            {
                string idVaca = file.Name.Split('.')[0].Substring(4); //Se queda con el id de la vaca del archivo
                arrayIDs = arrayIDs.Append
                    (Convert.ToInt32(idVaca))
                    .ToArray();
            }

            Array.Sort(arrayIDs);

            foreach (int id in arrayIDs)
            {
                string vacaId = "Vaca" + id;
                listVacas.Items.Add(vacaId);
            }
        }

        //Como para sobreescribir los archivos cuando llegan nuevos datos genera un nuevo archivo temporal
        //podria ocurrir el caso de que algun archivo temp no se borre y el programa lo cuente como un archivo normal
        //por eso es que se usa este metodo para filtrar los archivos
        private static FileInfo[] FiltrarArchivos(DirectoryInfo dirInfo)
        {
            FileInfo[] files = dirInfo.GetFiles("*.csv");
            files =
                files.Where
                    (file => !file.Name.Contains("temp"))
                    .ToArray();
            return files;
        }

        private void GraficaSetup()
        {
            //Hace que el grafico sea de linea
            vecesComida.ChartType = horasComida.ChartType = SeriesChartType.Line;
            
            //Añade las series horasComida y vecesComida al grafico
            graficoVacaInfo.Series.Add(horasComida);
            graficoVacaInfo.Series.Add(vecesComida);

            //Hace que el eje x vaya de uno en uno
            graficoVacaInfo.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            graficoVacaInfo.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            graficoVacaInfo.ChartAreas[0].BackColor = Color.FromArgb(155, 191, 169);
            ///chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;?

            //Muestra los valores de cada punto en el grafico
            graficoVacaInfo.Series[0].IsValueShownAsLabel = true;
            graficoVacaInfo.Series[1].IsValueShownAsLabel = true;

            //Cambia el color de las rayas (grid) de la grafica
            graficoVacaInfo.ChartAreas[0].AxisX.MajorGrid.LineColor = colorGridGrafica;
            graficoVacaInfo.ChartAreas[0].AxisY.MajorGrid.LineColor = colorGridGrafica;
            graficoVacaInfo.Legends[0].Alignment = StringAlignment.Center;
            ActualizarGrafico();
        }

        private void ActualizarGrafico()
        {
            string vacaSeleccionada = ObtenerIdSeleccionada().ToLower();
            ActualizadorGrafica.Actualizar(graficoVacaInfo, horasComida, vecesComida, vacaSeleccionada);
        }

        private void puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ComunicacionSerial.LeerDatos();
        }

        private void temporizador_Tick(object sender, EventArgs e)
        {
            ActualizarGrafico();
        }

        private void listVacas_SelectedValueChanged(object sender, EventArgs e)
        {
            lblVacaId.Text = ObtenerIdSeleccionada();
            ActualizarGrafico();
        }

        private string ObtenerIdSeleccionada()
        {
            return listVacas.SelectedItem.ToString();
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            char teclaPresionada = e.KeyChar;
            bool esNumero = Char.IsDigit(teclaPresionada);
            bool esTeclaBorrar = teclaPresionada == (char) Keys.Back;
            bool esEnter = teclaPresionada == (char) Keys.Enter;

            if (esEnter)
            {
                e.Handled = true;
                btnBusqueda_Click(sender, e);
            }
            else if (!esNumero && !esTeclaBorrar)
            {
                e.Handled = true;
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Text;
            bool txtBoxTieneTexto = !String.IsNullOrEmpty(busqueda);
            
            if (txtBoxTieneTexto)
            {
                busqueda = busqueda.Insert(0, "Vaca");
                listVacas.SelectedItem = busqueda;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CrearWord.Crear(lblVacaId.Text);
        }
    }
}

//Series horasComida = new Series("Horas que comió");
//Series vecesComida = new Series("Veces que comió");
//vecesComida.ChartType = horasComida.ChartType = SeriesChartType.Spline;

//chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
//chart1.Series.Add(horasComida);
//chart1.Series.Add(vecesComida);

//ComunicacionSerial.AbrirPuerto(puerto);
//await Task.Run(() =>
//{
//    while (true)
//    {
//        ComunicacionSerial.LeerDatos(puerto);
//        ActualizadorGrafica.Actualizar(chart1, horasComida, vecesComida);
//    }
//});

//string textoDeBusqueda = txtBusqueda.Text;
//bool txtBoxTieneTexto = !String.IsNullOrEmpty(textoDeBusqueda);
//if (txtBoxTieneTexto)
//{
//    foreach (var str in list)
//    {
//        if (str.Contains(textoDeBusqueda))
//        {
//            listVacas.Items.Add(str);
//        }
//    }
//}
//else if (textoDeBusqueda == "")
//{
//    foreach (var item in list)
//    {
//        listVacas.Items.Add(textoDeBusqueda);
//    }
//}