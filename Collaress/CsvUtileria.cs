using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace Collaress
{
    internal class CsvUtileria
    {
        private static int MaxNumDeDatos = 20;
        //private static string csvPath = @"..\..\..\InfoVacas\";
        public static string csvPath = @"C:\Users\ossie\Desktop\Vacas\";

        public static void GuardarEnCsv(int id, double horas, int vecesQueComio)
        {
            string rutaCompleta = $"{csvPath}vaca{id}.csv";
            if (File.Exists(rutaCompleta))
            {
                string record = $"{DateTime.Today.ToShortDateString()},{horas},{vecesQueComio}{Environment.NewLine}";
                File.AppendAllText(rutaCompleta, record);
            }
            else
            {
                CrearCsv(rutaCompleta, horas, vecesQueComio);
            }
        }

        private static void CrearCsv(string ruta, double horas, int vecesQueComio)
        {
            using (var streamWriter = new StreamWriter(ruta))
            {
                using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture))
                {
                    var vacas = VacaInfo.GetVacas(horas, vecesQueComio);
                    csvWriter.Context.RegisterClassMap<VacaInfoClassMap>();
                    csvWriter.WriteRecords(vacas);
                }
            }
        }

        //Tal vez usar
        private static void BorrarDatos(string rutaCompleta)
        {
            int numDeDatos = File.ReadAllLines(rutaCompleta).Length - 1;
            if (numDeDatos > MaxNumDeDatos)
            {
                //Borra el primer conjunto de datos
                string[] lineas = File.ReadAllLines(rutaCompleta).Skip(2).ToArray();
                lineas = lineas.Where(x => Array.IndexOf(lineas, x) != 1).ToArray();
                File.WriteAllLines(rutaCompleta, lineas);
            }
        }
    }
}
