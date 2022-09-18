using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudo4
{
    [System.Serializable]
    class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no Curso {nome}");
            Console.WriteLine("Digite a quantidade de Vagas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;//vagas = vagas + entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir Vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade que você quer consumir: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada; // vagas = estoque - entrada; 
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor:{autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas Restantes: {vagas}");
            Console.WriteLine("________________________________");
        }
    }
}
