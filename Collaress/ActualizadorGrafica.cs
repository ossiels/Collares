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
        // TODO: que se muestren los valores de los datos
        public static void Actualizar(Chart grafica, Series horasComida, Series vecesComida)
        {
            ///////////////vecesComida.IsValueShownAsLabel = horasComida.IsValueShownAsLabel = true;
            horasComida.Points.Clear();
            vecesComida.Points.Clear();

            List<string[]> datos = ObtenerDatos();
            foreach (var dato in datos)
            {
                horasComida.Points.AddXY(dato[0], Convert.ToDouble(dato[1]));
                vecesComida.Points.AddY(Convert.ToInt32(dato[2]));
            }
        }

        // TODO: que la ruta cambie dependiendo de la id
        // Obtiene los ultimos 20 datos solamente
        private static List<string[]> ObtenerDatos()
        {
            string ruta = CsvUtileria.csvPath;
            string vaca = @"vaca95.csv";
            string rutaCompleta = ruta + vaca;

            string[] lineas = File.ReadAllLines(rutaCompleta).Skip(1).ToArray();
            bool masDeVeinteLineas = lineas.Length > 20;
            
            if (masDeVeinteLineas)
            {
                lineas = lineas.Skip(lineas.Length - 20).ToArray();
            }

            List<string[]> list = new List<string[]>();
            foreach (string line in lineas)
            {
                list.Add(line.Split(','));
            }
            return list;
        }
    }
}
