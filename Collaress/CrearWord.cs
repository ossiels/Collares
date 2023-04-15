using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using System.Windows.Forms;

namespace Collaress
{
    public class CrearWord
    {
        //C:\Users\HP PAVILION DV6\Desktop\Word Collares\
        //C:\Users\ossie\Desktop\prueba\
        private static string path = @"C:\Users\HP PAVILION DV6\Desktop\Word Collares\";

        public static void Crear(string vaca)
        {
            var fecha = DateTime.Today.ToString("yyyy-MM-dd");
            var templateName = "plantilla.docx";
            var templatePath = path + templateName;
            var finalFile = $"{vaca}_{fecha}.docx";
            var finalFilePath = path + finalFile;

            File.Copy(templatePath, finalFilePath, true);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(finalFilePath, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                string[][] datos = ActualizadorGrafica.ObtenerDatos(vaca).ToArray();
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
            //Imprimir(finalFilePath);
        }

        private static void Imprimir(string filePath)
        {
            using (PrintDialog pd = new PrintDialog())
            {
                pd.ShowDialog();
                ProcessStartInfo info = new ProcessStartInfo(filePath);
                info.Verb = "PrintTo";
                info.Arguments = pd.PrinterSettings.PrinterName;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(info);
            }
        }
    }
}
