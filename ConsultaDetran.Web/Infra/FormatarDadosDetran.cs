using ConsultaDetran.Web.Models;
using System;
using System.Collections.Generic;

namespace ConsultaDetran.Web.Infra
{
   
    public class FormatarDadosDetran
    {
        private static string stringFinal { get; set; }

        public static Consulta MontarObjVeiculo(string renavan, string resp)
        {

            stringFinal = resp;

            Consulta v = new Consulta();
            v.QtdMultas = recuperaColunaValor( resp, ColunaDetran.QtdMultas);
            v.DataConsulta = recuperaColunaValor(stringFinal, ColunaDetran.DataConsulta);
            v.Renavan = recuperaColunaValor(stringFinal, ColunaDetran.Renavan);
            
            List<Multa> listaMarca = new List<Multa>();
            v.Multas = new List<Multa>();
            if (!string.IsNullOrEmpty(v.QtdMultas))
            {
                int qtd = Convert.ToInt32(v.QtdMultas);
                for (int i = 0; i < qtd; i++)
                {
                    v.Multa = new Multa();
                    Consulta itemVeiculo = new Consulta();
                    v.Multa.AutoDeInfracao = recuperaColunaValor(stringFinal, ColunaDetran.AutoDeInfracao);
                    v.Multa.AutoDeRenainf = recuperaColunaValor(stringFinal, ColunaDetran.AutoDeRenainf);
                    v.Multa.DataPgtoDesconto = recuperaColunaValor(stringFinal, ColunaDetran.DataPgtoDesconto);
                    v.Multa.Enquadramento = recuperaColunaValor(stringFinal, ColunaDetran.Enquadramento);
                    v.Multa.DatadaInfracao = recuperaColunaValor(stringFinal, ColunaDetran.DatadaInfracao);
                    v.Multa.HoraDaInfracao = recuperaColunaValor(stringFinal, ColunaDetran.HoraDaInfracao);
                    v.Multa.Descricao = recuperaColunaValor(stringFinal, ColunaDetran.Descricao);
                    v.Multa.PlacaRelacionada = recuperaColunaValor(stringFinal, ColunaDetran.PlacaRelacionada);
                    v.Multa.LocalInfracao = recuperaColunaValor(stringFinal, ColunaDetran.LocalInfracao);
                    v.Multa.ValorOriginal = recuperaColunaValor(stringFinal, ColunaDetran.ValorOriginal);
                    v.Multa.ValorSerPago = recuperaColunaValor(stringFinal, ColunaDetran.ValorSerPago);
                    v.Multa.StatusPagamento = recuperaColunaValor(stringFinal, ColunaDetran.StatusPagamento);
                    v.Multa.OrgaoEmissor = recuperaColunaValor(stringFinal, ColunaDetran.OrgaoEmissor);
                    v.Multa.AgenteEmissor = recuperaColunaValor(stringFinal, ColunaDetran.AgenteEmissor);

                    v.Multas.Add(v.Multa);
                    removerTabela();
                }
            }

            return v;
        }
        
