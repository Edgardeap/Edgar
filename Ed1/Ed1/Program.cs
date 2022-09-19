using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Meetings;

namespace Calendario
{
    public class CalendarioCompromisso
    {
        public int[] diasMes = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public List<List<Compromisso>> calendarioCompromissoBase;
        public DateTime primerDiaSemana;
        public DateTime diaDeHoy;

        public CalendarioCompromisso()
        {
            diaDeHoy = DateTime.Today;
            primerDiaSemana = diaDeHoy.AddDays(DayOfWeek.Monday - diaDeHoy.DayOfWeek);

            //calendarioCitaBase = crearSemanaCalendario();
        }


        //Crea una lista de listas de citas para una semana
        public List<List<Compromisso>> criarSemanaCalendario()
        {
            List<List<Compromisso>> calendario = new List<List<Compromisso>>();
            int diaAtual = primerDiaSemana.Day;
            int mesAtual = primerDiaSemana.Month;
            int anoAtual = primerDiaSemana.Year;

            for (int i = 1; i <= 7; i++)
            {
                string date = diaAtual + "/" + mesAtual + "/" + anoAtual;

                Console.WriteLine("Data: {0}", date);

                calendario.Add(compromissoDia(mesAtual, diaAtual, anoAtual));

                if (diaAtual == diasMes[mesAtual - 1])
                {
                    diaAtual = 1;

                    if (mesAtual == 12)
                    {
                        mesAtual = 1;
                        anoAtual++;
                    }
                }
                else
                {
                    diaAtual++;
                }
            }

            return calendario;
        }

        public DateTime getPrimerDia()
        {
            return primerDiaSemana;
        }

        //Devuelve una lista con las citas de la fecha pasada como argumento
        public List<Compromisso> compromissoDia(int mes, int dia, int ano)
        {
            List<Compromisso> compromissos = new List<Compromisso>();
            string fechar = dia + "/" + mes + "/" + ano;

            //System.Console.WriteLine("{0}",fecha);vb 
            try
            {
                XElement raiz = XElement.Load("compromisso.xml");

                IEnumerable<Compromisso> compromissosX =
                    from el in raiz.Elements("compromisso")
                    where (string)el.Element("fechar") == fechar
                    select new Compromisso((string)el.Element("nomeCitação"),
                                    (string)el.Element("nomeContato"),
                                    (string)el.Element("fechar"),
                                    (string)el.Element("hora"),
                                    (string)el.Element("descricao"));

                foreach (Compromisso compromisso in compromissosX)
                {
                    compromissos.Add(compromisso);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }


            return compromissos;
        }
    }
}