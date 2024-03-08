using ConsoleAppBank.Model;

namespace ConsoleAppBank.Service;

internal class DepositarEmUmaContaCommand : ICommand
{
    public void Execute(Repositorio repositorio)
    {
        Console.Clear();
        Console.WriteLine("*** DEPOSITAR EM UMA CONTA ***");
        Console.Write("Digite o CPF (apenas números) do titular da conta em que deseja fazer um depósito: ");
        ContaCorrente contaParaDeposito = repositorio.BuscarContaPorCpfTitular(Console.ReadLine());
        if (contaParaDeposito != null)
        {
            Console.Clear();
            Console.WriteLine("Confirme os detalhes da conta para depósito abaixo:");
            contaParaDeposito.ExibirDetalhes();
            Console.Write("\nConfirma a conta para depósito? S/N ");

            string? opcaoInput = Console.ReadLine();

            if (opcaoInput != null)
            {
                string opcaoPix = opcaoInput.Trim().Substring(0, 1).ToUpper();
                if (opcaoPix.Equals("S"))
                {
                    DepositoViaPix depositoViaPix = new(contaParaDeposito);
                    depositoViaPix.DepositarViaPix();
                    Console.ReadKey();
                }
                else if (opcaoPix.Equals("N"))
                {
                    Console.WriteLine("Depósito em conta cancelado, digite qualquer tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida! Digite qualquer teclar para retornar ao menu principal.");
                Console.ReadKey();
                return;
            }
        } else
        {
            Console.Write("\nNenhuma conta foi encontrada cujo titular tenha esse CPF, digite qualquer tecla para voltar ao menu principal. ");
            Console.ReadKey();
            return;
        }  
    }
}
