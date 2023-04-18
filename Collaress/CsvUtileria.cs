using CsvHelper;
using System;
using System.IO;
using System.Linq;

namespace Utileria
{
    internal class CsvUtileria
    {
        //TODO tal vez hacer una clase en comun con los valores que van a usar varias clases
        public static string csvPath = @"csvs\";

        private static int maxNumDeDatos = 10;

        public static void GuardarEnCsv(int id, double horas, int vecesQueComio)
        {
            string rutaCompleta = $"{csvPath}vaca{id}.csv";
            if (File.Exists(rutaCompleta))
            {
                string record = $"{DateTime.Today.ToShortDateString()},{horas},{vecesQueComio}{Environment.NewLine}";
                File.AppendAllText(rutaCompleta, record);
                ReducirCsv(rutaCompleta);
            }
            else
            {
                CrearCsv(rutaCompleta, horas, vecesQueComio);
            }
        }

        // Borra el dato mas viejo si el archivo .csv sobrepasa los 10 datos (10 dias)
        private static void ReducirCsv(string ruta)
        {
            string[] datos = File.ReadAllLines(ruta);
            int numeroDeDatos = datos.Length - 1;
            datos[1] = string.Empty;
            datos = datos.Where(x => x != string.Empty).ToArray();

            if (numeroDeDatos > maxNumDeDatos)
            {
                string rutaArchivoNuevo = ruta.Insert(ruta.Length - 4, "_temp");
                File.WriteAllLines(rutaArchivoNuevo, datos);
                string texto = File.ReadAllText(rutaArchivoNuevo);
                File.Replace(rutaArchivoNuevo, ruta, null);
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
            File.SetAttributes(ruta, FileAttributes.Hidden);
        }

        //Tal vez usar
        private static void BorrarDatos(string rutaCompleta)
        {
            int numDeDatos = File.ReadAllLines(rutaCompleta).Length - 1;
            if (numDeDatos > maxNumDeDatos)
            {
                //Borra el primer conjunto de datos
                string[] lineas = File.ReadAllLines(rutaCompleta).Skip(2).ToArray();
                lineas = lineas.Where(x => Array.IndexOf(lineas, x) != 1).ToArray();
                File.WriteAllLines(rutaCompleta, lineas);
            }
        }
    }
}

//ruta = ruta.Insert(ruta.Length - 4, "_HID");

//using (var streamWriter = new StreamWriter(ruta))
//{
//    using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.InvariantCulture))
//    {
//        var vacas = VacaInfo.GetVacas(horas, vecesQueComio);
//        csvWriter.Context.RegisterClassMap<VacaInfoClassMap>();
//        csvWriter.WriteRecords(vacas);
//        File.SetAttributes(ruta, FileAttributes.Hidden);
//    }
//}