using DocumentFormat.OpenXml.Packaging;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Utileria;

namespace Collaress
{
    public class CrearWord
    {
        private static string direccionPlantilla = Path.Combine(Path.GetFullPath(@"..\..\"), @"Resources\plantilla_reporte.docx");
        private static string direccionDestino = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public static void Crear(string vaca)
        {
            bool fileExists = File.Exists(direccionPlantilla);
            var fecha = DateTime.Today.ToString("yyyy-MM-dd");
            var archivoFinal = $@"\{vaca}_{fecha}.docx";
            var rutaArchivoFinal = direccionDestino + archivoFinal;

            File.Copy(direccionPlantilla, rutaArchivoFinal, true);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(rutaArchivoFinal, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                string[][] datos = UtileriaGrafica.ObtenerDatos(vaca).ToArray();
                for (int i = 0; i < datos.Length; i++)
                {
                    
                    //dato[0] es la fecha, [1] son las horas que la vaca comio y [2] son las veces
                    Regex regexFecha = new Regex($"fec{i}");
                    Regex regexVeces = new Regex($"veces{i}");
                    Regex regexHoras = new Regex($"hrs{i}");

                    docText = regexFecha.Replace(docText, datos[i][0]);
                    docText = regexHoras.Replace(docText, datos[i][1]);
                    docText = regexVeces.Replace(docText, datos[i][2]);
                }

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }
    }
}
