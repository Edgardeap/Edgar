using System;
using Gtk;
using Calendario;
using Meetings;
using System.Collections.Generic;

namespace Grafico
{
    public class VentanaGrafico : Window
    {

        String[] Days = { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado", "Domingo" };
        public List<List<Compromisso>> calendarioSemana;
        VBox Main = new VBox();
        HBox DayContainer = new HBox();
        VBox[] Dias = new VBox[7];
        int primerDia;
        int cont;

        public VentanaGrafico()
            : base("Gráfico")
        {
            //Config
            DayContainer.Spacing = 30;
            BorderWidth = 10;
            SetPosition(WindowPosition.Center);



            CalendarioCompromisso calendario = new CalendarioCompromisso();
            calendarioSemana = calendario.criarSemanaCalendario();
            primerDia = calendario.getPrimerDia().Day;

            //Crea los dias
            for (int i = 0; i < 7; i++)
            {
                Label h = new Label(Days[i] + "  " + primerDia.ToString());
                h.SetAlignment(0, 0);
                Dias[i] = new VBox();
                Dias[i].Add(h);
                DayContainer.Add(Dias[i]);
                primerDia++;
            }

            cont = 0;
            calendarioSemana.ForEach(delegate (List<Compromisso> c)
            {
                Label Compromisso;

                cont++;
                c.ForEach(delegate (Compromisso compromisso)
                {
                    Compromissos = new Label(compromisso.ToString());
                    Compromissos.SetAlignment(0, 0);
                    Dias[cont - 1].Add(Compromissos);

                });
            });

            //Enseña la interfaz
            Main.Add(DayContainer);
            this.Add(Main);
            this.ShowAll();
        }
    }
}
