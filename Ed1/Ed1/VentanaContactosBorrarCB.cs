using System;
using Gtk;
using Contactos;
using System.Diagnostics.Contracts;

namespace Ed1
{
    public class VentanaContatosApagarCB : Window
    {
        Label textoAMostrar;
        Contato toDelete;
        ComboBox comboBox;
        public VentanaContatosApagarCB() : base("Apagar Contatos")
        {
            //Config
            BorderWidth = 10;
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            VBox Main = new VBox();

            toDelete = null;
            textoAMostrar = new Label("Use o seletor para indicar o contato a ser excluído");

            comboBox = new ComboBox(Agenda.Get().ToStringCB());
            comboBox.Changed += mudarContato;

            Button AapagarContato = new Button("Apagar Contato");
            AapagarContato.Clicked += apagarContato;

            Main.Add(new Label("O seguinte contato será excluído: \n"));
            Main.Add(textoAMostrar);
            Main.Add(AapagarContato);
            Main.Add(comboBox);


            this.Add(Main);
            this.ShowAll();
        }


        void mudarContato(object sender, EventArgs args)
        {
            String[] nomeYSobrenome = comboBox.ActiveText.Split(','); //Esto es el Nombre,Apellidos
            String nome = nomeYSobrenome[0];
            String sobrenome = nomeYSobrenome[1];
            toDelete = Agenda.Get().GetContatoByNomeCompleto(nome, sobrenome);
            textoAMostrar.Text = toDelete.ToString();
        }


        void apagarContato(object sender, EventArgs args)
        {
            if (toDelete == null)
            {
                alertaNaoEliminavel();
            }
            else
            {
                Agenda agenda = Agenda.Get();
                agenda.DelContato(toDelete);
                agenda.SaveXML();
                alertaOperacaoBemSucedida();
                this.Destroy();
            }
        }


        //ALERTAS
        private void alertaNaoEliminavel()
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Warning,
                ButtonsType.Close, "O contato a ser excluído não foi selecionado");
            md.Run();
            md.Destroy();
        }
        private void alertaOperacaoBemSucedida()
        {
            MessageDialog md = new MessageDialog(this,
                DialogFlags.DestroyWithParent, MessageType.Info,
                ButtonsType.Ok, "Operação Bem Sucedida");
            md.Run();
            md.Destroy();
        }




    }
}
