
using ConsoleAppBank.Model;
using ConsoleAppBank.Service;
using ICommand = ConsoleAppBank.Service.ICommand;

namespace ConsoleAppBank.View;

internal class MenuPrincipal
{
    private readonly Repositorio Repositorio;

    Dictionary<string, ICommand> comandos = new Dictionary<string, ICommand>
    {
        {"1", new CadastrarContaCommand() },
        {"2", new EncerrarContaCommand() },
        {"3", new ListarTodasAsContasCommand() },
        {"4", new DepositarEmUmaContaCommand() },
        {"5", new ExportarContasParaArquivoCommand() },
        {"0", new EncerrarAplicacaoCommand()}

    };

    public MenuPrincipal(Repositorio repositorio)
    {
        Repositorio = repositorio;
    }

    public void ExibeMenuPrincipal()
    {
        string opcao = "";

        while (opcao != "0")
        {
            Console.Clear();
            Console.WriteLine("SEJA BEM VINDO AO BYTEBANK!\n\n");
            Console.WriteLine("===== Menu Principal =====");
            Console.WriteLine("1 - Cadastrar nova conta");
            Console.WriteLine("2 - Encerrar conta");
            Console.WriteLine("3 - Listar todas as contas ordenadas pelo nome do titular");
            Console.WriteLine("4 - Depositar em uma conta");
            Console.WriteLine("5 - Exportar contas para um arquivo csv");
            Console.WriteLine("0 - Encerrar aplicação");
            Console.WriteLine("==========================");
            Console.Write("\nEscolha uma opção: ");

            opcao = Console.ReadLine();

            if (opcao == null || !comandos.ContainsKey(opcao))
            {
                Console.Clear();
                Console.WriteLine("... OPÇÃO INVÁLIDA! ...");
                Console.Write("Digite qualquer tecla para voltar ao menu principal ");
                Console.ReadKey();
            } else
            {
                comandos[opcao].Execute(Repositorio);
            }
        }
    }
}
