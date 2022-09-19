using System;
using Gtk;
using Contactos;
using Meetings;

namespace Ed1
{
    public class VentanaCompromissoModificar : Window
    {
        private String fecharSalvar;
        private Controler_Meetings compromisso;
        private String[] nomesCompromisso;
        private String[] nomesContatos;
        private String compromissoAModificar;
        private String contatoASalvar;

        private Entry NomeCompromisso;
        //private Entry NombreContacto;
        //Entry Fecha =; //Utilizo un calendario en vez de una entrada
        private Entry Hora;
        private Entry Endereco;

        private Label textoAMostrar;

        private ComboBox cbModifica;

        private Calendar calendar;

        public VentanaCompromissoModificar() : base("Modificar Compromisso")
        {
            compromisso = new Controler_Meetings();
            nomesCompromisso = compromisso.GetAll();
            nomesContatos = Agenda.Get().ToStringCB();
            fecharSalvar = "";
            this.Build();
        }

        private void Build()
        {
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            VBox Main = new VBox();

            if (nomesCompromisso.Length == 0)
            {
                textoAMostrar = new Label("Você não tem horários disponíveis.");
                Main.Add(textoAMostrar);
            }
            else
            {

                HBox H0 = new HBox();
                HBox H00 = new HBox();
                HBox H1 = new HBox();
                HBox H2 = new HBox();
                HBox H3 = new HBox();
                HBox H4 = new HBox();
                HBox H5 = new HBox();

                NomeCompromisso = new Entry();
                //NombreContacto = new Entry ();
                ComboBox cb = new ComboBox(nomesCompromisso); //Selleccionar Contacto.
                cb.Changed += OnChanged;
                cbModifica = new ComboBox(nomesContatos); //Selleccionar Contacto.
                cbModifica.Changed += OnChanged2;
                //Entry Fecha = new Entry ();
                Hora = new Entry();
                Endereco = new Entry();

                textoAMostrar = new Label("...");
                Label LnomesCompromisso = new Label("ID do compromisso: ");
                Label LNomeContato = new Label("Nome de contato: ");
                Label LFechar = new Label("Fechar: ");
                Label LHora = new Label("Hora: ");
                Label LEndereco = new Label("Endereco: ");

                //Calendario
                calendar = new Calendar();
                calendar.DaySelected += OnDaySelected;

                //Fixed fix = new Fixed();
                //fix.Put(calendar, 20, 20);
                //fix.Put(label, 40, 230);

                H0.Add(textoAMostrar);
                H00.Add(cb);
                H1.Add(LnomesCompromisso);
                H1.Add(NomeCompromisso);
                H2.Add(LNomeContato);
                H2.Add(cbModifica);
                H3.Add(LFechar);
                H3.Add(calendar);
                H4.Add(LHora);
                H4.Add(Hora);
                H5.Add(LEndereco);
                H5.Add(Endereco);

                Main.Add(H0);
                Main.Add(H00);
                Main.Add(H1);
                Main.Add(H2);
                Main.Add(H3);
                Main.Add(H4);
                Main.Add(H5);

                Button btn = new Button("Salvar");
                btn.Clicked += Salvar;

                Main.Add(btn);
            }
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
            compromissoAModificar = cb.ActiveText; //Este es la cita seleccionada
            textoAMostrar.Text = compromisso.ToViewMeetByName(compromissoAModificar);

            NomeCompromisso.Text = compromisso.ToGetMeetByName(compromissoAModificar).Nome;
            String nomeYSobrenome = compromisso.ToGetMeetByName(compromissoAModificar).NomeContato;
            String nome = nomeYSobrenome.Split(',')[0];
            String Sobrenome = nomeYSobrenome.Split(',')[1];
            cbModifica.Active = (Agenda.Get().GetPosicion(Agenda.Get().GetContatoByNomeCompleto(nome, Sobrenome))); //Inicializamos combo box a una posicion

            String fechar = compromisso.ToGetMeetByName(compromissoAModificar).Fechar; //Ponemos el calendario a lo qe estaba antiguamente
            String dia = fechar.Split('/')[0];
            String mes = fechar.Split('/')[1];
            String ano = fechar.Split('/')[2];
            calendar = new Calendar();
            calendar.DaySelected += OnDaySelected;
            calendar.Day = Int32.Parse(dia.Trim());
            calendar.Month = Int32.Parse(mes.Trim());
            calendar.Year = Int32.Parse(ano.Trim());
            calendar.MarkDay((uint)calendar.Day);
            calendar.SelectDay((uint)calendar.Day);
            calendar.SelectMonth((uint)calendar.Month, (uint)calendar.Year);

            Hora.Text = compromisso.ToGetMeetByName(compromissoAModificar).Hora;
            Endereco.Text = compromisso.ToGetMeetByName(compromissoAModificar).Endereco;

        }

        void OnChanged2(object sender, EventArgs args)
        {
            ComboBox cb = (ComboBox)sender;
            contatoASalvar = cb.ActiveText;   //Este es la cita seleccionada
                                                //textoAMostrar.Text = citas.ToViewMeetByName(citaABorrar);
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
                compromisso.ToModifyMeet(compromissoAModificar, NomeCompromisso.Text, contatoASalvar, fecharSalvar, Hora.Text, Endereco.Text);
                compromisso.ToGenerateXml();

                MessageDialog md = new MessageDialog(this,
                    DialogFlags.DestroyWithParent, MessageType.Info,
                    ButtonsType.Close, "Compromisso modificado com sucesso. ");
                md.Run();
                md.Destroy();

                this.Destroy();
            }
        }
    }
}
