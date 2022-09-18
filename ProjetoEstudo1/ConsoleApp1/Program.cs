using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        enum Menu { Soma = 1, Subtracao, Divisao, Multiplicacao, Potencia, Raiz, Sair }



        static void Main(string[] args)
        {
            bool escolheuSair = false;
            while (!escolheuSair) // (!escolheuSair) leia- se: ENQUANTO O USUARIO NÃO(!) ESCOLHER SAIR EXIBA O MENU
            {
                Console.WriteLine("Seja bem vindo a Calculadora, Selecione uma das Opções Abaixo: ");
                Console.WriteLine("1 - Soma\n2 - Subtração\n3 - Divisão\n4 - Multiplicação\n5 - Potência\n6 - Raiz Quadrada\n7 - Sair");

                Menu opcao = (Menu)int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case Menu.Soma:
                        Soma();
                        break;
                    case Menu.Subtracao:
                        Subtracao();
                        break;
                    case Menu.Divisao:
                        Divisao();
                        break;
                    case Menu.Multiplicacao:
                        Multiplicacao();
                        break;
                    case Menu.Potencia:
                        Potencia();
                        break;
                    case Menu.Raiz:
                        Raiz();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }

                Console.Clear();
            }
        }
        static void Soma()
        {
            Console.WriteLine("Soma de dois números: ");
            Console.WriteLine("Digite o primeiro número: ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número: ");
            float b = float.Parse(Console.ReadLine());
            float resultado = a + b;
            Console.WriteLine($"O Resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar para o menu");
            Console.ReadLine();
        }
        static void Subtracao()
        {
            Console.WriteLine("Subtração de dois números: ");
            Console.WriteLine("Digite o primeiro número: ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número: ");
            float b = float.Parse(Console.ReadLine());
            float resultado = a - b;
            Console.WriteLine($"O Resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar para o menu");
            Console.ReadLine();
        }
        static void Divisao()
        {
            Console.WriteLine("Divisão de dois números: ");
            Console.WriteLine("Digite o primeiro número: ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número: ");
            float b = float.Parse(Console.ReadLine());
            float resultado = a / b; // poderia ter deixado em int e feito apenas a alteração float resultado = (float) a/(float)b; isso se chama cast
            Console.WriteLine($"O Resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar para o menu");
            Console.ReadLine();
        }
        static void Multiplicacao()
        {
            Console.WriteLine("Multiplicação de dois números: ");
            Console.WriteLine("Digite o primeiro número: ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo número: ");
            float b = float.Parse(Console.ReadLine());
            float resultado = a * b;
            Console.WriteLine($"O Resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar para o menu");
            Console.ReadLine();
        }
        static void Potencia() // Potencia  numero base elevado a outro numero (2^4 = 2*2*2*2)
        {
            Console.WriteLine("Potência de um números: ");
            Console.WriteLine("Digite a base: ");
            double baseNum = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o expoente: ");
            double expo = double.Parse(Console.ReadLine());
            double resultado = Math.Pow(baseNum, expo); // Math.Pow = calculo de potencia dentro da biblioteca do C#

            // numeros decimais:
            // Float (6 a 9 digitos após na casa decimal)
            // Double (15 a 17 digitos apos a casa decimal)
            // Decimal (28 a 29 digitos apos a casa decimal)

            Console.WriteLine($"O Resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar para o menu");
            Console.ReadLine();
        }
        static void Raiz()
        {
            Console.WriteLine("Raiz Quadrada de um números: ");
            Console.WriteLine("Digite a número: ");
            double a = double.Parse(Console.ReadLine());
            double resultado = Math.Sqrt(a); // Math.Sqrt = calculo de Square Root (Raiz Quadrada) dentro da biblioteca do C#
            Console.WriteLine($"O Resultado é: {resultado}");
            Console.WriteLine("Aperte ENTER para voltar para o menu");
            Console.ReadLine();
        }
    }
}
