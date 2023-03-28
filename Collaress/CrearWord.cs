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
        public static void Crear(string path)
        {
            var templateName = "cale.docx";
            var templatePath = path + templateName;
            var finalFile = "resultado.docx";
            var finalFilePath = path + finalFile;

            File.Copy(templatePath, finalFilePath, true);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(finalFilePath, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Regex regexNombre = new Regex("_Nombre_");
                Regex regexPais = new Regex("_Pais_");
                docText = regexNombre.Replace(docText, "Ossiel");
                docText = regexPais.Replace(docText, "México");

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
