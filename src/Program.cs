using src.Entities;
using src.Entities.Exceptions;
using System;
using System.Globalization;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Resolução do exercício de tratamento de exceções da seção 11");
            Console.WriteLine("Gerenciamento de conta bancária");
            Console.WriteLine();

            Account conta = new Account();

            bool loop = true;
            while (true)
            {
                try
                {
                    Console.WriteLine("Menu de opções");
                    Console.WriteLine("1) Cadastrar conta");
                    Console.WriteLine("2) Depósito");
                    Console.WriteLine("3) Saque");
                    Console.WriteLine("4) Sair");
                    Console.WriteLine("Opção: ");
                    int optSwitch = int.Parse(Console.ReadLine());

                    switch (optSwitch)
                    {
                        case 1:
                            // Cadastrar nova conta
                            Console.WriteLine(Environment.NewLine + "Cadastrar nova conta");
                            Console.Write("Número da conta ");
                            int numero = int.Parse(Console.ReadLine());
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();
                            Console.Write("Limite de saque: R$ ");
                            double limiteSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            conta = new Account(numero, nome, limiteSaque);
                            ////////////////////////
                            break;
                        case 2:
                            Console.WriteLine(Environment.NewLine + "Depósito");
                            break;
                        case 3:
                            Console.WriteLine(Environment.NewLine + "Saque");
                            break;
                        case 4:
                            Console.WriteLine(Environment.NewLine + "Sair");
                            break;

                        default:
                            Console.WriteLine(Environment.NewLine + "Opção inválida");
                            break;
                    }
                }
                catch (DomainException e)
                {
                    Console.WriteLine(Environment.NewLine + e.Message);
                }
            }
        }
    }
}
