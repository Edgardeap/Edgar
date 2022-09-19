using System;
using Gtk;
using Calendario;
using Meetings;

namespace Ed1
{
    public class VentanaCompromissoListar : Window
    {
        private Controler_Meetings compromisso;
        private String listado;

        public VentanaCompromissoListar() : base("Listar Compromisso")
        {
            compromisso = new Controler_Meetings();
            listado = compromisso.ToString();
            this.Build();
        }

        private void Build()
        {
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            VBox Main = new VBox();
            //DeleteEvent += delegate { Application.Quit(); };

            if (listado == "")
            {
                Label aMostrar = new Label("Não há compromissos salvos.");
                Main.Add(aMostrar);
            }
            else
            {
                System.Console.Write(listado);
                Label aMostrar = new Label(listado);
                Main.Add(aMostrar);
            }

            Add(Main);
            this.ShowAll();
        }
    }
}
