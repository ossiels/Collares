using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public VentanaGrafico()
        {
            InitializeComponent();
        }

        private async void VentanaGrafico_Load(object sender, EventArgs e)
        {

            Series horasComida = new Series("Horas que comió");
            Series vecesComida = new Series("Veces que comió");
            vecesComida.ChartType = horasComida.ChartType = SeriesChartType.Spline;

            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart1.Series.Add(horasComida);
            chart1.Series.Add(vecesComida);

            ComunicacionSerial.AbrirPuerto(puerto);
            await Task.Run(() =>
            {
                while (true)
                {
                    ComunicacionSerial.LeerDatos(puerto);
                    ActualizadorGrafica.Actualizar(chart1, horasComida, vecesComida);
                }
            });
        }

        private void VentanaGrafico_FormClosing(object sender, FormClosingEventArgs e)
        {
            ComunicacionSerial.CerrarPuerto(puerto);
        }
    }
}
