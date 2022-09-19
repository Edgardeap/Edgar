using System;
using System.Collections.Generic;
using Gtk;
using Contactos;
using Notas;
using System.Diagnostics.Contracts;

namespace Ed1
{
    public class VentanaNotasApagar : Window
    {
        private VBox comentariosBox;
        private VBox mainBox;
        private Contato contato;
        private ComboBox lista_contatos;

        private List<Nota> notasTotal;
        private List<Nota> notasApagadas;

        private Dictionary<CheckButton, Nota> checks;


        public VentanaNotasApagar() : base("Apagar notas")
        {
            Agenda agenda = Agenda.Get();
            lista_contatos = new ComboBox(agenda.ToStringCB());
            lista_contatos.Changed += mudarContato;
            mainBox = new VBox();

            mainBox.Add(lista_contatos);
            Add(mainBox);
            ShowAll();
        }

        private void mudarContato(object sender, EventArgs args)
        {
            String[] nomyaps = lista_contatos.ActiveText.Split(',');
            String nome = nomyaps[0];
            String sobrenome = nomyaps[1];
            Agenda agenda = Agenda.Get();
            this.contato = agenda.GetContatoByNomeCompleto(nome, sobrenome);

            List<Nota> notasMostradas;
            notasTotal = Nota.GetNotasXML();
            notasMostradas = notasTotal.FindAll(x => x.contato.Equals(this.contato));

            if (comentariosBox != null)
                comentariosBox.Destroy();
            comentariosBox = new VBox();
            mainBox.Add(comentariosBox);

            checks = new Dictionary<CheckButton, Nota>();
            foreach (Nota n in notasMostradas)
            {
                HBox hbox = new HBox();
                CheckButton c = new CheckButton(n.ToString());
                hbox.Add(c);
                comentariosBox.Add(hbox);
                checks.Add(c, n);
            }

            Button apagar = new Button("Apagar");
            apagar.Clicked += apagarNotas;
            comentariosBox.Add(apagar);
            ShowAll();
        }

        private void apagarNotas(object sender, EventArgs args)
        {
            notasApagadas = new List<Nota>(notasTotal);

            foreach (KeyValuePair<CheckButton, Nota> c in checks)
            {
                if (c.Key.Active)
                {
                    notasApagadas.Remove(c.Value);
                }
            }
            Nota.SaveNotas(notasApagadas);
            Destroy();
        }
    }
}
