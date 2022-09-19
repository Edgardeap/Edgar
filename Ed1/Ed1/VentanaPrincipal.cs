using System;
using Gtk;
using Grafico;
using System.Reflection.Emit;
using Label = System.Reflection.Emit.Label;

namespace Ed1
{
    public class VentanaPrincipal : Window
    {
        VBox Main = new VBox();

        public VentanaPrincipal()
            : base("SharpAgenda")
        {
            //Config
            BorderWidth = 10;
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            DeleteEvent += delegate { Application.Quit(); };

            //Partes
            MenuBar mb = new MenuBar();

            Menu contatosOpcoes = new Menu();
            MenuItem contatosMenu = new MenuItem("Contatos");
            MenuItem contatosListar = new MenuItem("Listar contatos");
            contatosListar.Activated += ListarContatos;
            MenuItem contatosCriar = new MenuItem("Criar Contato");
            contatosCriar.Activated += CriarContato;
            MenuItem contatosApagar = new MenuItem("Apagar contatos");
            contatosApagar.Activated += ApagarContato;
            MenuItem contatosModificar = new MenuItem("Modificar contatos");
            contatosModificar.Activated += ModificarContato;

            Menu CompromissosOpcoes = new Menu();
            MenuItem compromissosMenu = new MenuItem("Compromissos");
            MenuItem compromissosListar = new MenuItem("Listar compromissos");
            compromissosListar.Activated += ListarCompromissos;
            MenuItem compromissosCriar = new MenuItem("Criar compromissos");
            compromissosCriar.Activated += CriarCompromissos;
            MenuItem compromissosApagar = new MenuItem("Apagar Compromissos");
            compromissosApagar.Activated += ApagarCompromissos;
            MenuItem compromissosModificar = new MenuItem("Modificar compromissos");
            compromissosModificar.Activated += ModificarCompromissos;

            Menu notasOpcoes = new Menu();
            MenuItem notasMenu = new MenuItem("Notas");
            MenuItem notasListar = new MenuItem("Listar notas");
            notasListar.Activated += ListarNotas;
            MenuItem notasCriar = new MenuItem("Criar notas");
            notasCriar.Activated += CriarNotas;
            MenuItem notasApagar = new MenuItem("Apagar notas");
            notasApagar.Activated += ApagarNotas;
            MenuItem notasModificar = new MenuItem("Modificar notas");
            notasModificar.Activated += ModificarNotas;

            Menu calendarioOpcoes = new Menu();
            MenuItem calendarioMenu = new MenuItem("Calendario");
            MenuItem calendarioVer = new MenuItem("Ver");
            calendarioVer.Activated += VerCalendario;

            contatosMenu.Submenu = contatosOpcoes;
            compromissosMenu.Submenu = compromissosOpcoes;
            notasMenu.Submenu = notasOpcoes;
            calendarioMenu.Submenu = calendarioOpcoes;

            contatosOpcoes.Append(contatosListar);
            contatosOpcoes.Append(contatosCriar);
            contatosOpcoes.Append(contatosApagar);
            contatosOpcoes.Append(contatosModificar);

            compromissosOpcoes.Append(compromissosListar);
            compromissosOpcoes.Append(compromissosCriar);
            compromissosOpcoes.Append(compromissosApagar);
            compromissosOpcoes.Append(compromissosModificar);

            notasOpcoes.Append(notasListar);
            notasOpcoes.Append(notasCriar);
            notasOpcoes.Append(notasApagar);
            notasOpcoes.Append(notasModificar);

            calendarioOpcoes.Append(calendarioVer);

            mb.Append(contatosMenu);
            mb.Append(compromissosMenu);
            mb.Append(notasMenu);
            mb.Append(calendarioMenu);
            //PASTEADO
            VBox menuBox = new VBox(false, 2);
            menuBox.PackStart(mb, false, false, 0);

            VBox textBox = new VBox();

            textBox.Add(new Label("Bem Vindo a SharpAgenda\nSelecione uma opção usando o menu"));
            Main.Add(menuBox);
            Main.Add(textBox);

            Add(Main);
            ShowAll();

        }
        void ListarContatos(object sender, EventArgs args)
        {
            new VentanaContatosListar();
        }
        void CriarContato(object sender, EventArgs args)
        {
            new VentanaContatosCriar();
        }
        void ApagarContato(object sender, EventArgs args)
        {
            new VentanaContatosApagarCB();
        }
        void ModificarContato(object sender, EventArgs args)
        {
            new VentanaContatosModificar();
        }
        void ListarCompromissos(object sender, EventArgs args)
        {
            new VentanaCompromissoListar();
        }
        void CriarCompromissos(object sender, EventArgs args)
        {
            new VentanaCompromissoNova();
        }
        void ApagarCompromissos(object sender, EventArgs args)
        {
            new VentanaCompromissoApagar();
        }
        void ModificarCompromissos(object sender, EventArgs args)
        {
            new VentanaCompromissoModificar();
        }
        void VerCalendario(object sender, EventArgs args)
        {
            new VentanaGrafico();
        }

        void ListarNotas(object sender, EventArgs args)
        {
            new VentanaNotasListar();
        }
        void CriarNotas(object sender, EventArgs args)
        {
            new VentanaNotasCriar();
        }
        void ModificarNotas(object sender, EventArgs args)
        {
            new VentanaNotasModificar();
        }
        void ApagarNotas(object sender, EventArgs args)
        {
            new VentanaNotasApagar();
        }
    }
}

