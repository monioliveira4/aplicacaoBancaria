using System;
using System.Collections.Generic;

namespace aplicacaoBancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "x"){
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "X":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Eu te amo miau, volte sempre!");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            listaContas[indiceConta].Transferir(valorTransferencia,listaContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listaContas.Count ==0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i=0; i< listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Insira sua nova conta");

            Console.WriteLine("Digite 1 para conta física ou 2 para conta júridica: ");
            int novoTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o seu nome: ");
            string novoNome = Console.ReadLine();

            Console.Write("Digite o seu saldo inicial: ");
            double novoSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o seu crédito: ");
            double novoCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)novoTipoConta,
                                        saldo: novoSaldo,
                                        credito:novoCredito,
                                        nome: novoNome);
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao banco Blue Sky");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Criar nova conta");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Saque");
            Console.WriteLine("5 - Depósito");
            Console.WriteLine("6 - Cancelar");
            Console.WriteLine("x - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
