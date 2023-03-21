using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collaress
{
    internal class ComunicacionSerial
    {
        public static void AbrirPuerto(SerialPort puerto)
        {
            if (puerto.IsOpen) puerto.Close();

            try
            {
                puerto.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public static void LeerDatos(SerialPort puerto)
        {
            //string rawDatosRecibidos = puerto.ReadExisting();
            //string[] lineas = rawDatosRecibidos.Split('\n');

            //foreach (string linea in lineas)
            //{
            //    string[] datoNumerico = linea.Split('#');
            //    int id = Convert.ToInt32(datoNumerico[0]);
            //    double horasComida = Convert.ToDouble(datoNumerico[1]);
            //    int vecesComida = Convert.ToInt32(datoNumerico[2]);

            //    CsvUtileria.GuardarEnCsv(id, horasComida, vecesComida);
            //}

            string linea = puerto.ReadLine();
            string[] datosNumericos = linea.Split('#');

            try
            {
                int id = Convert.ToInt32(datosNumericos[0]);
                double horasComida = Convert.ToDouble(datosNumericos[1]);
                int vecesComida = Convert.ToInt32(datosNumericos[2]);
                CsvUtileria.GuardarEnCsv(id, horasComida, vecesComida);
            }
            catch (Exception)
            {
                //MessageBox.Show("Hubo un error al recibir los datos");
            }


            //TODO rodear con trycatch
        }

        public static void CerrarPuerto(SerialPort puerto)
        {
            puerto.Close();
        }
    }
}
