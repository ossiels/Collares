using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collaress
{
    public class VacaInfoClassMap : ClassMap<VacaInfo>
    {
        public VacaInfoClassMap()
        {
            Map(v => v.Dia).Name("fecha");
            Map(v => v.Horas).Name("horas");
            Map(v => v.VecesQueComio).Name("veces_que_comio");
        }
    }

    public class VacaInfo
    {
        public VacaInfo() { }
        public string Dia { get; set; }
        public double Horas { get; set; }
        public int VecesQueComio { get; set; }

        public static List<VacaInfo> GetVacas(double horas, int vecesQueComio)
        {
            return new List<VacaInfo>
            {
                new VacaInfo
                {
                    Dia = DateTime.Today.ToShortDateString(),
                    Horas = horas,
                    VecesQueComio = vecesQueComio
                }
            };
        }
    }
}
