using System;
using Gtk;
using Meetings;

namespace Ed1
{
    public class VentanaCompromissoApagar : Window
    {
        private Controler_Meetings compromisso;
        private String[] nomesCompromisso;
        private String compromissoApagar;
        private Label textoAMostrar;

        public VentanaCompromissoApagar() : base("Eliminar Compromissos")
        {
            compromisso = new Controler_Meetings();
            compromissoApagar = "";
            nomesCompromisso = compromisso.GetAll();
            this.Build();
        }

        private void Build()
        {
            BorderWidth = 10;
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
                HBox H1 = new HBox();



                //Devolver el array de citas.
                ComboBox cb = new ComboBox(nomesCompromisso);
                cb.Changed += OnChanged;

                H1.Add(cb);

                textoAMostrar = new Label("...");

                Button btn = new Button("Apagar");
                btn.Clicked += Apagar;

                Main.Add(H1);
                Main.Add(textoAMostrar);
                Main.Add(btn);

            }
            Add(Main);
            this.ShowAll();

        }


        void OnChanged(object sender, EventArgs args)
        {
            ComboBox cb = (ComboBox)sender;
            compromissoApagar = cb.ActiveText;    //Este es la cita seleccionada
            textoAMostrar.Text = compromisso.ToViewMeetByName(compromissoApagar);
        }

        public void Apagar(object sender, EventArgs args)
        {
            if (compromissoApagar == "")
            {
                MessageDialog md = new MessageDialog(this,
                    DialogFlags.DestroyWithParent, MessageType.Warning,
                    ButtonsType.Close, "Selecione pelo menos um compromisso.");
                md.Run();
                md.Destroy();
            }
            else
            {
                if (compromisso.ToDeleteMeet(compromissoApagar))
                {
                    compromisso.ToGenerateXml();

                    MessageDialog md = new MessageDialog(this,
                        DialogFlags.DestroyWithParent, MessageType.Info,
                        ButtonsType.Close, "O compromisso foi excluído com sucesso.");
                    md.Run();
                    md.Destroy();
                }
                else
                {
                    MessageDialog md = new MessageDialog(this,
                        DialogFlags.DestroyWithParent, MessageType.Error,
                        ButtonsType.Close, "O compromisso não pôde ser excluído.");
                    md.Run();
                    md.Destroy();
                }
                this.Destroy();//Mirar si se cierra al guardar
            }
        }
    }
}
