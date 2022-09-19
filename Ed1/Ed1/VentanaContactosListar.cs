using System;
using Gtk;
using Contactos;

namespace Ed1
{
    public class VentanaContatosListar : Window
    {
        public VentanaContatosListar() : base("Lista de contatos")
        {
            BorderWidth = 10;
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            Agenda agenda = Agenda.Get();
            VBox Main = new VBox();
            if (agenda.IsEmpty())
            {
                Main.Add(new Label("Não há contatos para mostrar"));
            }
            else
            {
                Label label = new Label(agenda.ToString());
                label.SetAlignment(0, 1);
                Main.Add(label);
            }
            Add(Main);
            ShowAll();
        }
    }
}
