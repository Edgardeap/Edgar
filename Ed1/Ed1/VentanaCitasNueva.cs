using System;
using Gtk;
using Contactos;
using Meetings;

namespace Ed1
{
    public class VentanaCompromissoNova : Window
    {
        private String fecharSalvar;
        private Controler_Meetings compromisso;
        private String[] nomeContatos;
        private String contatoASalvar;

        Entry NomeCompromisso;
        //Entry NombreContacto;
        ComboBox cb;
        //Entry Fecha =; //Utilizo un calendario en vez de una entrada
        Entry Hora;
        Entry Endereco;


        public VentanaCompromissoNova() : base("Novo Compromisso")
        {
            compromisso = new Controler_Meetings();
            nomeContatos = Agenda.Get().ToStringCB();
            contatoASalvar = "";
            fecharSalvar = "";
            this.Build();
        }

        private void Build()
        {
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            VBox Main = new VBox();

            HBox H1 = new HBox();
            HBox H2 = new HBox();
            HBox H3 = new HBox();
            HBox H4 = new HBox();
            HBox H5 = new HBox();

            NomeCompromisso = new Entry();
            //NombreContacto = new Entry ();
            cb = new ComboBox(nomeContatos); //Selleccionar Contacto.
            cb.Changed += OnChanged;

            //Entry Fecha = new Entry ();
            Hora = new Entry();
            Endereco = new Entry();

            Label LnomeCompromisso = new Label("ID do compromisso: ");
            Label LNomeContato = new Label("Nome do contato: ");
            Label LFechar = new Label("Fechar: ");
            Label LHora = new Label("Hora: ");
            Label LEndereco = new Label("Endereço: ");

            //Calendario
            Calendar calendar = new Calendar();
            calendar.DaySelected += OnDaySelected;

            //Fixed fix = new Fixed();
            //fix.Put(calendar, 20, 20);
            //fix.Put(label, 40, 230);

            H1.Add(LnomeCompromisso);
            H1.Add(NomeCompromisso);
            H2.Add(LNomeContato);
            H2.Add(cb);
            H3.Add(LFechar);
            H3.Add(calendar);
            H4.Add(LHora);
            H4.Add(Hora);
            H5.Add(LEndereco);
            H5.Add(Endereco);

            Main.Add(H1);
            Main.Add(H2);
            Main.Add(H3);
            Main.Add(H4);
            Main.Add(H5);

            Button btn = new Button("Guardar");
            btn.Clicked += Salvar;

            Main.Add(btn);

            Add(Main);
            this.ShowAll();
        }


        void OnDaySelected(object sender, EventArgs args)
        {
            Calendar cal = (Calendar)sender;
            fecharSalvar = cal.Day + "/" + (cal.Month + 1) + "/" + cal.Year; //Fecha en String
        }

        void OnChanged(object sender, EventArgs args)
        {
            ComboBox cb = (ComboBox)sender;
            contatoASalvar = cb.ActiveText;   //Este es la cita seleccionada
        }

        public void Salvar(object sender, EventArgs args)
        {
            if ((NomeCompromisso.Text == "") || (contatoASalvar == "") || fecharSalvar == "")
            {
                MessageDialog md = new MessageDialog(this,
                    DialogFlags.DestroyWithParent, MessageType.Warning,
                    ButtonsType.Close, "Preencha os campos: Identificador de Compromisso, Nome do Contato e Data.");
                md.Run();
                md.Destroy();
            }
            else
            {
                compromisso.ToAddNewMeet(NomeCompromisso.Text, contatoASalvar, fecharSalvar, Hora.Text, Endereco.Text);
                compromisso.ToGenerateXml();
                this.Destroy();
            }
        }
    }
}

