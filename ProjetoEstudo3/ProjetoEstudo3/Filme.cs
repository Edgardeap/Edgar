using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudo3
{
    class Filme
    {
        public string nome;
        public string desc;
        public int ano;
        public string studio;

        private List<string> atores = new List<string>();

        static public string plataforma = "Prime Video";

        public Filme(string nome, string desc, int ano, string studio)// construtor de objetos
        {
            this.nome = nome;
            this.desc = desc;
            this.ano = ano;
            this.studio = studio;
        }


        public void Executar()
        {
            Console.WriteLine("Rodando Filme: " + nome);
        }

        public void Pausar()
        {
            Console.WriteLine(" || ");
        }

        // Metodo encapsulador é um metodo que é publico e que vc manipula uma informação privada
        public void ADDAtor(string nome)
        {
            if (nome != null)
            {
                if (nome.Length > 4)
                {
                    atores.Add(nome);
                }

            }

        }
        public void ExibirAtores()
        {
            foreach (string ator in atores)
            {
                Console.WriteLine(ator);
            }
        }
    }
}
