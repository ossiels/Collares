using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Collaress
{
    internal abstract class ActualizadorGrafica
    {
        public static void Actualizar(Chart grafica, Series horasComida, Series vecesComida, string vaca)
        {
            horasComida.Points.Clear();
            vecesComida.Points.Clear();

            List<string[]> datos = ObtenerDatos(vaca);
            foreach (var dato in datos)
            {
                horasComida.Points.AddXY(dato[0], Convert.ToDouble(dato[1]));
                vecesComida.Points.AddY(Convert.ToInt32(dato[2]));
            }
        }

        // TODO: que sea arreglo en lugar de lista
        // TODO: poner este metodo en la clase de CsvUtileria
        public static List<string[]> ObtenerDatos(string vaca)
        {
            string ruta = CsvUtileria.csvPath;
            string rutaCompleta = ruta + vaca + ".csv";

            string[] lineas = File.ReadAllLines(rutaCompleta).Skip(1).ToArray();

            List<string[]> list = new List<string[]>();
            foreach (string line in lineas)
            {
                list.Add(line.Split(','));
            }
            return list;
        }
    }
}
