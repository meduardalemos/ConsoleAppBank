using ConsoleAppBank.Model;
using System.Text;

namespace ConsoleAppBank.Service;

internal class ExportarContasParaArquivoCommand : ICommand
{
    public void Execute(Repositorio repositorio)
    {
        Console.Clear();
        Console.WriteLine("*** EXPORTAR CONTAS PARA UM ARQUIVO CSV ***");
        VerificaSeDesejaExportarContas(repositorio);
    }

    private void VerificaSeDesejaExportarContas(Repositorio repositorio)
    {
        Console.Write("Deseja exportar as contas no repositório para um arquivo csv? S/N ");
        string? opcaoInput = Console.ReadLine();

        if (opcaoInput != null)
        {
            string opcao = opcaoInput.Trim().Substring(0, 1).ToUpper();
            if (opcao.Equals("S"))
            {
                ExportarContas(repositorio);
            }
            else if (opcao.Equals("N"))
            {
                Console.WriteLine($"\nOperação para exportar contas para o arquivo foi cancelada.");
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

    private void ExportarContas(Repositorio repositorio)
    {
        List<ContaCorrente> listaDeContas = repositorio.RetornaListaDeContas();

        using (var fs = new FileStream("contasExportadas.csv", FileMode.Create))
        using (var sw = new StreamWriter(fs, Encoding.UTF8))
        {
            sw.WriteLine("NumeroAgencia;NumeroConta;SaldoConta;TitularConta");
            foreach (ContaCorrente conta in listaDeContas)
            {
                string informacoesDaConta = $"{conta.NumeroAgencia};{conta.NumeroConta};{conta.Saldo};{conta.Titular.Nome}";
                sw.WriteLine(informacoesDaConta);
                sw.Flush();
            }
            
            Console.WriteLine($"\nContas exportadas para o arquivo csv com sucesso");
            Console.Write("\nDigite qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
        }
    }
}
