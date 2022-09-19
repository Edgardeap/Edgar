using System;
using System.Collections.Generic;
using Gtk;
using Contactos;
using Notas;
using System.Diagnostics.Contracts;

namespace Ed1
{
    public class VentanaNotasModificar : Gtk.Window
    {
        private VBox inf;
        private Contato contato;
        private ComboBox listaContatos;
        private VBox mainBox;
        private List<Nota> notasModificadas;
        private List<Nota> notasNoModificadas;
        private List<Nota> notasTotal;
        private List<Entry> entradasNota;

        public VentanaNotasModificar() : base("Modificar notas")
        {
            mainBox = new VBox();
            inf = new VBox();

            listaContatos = new ComboBox(Agenda.Get().ToStringCB());
            listaContatos.Changed += mudarContato;
            mainBox.Add(listaContatos);

            Add(mainBox);
            mainBox.Add(inf);
            ShowAll();
        }

        private void mudarContato(object sender, EventArgs args)
        {
            String[] nomyaps = listaContatos.ActiveText.Split(',');
            String nome = nomyaps[0];
            String sobrenome = nomyaps[1];
            Agenda agenda = Agenda.Get();
            this.contato = agenda.GetContatoByNomeCompleto(nome, sobrenome);

            notasTotal = Nota.GetNotasXML();
            notasModificadas = notasTotal.FindAll(x => x.contato.Equals(this.contato));
            notasNoModificadas = new List<Nota>(notasTotal);
            notasNoModificadas.RemoveAll(x => x.contato.Equals(this.contato));
            entradasNota = new List<Entry>();

            inf.Destroy();
            inf = new VBox();
            foreach (Nota nota in notasModificadas)
            {
                Entry entrada_nota = new Entry();
                entrada_nota.Text = nota.conteudo;
                inf.Add(entrada_nota);
                entradasNota.Add(entrada_nota);
            }
            Button enviar = new Button("Enviar");
            enviar.Clicked += modificarNotas;
            inf.Add(enviar);
            mainBox.Add(inf);
            ShowAll();
        }

        private void modificarNotas(object sender, EventArgs args)
        {
            notasTotal = new List<Nota>();
            foreach (Entry e in entradasNota)
            {
                Nota nova_nota = new Nota();
                nova_nota.contato = this.contato;
                nova_nota.conteudo = e.Text;
                notasTotal.Add(nova_nota);
            }
            foreach (Nota n in notasNoModificadas)
            {
                notasTotal.Add(n);
            }
            Nota.SaveNotas(notasTotal);
            Destroy();
        }
    }
}

