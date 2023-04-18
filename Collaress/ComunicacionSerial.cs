using System;
using System.IO.Ports;
using System.Windows.Forms;
using Utileria;

namespace Collaress
{
    internal class ComunicacionSerial
    {
        private static SerialPort puertoSerial;

        public static void SetPuerto(SerialPort puerto)
        {
            puertoSerial = puerto;
        }

        public static void AbrirPuerto()
        {
            if (puertoSerial.IsOpen) puertoSerial.Close();

            try
            {
                puertoSerial.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public static void LeerDatos()
        {
            string linea = puertoSerial.ReadLine();
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
        }

        public static void CerrarPuerto()
        {
            puertoSerial.Close();
        }
    }
}
