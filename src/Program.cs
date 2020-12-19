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
            while (loop)
            {
                try
                {
                    int optSwitch;
                    if (conta.Name != null)
                    {
                        Console.WriteLine(Environment.NewLine + "Conta cadastrada:");
                        Console.WriteLine(conta.ToString() + Environment.NewLine);

                        Console.WriteLine("Menu de opções");
                        Console.WriteLine("1) Cadastrar conta");
                        Console.WriteLine("2) Depósito");
                        Console.WriteLine("3) Saque");
                        Console.WriteLine("4) Sair");
                        Console.Write("Opção: ");
                        optSwitch = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        optSwitch = 1;
                    }

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
                            Console.Write("Deseja fazer um depósito inicial (s/n)? ");
                            string resposta = Console.ReadLine().Trim().ToLower();
                            if (resposta[0] == 's' || resposta[0] == 'y')
                            {
                                Console.Write("Depósito inicial: R$ ");
                                conta.Deposit(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                            } 
                            ////////////////////////
                            break;
                        case 2:
                            // Opção depósito
                            Console.WriteLine(Environment.NewLine + "Depósito");
                            Console.Write("Valor do depósito: R$ ");
                            conta.Deposit(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                            ///////////////////////
                            break;
                        case 3:
                            // Opção saque
                            Console.WriteLine(Environment.NewLine + "Saque");
                            Console.Write("Valor do saque: R$ ");
                            conta.Withdraw(double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
                            ///////////////////////
                            break;
                        case 4:
                            Console.WriteLine(Environment.NewLine + "Sair");
                            loop = false;
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
