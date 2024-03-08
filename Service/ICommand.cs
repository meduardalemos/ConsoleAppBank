using ConsoleAppBank.Model;

namespace ConsoleAppBank.Service;

internal interface ICommand
{
    void Execute(Repositorio repositorio);
}
