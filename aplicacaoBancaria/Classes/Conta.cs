using System;
namespace aplicacaoBancaria
{
    public class Conta
    {
        //Atributos
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        //Métodos
        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;

        }
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
                this.Saldo -= valorSaque;
                Console.WriteLine("Saque realizado com sucesso!");
                Console.WriteLine("O saldo atual da sua conta é {0}", this.Saldo);
                return true;
        }

        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;
            Console.WriteLine("Deposito realizado com sucesso!");
            Console.WriteLine("O saldo atual da sua conta é {0}", this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito + " | ";
            return retorno;
        }
    }
}