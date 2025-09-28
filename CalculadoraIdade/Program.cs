using System;
using System.Globalization;

namespace CalculadoraIdade
{
    struct Pessoa
    {
        public string NomeCompleto;
        public DateTime DataNascimento;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pessoa usuario = new Pessoa();

            Console.WriteLine("--- Calculadora de Idade ---");
            Console.Write("Digite seu nome completo: ");
            usuario.NomeCompleto = Console.ReadLine();

            Console.Write("Digite sua data de nascimento (formato dd/MM/yyyy): ");

            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNasc))
            {
                usuario.DataNascimento = dataNasc;

                DateTime dataAtual = DateTime.Today;
                int idade = dataAtual.Year - usuario.DataNascimento.Year;

                if (dataAtual.DayOfYear < usuario.DataNascimento.DayOfYear)
                {
                    idade--;
                }

                Console.WriteLine("");
                Console.WriteLine($"Olá, {usuario.NomeCompleto}!");
                Console.WriteLine($"Você tem {idade} anos de idade.");
                Console.WriteLine("");

                if (idade >= 18)
                {
                    Console.WriteLine("Parabéns, você é maior de idade!");
                    Console.WriteLine("Você já pode realizar o procedimento para tirar sua carteira de habilitação (CNH).");
                }
                else
                {
                    Console.WriteLine("Você é menor de idade.");
                    int anosFaltantes = 18 - idade;
                    Console.WriteLine($"Faltam {anosFaltantes} ano(s) para você poder tirar sua CNH.");
                }
            }
            else
            {
                Console.WriteLine("\nFormato de data inválido. Por favor, reinicie o programa e use o formato dd/MM/yyyy.");
            }

            Console.WriteLine("\nPressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}