using System;
using Gtk;
using Contactos;
using System.Diagnostics.Contracts;

namespace Ed1
{
    public class VentanaContatosModificar : Window
    {
        Contato toMod;
        ComboBox comboBox;
        Entry Nome;
        Entry Sobrenome;
        Entry Endereco;
        Entry Telefone;
        Entry Email;

        public VentanaContatosModificar() : base("Modificar contatos")
        {
            //Config
            BorderWidth = 10;
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);

            VBox Main = new VBox();
            //TODO ESTA TARDE

            comboBox = new ComboBox(Agenda.Get().ToStringCB());
            comboBox.Changed += mudarContato;

            Button botonModificar = new Button("Modificar");
            botonModificar.Clicked += modificarContato;

            Nome = new Entry();
            Sobrenome = new Entry();
            Endereco = new Entry();
            Telefone = new Entry();
            Email = new Entry();

            Label labelNomeContato = new Label("Nome");
            labelNomeContato.SetAlignment(0, 1);
            Label labelSobrenomeContato = new Label("Sobrenomes");
            labelSobrenomeContato.SetAlignment(0, 1);
            Label labelEnderecoContato = new Label("Endereço");
            labelEnderecoContato.SetAlignment(0, 1);
            Label labelTelefoneContato = new Label("Telefone");
            labelTelefoneContato.SetAlignment(0, 1);
            Label labelEmailContato = new Label("Email");
            labelEmailContato.SetAlignment(0, 1);

            Main.Add(comboBox);
            Main.Add(labelNomeContato);
            Main.Add(Nome);
            Main.Add(labelSobrenomeContato);
            Main.Add(Sobrenome);
            Main.Add(labelEnderecoContato);
            Main.Add(Endereco);
            Main.Add(labelTelefoneContato);
            Main.Add(Telefone);
            Main.Add(labelEmailContato);
            Main.Add(Email);
            Main.Add(botonModificar);

            this.Add(Main);
            this.ShowAll();
        }

        void mudarContato(object sender, EventArgs args)
        {
            String[] nomeYSobrenome = comboBox.ActiveText.Split(','); //Esto es el Nombre,Sobrenomes
            String nome = nomeYSobrenome[0];
            String sobrenome = nomeYSobrenome[1];
            toMod = Agenda.Get().GetContatoByNomeCompleto(nome, sobrenome);
            Nome.Text = toMod.Nome;
            Sobrenome.Text = toMod.Sobrenome;
            Endereco.Text = toMod.Endereco;
            Telefone.Text = toMod.Telefone;
            Email.Text = toMod.Email;
        }

        void modificarContato(object sender, EventArgs args)
        {
            if (toMod == null)
            {
                alertaNaoModificavel();
            }
            else
            {
                if (Nome.Text == "")
                {
                    alertaIntroducaAoMenosumNome();
                }
                else
                {
                    Agenda agenda = Agenda.Get();
                    int pos = agenda.GetPosicion(toMod);
                    agenda.ModificarContato(pos, Nome.Text, Sobrenome.Text, Endereco.Text, Email.Text, Telefone.Text);
                    agenda.SaveXML();
                    alertaDeOperacaoBemSucedida();
                    this.Destroy();
                }
            }
        }

        //ALERTAS
        private void alertaNaoModificavel()
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Warning,
                ButtonsType.Close, "O contato a ser modificado não foi selecionado");
            md.Run();
            md.Destroy();
        }

        private void alertaDeOperacaoBemSucedida()
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Info,
                ButtonsType.Ok, "Operação bem-sucedida");
            md.Run();
            md.Destroy();
        }

        private void alertaIntroducaAoMenosumNome()
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Warning,
                ButtonsType.Close, "Digite pelo menos um nome para o contato");
            md.Run();
            md.Destroy();
        }
    }
}
