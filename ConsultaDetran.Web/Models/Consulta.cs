
using System.Collections.Generic;

namespace ConsultaDetran.Web.Models
{
    

    public class Consulta
    {
        public string DataConsulta { get; set; }
        public string Renavan { get; set; }
        public string QtdMultas { get; set; }
        public Multa Multa { get; set; }
        public List<Multa> Multas { get; set; }
    }
    public class Multa
    {
        public string AutoDeInfracao { get; set; }
        public string AutoDeRenainf { get; set; }
        public string DataPgtoDesconto { get; set; }
        public string Enquadramento { get; set; }
        public string DatadaInfracao { get; set; }
        public string HoraDaInfracao { get; set; }
        public string Descricao { get; set; }
        public string PlacaRelacionada { get; set; }
        public string LocalInfracao { get; set; }
        public string ValorOriginal { get; set; }
        public string ValorSerPago { get; set; }
        public string StatusPagamento { get; set; }
        public string OrgaoEmissor { get; set; }
        public string AgenteEmissor { get; set; }
    }
}