namespace ConsoleAppBank.Model;

internal class ContaCorrente : IComparable<ContaCorrente>
{
    public Titular Titular { get; }
    public int NumeroAgencia { get; }
    public string NumeroConta { get; }
    public decimal Saldo { get; private set; }
  

    public ContaCorrente(Titular titular, int numeroAgencia, string numeroConta)
    {
        Titular = titular;
        NumeroAgencia = numeroAgencia;
        NumeroConta = numeroConta;
        Saldo = 0.00m;

    }

    public void ExibirDetalhes()
    {
        Console.WriteLine("\n***   DETALHES DA CONTA   ***");
        Console.WriteLine("Número da Agência: " + NumeroAgencia);
        Console.WriteLine("Número da Conta: " + NumeroConta);
        Console.WriteLine("Titular da Conta: " + Titular.ToString());
        Console.WriteLine("Saldo da conta: R$ " + Saldo);
    }


    public decimal ObterSaldo()
    {
        return Saldo;
    }

    public void Depositar(decimal valorDeposito)
    {
        Saldo += valorDeposito;
    }

    public int CompareTo(ContaCorrente? other)
    {
        return this.Titular.Nome.CompareTo(other.Titular.Nome);
    }
}
