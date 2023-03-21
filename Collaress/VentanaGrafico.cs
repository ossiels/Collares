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

        // TODO: Mandar el puerto solo una vez
        public VentanaGrafico()
        {
            InitializeComponent();
        }

        private void VentanaGrafico_Load(object sender, EventArgs e)
        {
            puerto.NewLine = "\r\n";
            ComunicacionSerial.AbrirPuerto(puerto);
            try
            {
                LlenarListVacas();
                listVacas.SelectedIndex = 0;
                GraficaSetup();
                lblVacaId.Text = ObtenerIdSeleccionada();
            }
            catch (Exception)
            {
                //MessageBox.Show("Error papu");
            }
        }

        private void LlenarListVacas()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\ossie\Desktop\Vacas\");
            FileInfo[] files = dirInfo.GetFiles("*.csv");
            files =
                files.Where
                    (file => !file.Name.Contains("temp"))
                    .ToArray();

            int[] arrayIDs = new int[0];

            foreach (FileInfo file in files)
                arrayIDs = arrayIDs.Append
                    (Convert.ToInt32(file.Name.Split('.')[0].Substring(4)))
                    .ToArray();

            Array.Sort(arrayIDs);

            foreach (int id in arrayIDs)
            {
                string vacaId = "Vaca" + id;
                listVacas.Items.Add(vacaId);
            }
        }

        private void GraficaSetup()
        {
            vecesComida.ChartType = horasComida.ChartType = SeriesChartType.Line;
            graficoVacaInfo.Series.Add(horasComida);
            graficoVacaInfo.Series.Add(vecesComida);

            graficoVacaInfo.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            graficoVacaInfo.ChartAreas[0].AxisX.MajorGrid.Interval = 1;
            graficoVacaInfo.ChartAreas[0].BackColor = Color.FromArgb(155, 191, 169);
            //chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;?

            graficoVacaInfo.Series[0].IsValueShownAsLabel = true;
            graficoVacaInfo.Series[1].IsValueShownAsLabel = true;

            graficoVacaInfo.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            graficoVacaInfo.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            graficoVacaInfo.Legends[0].Alignment = StringAlignment.Center;
            ActualizarGrafico();
        }

        private void ActualizarGrafico()
        {
            string vacaSeleccionada = ObtenerIdSeleccionada().ToLower();
            ActualizadorGrafica.Actualizar(graficoVacaInfo, horasComida, vecesComida, vacaSeleccionada);
        }

        private void VentanaGrafico_FormClosing(object sender, FormClosingEventArgs e)
        {
            ComunicacionSerial.CerrarPuerto(puerto);
        }

        private void puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ComunicacionSerial.LeerDatos(puerto);
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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

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
            string texto = txtBusqueda.Text;
            bool txtBoxTieneTexto = !String.IsNullOrEmpty(texto);
            
            if (txtBoxTieneTexto)
            {
                texto = texto.Insert(0, "Vaca");
                listVacas.SelectedItem = texto;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {

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