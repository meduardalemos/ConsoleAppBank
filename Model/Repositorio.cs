namespace ConsoleAppBank.Model;

internal class Repositorio
{
    private List<ContaCorrente> ContasCorrente;

    public Repositorio()
    {
        ContasCorrente = new List<ContaCorrente>();
    }

    public void SalvarContaCorrente(ContaCorrente contaCorrente)
    {
        ContasCorrente.Add(contaCorrente);
        Console.WriteLine($"\nA conta nº{contaCorrente.NumeroConta} foi salva com sucesso na agência {contaCorrente.NumeroAgencia}!");
    }

    public void RemoverContaCorrente(ContaCorrente contaCorrente)
    {
        ContasCorrente.Remove(contaCorrente);
        Console.WriteLine($"\nA conta nº{contaCorrente.NumeroConta} foi removida com sucesso da agência {contaCorrente.NumeroAgencia}!");
    }
    public void ExibirContasCorrenteOrdenadas()
    {
        List<ContaCorrente> contasCorrenteOrdenadas = new List<ContaCorrente>(ContasCorrente);
        contasCorrenteOrdenadas.Sort();
        foreach(ContaCorrente conta in contasCorrenteOrdenadas)
        {
            conta.ExibirDetalhes();
        }
    }

    public ContaCorrente BuscarContaPorCpfTitular(string cpf)
    {
        return ContasCorrente.Where(conta => conta.Titular.Cpf.Equals(cpf)).FirstOrDefault();

    }
}
