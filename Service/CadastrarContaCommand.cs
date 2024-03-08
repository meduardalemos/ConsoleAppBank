using ConsoleAppBank.Model;

namespace ConsoleAppBank.Service;

internal class CadastrarContaCommand : ICommand
{
    private Dictionary<string, int> agenciasPorRegiao = new Dictionary<string, int>
    {
        {"CO", 1010 },
        {"NE", 2020 },
        {"NO", 3030 },
        {"SE", 4040 },
        {"SU", 5050 },
        {"DI", 1001 }
    };

    public void Execute(Repositorio repositorio)
    {
        Console.Clear();
        Console.WriteLine("***   CADASTRO DE NOVA CONTA   ***");
        Titular titular = new();
        titular.CadastrarInformacoesTitular();
        Console.ReadKey();
        
        int numeroAgencia = GerarNumeroAgencia();
        string numeroConta = GerarNumeroConta();

        ContaCorrente conta = new(titular, numeroAgencia, numeroConta);
        repositorio.SalvarContaCorrente(conta);
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("... CONTA ABERTA COM SUCESSO ...");
        conta.ExibirDetalhes();

        VerificarOpcaoPix(conta);

    }

    private int GerarNumeroAgencia()
    {
        Console.Clear();
        Console.WriteLine("Agora precisamos de informações sobre onde você reside");
        Console.WriteLine("\nCO - Centro-oeste, NE - Nordeste, NO - Norte, SE - Sudeste, SU - Sul");
        Console.Write("Digite a sigla referente à sua região de acordo com a legenda acima: ");
        string? regiao = Console.ReadLine();

        if (string.IsNullOrEmpty(regiao) || regiao.Length < 2)
        {
            Console.WriteLine("\nNão foi possível identificar a sua região. Sua agência será digital. " +
                "Digite qualuer tecla para continuar.");
            Console.ReadKey();
            return 1001;
        }

        string regiaoSigla = regiao.Substring(0, 2).ToUpper();
        if (agenciasPorRegiao.ContainsKey(regiaoSigla))
        {
            return agenciasPorRegiao[regiaoSigla];
        }

        Console.WriteLine("\nNão foi possível identificar a sua região. Sua agência será digital. " +
                "Digite qualuer tecla para continuar.");
        Console.ReadKey();
        return 1001;
    }

    public string GerarNumeroConta()
    {
        Random random = new();
        int numero = random.Next(0, 10000);
        int digito = random.Next(0, 10);
        return numero.ToString() + "-" + digito.ToString();
    }

    private void VerificarOpcaoPix(ContaCorrente conta)
    {
        Console.WriteLine($"\nO saldo da sua conta é R$ {conta.ObterSaldo()}.");
        Console.Write("Você gostaria de fazer um depósito via pix? S/N: ");

        string? opcaoPixInput = Console.ReadLine();

        if (opcaoPixInput != null)
        {
            string opcaoPix = opcaoPixInput.Trim().Substring(0, 1).ToUpper();
            if (opcaoPix.Equals("S"))
            {
                DepositoViaPix depositoViaPix = new(conta);
                depositoViaPix.DepositarViaPix();
            }
            else if (opcaoPix.Equals("N"))
            {
                Console.WriteLine($"\nCerto, seu saldo permanecerá R$ {conta.ObterSaldo()}.");
                Console.Write("Digite qualquer teclar para retornar ao menu principal...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Opção inválida! Digite qualquer teclar para retornar ao menu principal...");
            Console.ReadKey();
        }
    }
}
