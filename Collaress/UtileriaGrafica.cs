using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Utileria
{
    internal abstract class UtileriaGrafica
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
