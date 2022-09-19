using System;
using Gtk;
using Contactos;
using System.Diagnostics.Contracts;

namespace Ed1
{
    public class VentanaContatosCriar : Window
    {
        //Para usar en el create se sacan del constructor
        private Entry nomeContato;
        private Entry sobrenomeContato;
        private Entry enderecoContato;
        private Entry telefoneContato;
        private Entry emailContato;


        public VentanaContatosCriar() : base("Criar contato")
        {
            BorderWidth = 10;
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            VBox Main = new VBox();

            nomeContato = new Entry();
            sobrenomeContato = new Entry();
            enderecoContato = new Entry();
            telefoneContato = new Entry();
            emailContato = new Entry();

            //Si tal, ya si eso, gravedad izquierda en las labels porque estan al medio
            Label labelNomeContato = new Label("Nome");
            Label labelSobrenomeContato = new Label("Sobrenome");
            Label labelEnderecoContato = new Label("Endereco");
            Label labelTelefoneContato = new Label("Telefone");
            Label LabelEmailContato = new Label("Email");

            Button guardar = new Button("Salvar");
            guardar.Clicked += criarContato;

            Main.Add(labelNomeContato);
            Main.Add(nomeContato);
            Main.Add(labelSobrenomeContato);
            Main.Add(sobrenomeContato);
            Main.Add(labelEnderecoContato);
            Main.Add(enderecoContato);
            Main.Add(labelTelefoneContato);
            Main.Add(telefoneContato);
            Main.Add(LabelEmailContato);
            Main.Add(emailContato);
            Main.Add(guardar);


            Add(Main);
            ShowAll();
        }

        void criarContato(object sender, EventArgs args)
        {
            if (nomeContato.Text != "")
            {
                //Crear el contacto
                Contato nuevo = new Contato(nomeContato.Text, sobrenomeContato.Text,
                                      enderecoContato.Text,
                    telefoneContato.Text, emailContato.Text);
                Agenda agenda = Agenda.Get();
                agenda.AddContato(nuevo);
                agenda.SaveXML();
                alertaOperacaoBemSucedida();
                this.Destroy();

            }
            else
            {
                alertaDigitePeloMenosONome();
            }
        }

        //ALERTAS
        private void alertaOperacaoBemSucedida()
        {
            MessageDialog md = new MessageDialog(this,
                                   DialogFlags.DestroyWithParent, MessageType.Info,
                                   ButtonsType.Ok, "Operação Bem-Sucedida");
            md.Run();
            md.Destroy();
        }

        private void alertaDigitePeloMenosONome()
        {
            MessageDialog md = new MessageDialog(this,
                                    DialogFlags.DestroyWithParent, MessageType.Warning,
                                    ButtonsType.Close, "Digite pelo menos um nome para o contato");
            md.Run();
            md.Destroy();
        }

    }
}
