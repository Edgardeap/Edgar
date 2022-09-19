using System;
using System.IO;
using System.Collections.Generic;
using Gtk;
using Notas;
using Contactos;

namespace Ed1
{
    public class VentanaNotasCriar : Gtk.Window
    {

        private Entry email;
        private Entry conteudo;
        public VentanaNotasCriar() : base("Criar Notas")
        {
            this.Build();
        }

        private void Build()
        {
            VBox main = new VBox();

            Label labelEmail = new Label("Email: ");
            email = new Entry();
            conteudo = new Entry();
            Button criar = new Button("Criar nota");
            criar.Clicked += CriarNota;

            main.Add(labelEmail);
            main.Add(email);
            main.Add(conteudo);
            main.Add(criar);

            Add(main);
            ShowAll();
        }

        private void CriarNota(object sender, EventArgs args)
        {
            Nota n = new Nota();
            Agenda agenda = Agenda.Get();
            n.contato = agenda.GetContatoByEmail(email.Text);
            if (n.contato == null)
            {
                alertaContatoNulo(email.Text);
            }
            n.conteudo = conteudo.Text;

            System.Console.WriteLine(n.contato.ToString());

            List<Nota> notas = Nota.GetNotasXML();
            notas.Add(n);

            Nota.SaveNotas(notas);
            Destroy();
        }

        private void alertaContatoNulo(string email)
        {
            MessageDialog md = new MessageDialog(this,
                                   DialogFlags.DestroyWithParent, MessageType.Info,
                                   ButtonsType.Ok, "Contato " + email + " não encontrado.");
            md.Run();
            md.Destroy();
        }
    }
}

