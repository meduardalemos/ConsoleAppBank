using ConsoleAppBank.Model;

namespace ConsoleAppBank.Service;

internal class ListarTodasAsContasCommand : ICommand
{
    public void Execute(Repositorio repositorio)
    {
        Console.Clear();
        Console.WriteLine("*** LISTA DE CONTAS ORDENADAS PELO NOME DO TITULAR ***");
        repositorio.ExibirContasCorrenteOrdenadas();
        Console.Write("\nDigite qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
    }
}