        private static string recuperaColunaValor(string pattern, Models.ColunaDetran col)
        {

            var r = pattern.Replace("\n", "").Replace("\t", "").Replace("\r", "");

            switch (col)
            {
                #region MyRegion

                case ColunaDetran.DataConsulta://OK
                    {
                        r = stringEntreString(r, "<tr><td><span class=\"sub-titulo\">Data da consulta: </span>", "</td>");
                        return r.Trim();
                    }
                case ColunaDetran.Renavan://OK
                    {
                        r = stringEntreString(r, "<td><span class=\"sub-titulo\">Renavam: </span>", "</td></tr>");
                        return r.Trim();
                    }
                case ColunaDetran.QtdMultas://OK
                    {
                        r = stringEntreString(r, "<div class=\"paginate\">", " multas encontradas");//". PÃ¡gina 1 de 1</div>");
                        string qtd = r;
                        return r.Trim();
                    }
                case ColunaDetran.AutoDeInfracao://OK
                    {
                        r = stringEntreString(r, "<td><span class=\"sub-titulo\">Auto de InfraÃ§Ã£o:<br></span>", "   </td>");
                        return r.Trim();
                    }
                case ColunaDetran.DataPgtoDesconto://OK
                    {
                        r = stringEntreString(r, " <td colspan=\"2\"><span class=\"sub-titulo\">Data para pagamento com desconto:<br></span>", "</td></tr><tr>");
                        return r.Trim();
                    }
                case ColunaDetran.Enquadramento://OK
                    {
                        r = stringEntreString(r, "<td colspan=\"2\"><span class=\"sub-titulo\">Enquadramento da InfraÃ§Ã£o:<br></span>", "</td> <td><span class=\"sub-titulo\">Data da Infra");

                        return r.Trim();
                    }
                case ColunaDetran.DatadaInfracao://OK
                    {
                        r = stringEntreString(r, "<span class=\"sub-titulo\">Data da InfraÃ§Ã£o:<br></span>", "</td> <td><span class=\"sub-titulo\">Hora:");
                        return r.Trim();
                    }
                case ColunaDetran.HoraDaInfracao://OK
                    {
                        r = stringEntreString(r, "<td><span class=\"sub-titulo\">Hora:<br></span>", "</td></tr><tr><td colspan=\"3\"><span class=\"sub-titulo\">Descri");
                        return r.Trim();
                    }
                case ColunaDetran.Descricao://OK
                    {
                        r = stringEntreString(r, "<tr><td colspan=\"3\"><span class=\"sub-titulo\">DescriÃ§Ã£o:<br></span>", "</td> <td><span class=\"sub-titulo\">Placa");
                        return r.Trim();
                    }
                case ColunaDetran.AutoDeRenainf://OK
                    {
                        r = stringEntreString(r, "<td><span class=\"sub-titulo\">Auto de Renainf:<br>", "\">Data para pagamento");
                        r = stringEntreString(r, "</span>", "</td>");
                        r = r.Replace("</span>", "");
                        return r.Trim();
                    }
                case ColunaDetran.PlacaRelacionada://OK
                    {
                        //r = stringEntreString(r, "</td> <td><span class=\"sub-titulo\">Placa Relacionada:<br></span>", "class=\"sub-titulo\">Local da InfraÃ§Ã£o");
                        r = stringEntreString(r, "</td> <td><span class=\"sub-titulo\">Placa Relacionada:<br>", "class=\"sub-titulo\">Local da InfraÃ§Ã£o");
                        r = stringEntreString(r, "</span>", "</td>");
                        r = r.Replace("</span>", "");
                        return r.Trim();
                    }
                case ColunaDetran.LocalInfracao://OK
                    {
                        r = stringEntreString(r, "<tr><td colspan=\"2\"><span class=\"sub-titulo\">Local da InfraÃ§Ã£o:<br>", "<span class=\"sub-titulo\">Valor original R$");
                        r = stringEntreString(r, "</span>", "</td>");
                        r = r.Replace("</span>", "");
                        return r.Trim();
                    }
                case ColunaDetran.ValorOriginal://OK
                    {
                        r = stringEntreString(r, " <td><span class=\"sub-titulo\">Valor original R$:<br>", "Valor a ser pago");
                        r = stringEntreString(r, "</span>", "</td>");
                        r = r.Replace("</span>", "");
                        return r.Trim();
                    }
                case ColunaDetran.ValorSerPago://OK
                    {
                        r = stringEntreString(r, "<td colspan=\"2\"><span class=\"sub-titulo\">Valor a ser pago R$:<br>", "<td colspan=\"2\"><span class=\"sub-titulo\">Status de Pagamento:");
                        r = stringEntreString(r, "</span>", "</td>");
                        r = r.Replace("</span>", "");
                        return r.Trim();
                    }
                case ColunaDetran.StatusPagamento://OK
                    {
                        r = stringEntreString(r, "<tr><td colspan=\"2\"><span class=\"sub-titulo\">Status de Pagamento:<br>", "<td><span class=\"sub-titulo\">Ã\u0093rgÃ£o Emissor");
                        r = stringEntreString(r, "</span>", "</td>");
                        r = r.Replace("</span>", "");
                        return r.Trim();
                    }
                case ColunaDetran.OrgaoEmissor://OK
                    {
                        r = stringEntreString(r, "<td><span class=\"sub-titulo\">ÃrgÃ£o Emissor:<br>", "<span class=\"sub-titulo\">Agente Emissor");
                        r = stringEntreString(r, "</span>", "</td>");
                        r = r.Replace("</span>", "");
                        return r.Trim();
                    }
                #endregion
                case ColunaDetran.AgenteEmissor:
                    {
                        r = stringEntreString(r, "<td><span class=\"sub-titulo\">Agente Emissor:<br></span>", "</td></tr></table></br>");
                        return r.Trim();
                    }
                default:
                    {
                        return r;
                    }
            }
        }

        private static string stringEntreString(string str, string strInicio, string strFinal)
        {
            var ini = str.IndexOf(strInicio);
            var fim = str.IndexOf(strFinal);

            if (ini > 0)
                ini = ini + strInicio.Length;

            if (fim > 0)
                fim = fim + strFinal.Length;

            var diff = ((fim - ini) - strFinal.Length);
            if ((fim > ini) && (diff > 0))
                return str.Substring(ini, diff);
            else
                return string.Empty;
        }
        private static void removerTabela()
        {
            string strInicio = "<table class=\"tabelaDescricao\">";
            string strFinal = "</table></br>";

            var ini = stringFinal.IndexOf(strInicio);
            var fim = stringFinal.IndexOf(strFinal);

            var indiceInicial = ini;    

            if (ini > 0)
                ini = ini + strInicio.Length;

            if (fim > 0)
                fim = fim + strFinal.Length;

            var diff = ((fim - ini) - strFinal.Length);

            var qtd = strInicio.Length + diff + strFinal.Length;

            if ((fim > ini) && (diff > 0))
            {
                stringFinal = stringFinal.Remove(indiceInicial, qtd);
            }
        }

        //private static string stringSaltaString(string str, string strInicio)
        //{
        //    var ini = str.IndexOf(strInicio);

        //    if (ini > 0)
        //    {
        //        ini = ini + strInicio.Length;
        //        return str.Substring(ini);
        //    }
        //    else
        //        return str;
        //}

        //private string stringPrimeiraLetraMaiuscula(string str)
        //{
        //    return
        //        str.Length > 0 ?
        //            str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1).ToLower() :
        //            string.Empty;

        //}
    }
}