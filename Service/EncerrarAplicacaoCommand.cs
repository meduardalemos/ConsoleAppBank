using ConsoleAppBank.Model;

namespace ConsoleAppBank.Service;

internal class EncerrarAplicacaoCommand : ICommand
{
    public void Execute(Repositorio repositorio)
    {
        Console.Clear();
        Console.WriteLine("*** ENCERRANDO APLICAÇÃO ***");
        return;
    }
}
