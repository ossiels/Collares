using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
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

            Regex regex = new Regex(@"#(.*?)#");
            MatchCollection datosNumericos = regex.Matches(linea);
            if (datosNumericos.Count == 0) return;

            try
            {
                double horasComida = Convert.ToDouble(datosNumericos[0].Groups[1].Value);
                double vecesdoub = Convert.ToDouble(datosNumericos[1].Groups[1].Value);
                int vecesComida = Convert.ToInt32(vecesdoub);
                double idDoub = Convert.ToDouble(datosNumericos[2].Groups[1].Value);
                int id = Convert.ToInt32(idDoub);
                CsvUtileria.GuardarEnCsv(id, horasComida, vecesComida);
            }
            catch (Exception)
            {

            }
            
        }

        public static void CerrarPuerto()
        {
            puertoSerial.Close();
        }
    }
}
