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
            string c = puerto.ReadLine();
            string[] datosRecibidos = c.Split('#');

            //TODO rodear con trycatch
            int id = Convert.ToInt32(datosRecibidos[0]);
            double horasComida = Convert.ToDouble(datosRecibidos[1]);
            int vecesComida = Convert.ToInt32(datosRecibidos[2]);

            CsvUtileria.GuardarEnCsv(id, horasComida, vecesComida);
        }

        public static void CerrarPuerto(SerialPort puerto)
        {
            puerto.Close();
        }
    }
}
