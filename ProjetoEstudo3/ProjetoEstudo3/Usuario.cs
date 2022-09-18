using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudo3
{
    class Usuario
    {
        public string nome;
        public string email;
        public string senha;
        protected string teste; // os filhos assim podem acessar este campo também

        public Usuario(string nome, string email, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
        }

        public void Logar()
        {
            Console.WriteLine(teste);
            Console.WriteLine("Logando....");

        }

        public void Logar(string codigo)
        {
            Console.WriteLine("Logando com codigo....");
        }

        public void Logar(string email, string senha)
        {
            Console.WriteLine("Logando com codigo....");
        }

        public virtual void Exibir()
        {
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Senha: {senha}");
        }
    }


    class Aluno : Usuario
    {
        public List<string> turmas = new List<string>();
        public string turno = "Matutino";
        // não conseguimos acessar o campo privado nos filhos, para acessar precisamos alterar para Protected.

        public Aluno(string turno, string nome, string email, string senha) : base(nome, email, senha)
        {
            this.turno = turno;
        }

        public override void Exibir()
        {
            Console.WriteLine("Dados do aluno: ");
            base.Exibir();
            Console.WriteLine("Turno: " + turno);
        }
    }


    class Zelador : Usuario
    {
        public List<string> tarefas = new List<string>();

        public Zelador(string nome, string email, string senha) : base(nome, email, senha)
        {

        }
    }
}
