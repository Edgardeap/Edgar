using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudo3
{
    class Program
    {
        static void Main(string[] args)
        {

            Filme filme = new Filme("Era do Gelo", "adassdadadas", 2004, "Dreamworks");
            Filme filme2 = filme;
            Filme filme3 = filme2;
            Filme filme4 = new Filme("Vingadores", "kaholaohja", 2019, "Disney");


            Console.WriteLine(filme3.nome);

            filme2.nome = "Sherek";

            Console.WriteLine(filme.nome);
            Console.WriteLine(filme4.nome);


            Console.ReadLine();
        }
    }

    abstract class Drawable
    {
        public int size; // não conseguimos incluir na interface
        public int color;
        public abstract void Draw();

        public abstract float Area();

    }

    interface IDrawable // desenhavel
    {
        void Draw();
        float Area();



    }
    class Line : Drawable
    {


        public override float Area()
        {
            return 0;
        }


        public override void Draw()
        {
            Console.WriteLine(" - Line - ");
        }
    }

    class Quad : IDrawable
    {
        public float Area()
        {
            return 2;
        }

        public void Draw()
        {
            Console.WriteLine(" - Quad - ");
        }
    }

    class Rect : IDrawable
    {
        public float Area()
        {
            return 10;
        }

        public void Draw()
        {
            Console.WriteLine(" - Rect - ");
        }
    }
}
