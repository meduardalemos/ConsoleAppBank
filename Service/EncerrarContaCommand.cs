using ConsoleAppBank.Model;

namespace ConsoleAppBank.Service;

internal class EncerrarContaCommand : ICommand
{
    public void Execute(Repositorio repositorio)
    {
        Console.Clear();
        Console.WriteLine("***   ENCERRAMENTO DE CONTA   ***");
        Console.Write("Digite o CPF (apenas números) do titular da conta que deseja encerrar: ");
        ContaCorrente contaASerEncerrada = repositorio.BuscarContaPorCpfTitular(Console.ReadLine());
        if(contaASerEncerrada != null)
        {
            Console.Clear();
            Console.WriteLine("Confirme os detalhes da conta a ser encerrada abaixo:");
            contaASerEncerrada.ExibirDetalhes();
            Console.Write("\nConfirma a conta a ser encerrada? S/N ");

            string? opcaoInput = Console.ReadLine();

            if (opcaoInput != null)
            {
                string opcaoPix = opcaoInput.Trim().Substring(0, 1).ToUpper();
                if (opcaoPix.Equals("S"))
                {
                    Console.Clear();
                    repositorio.RemoverContaCorrente(contaASerEncerrada);
                    Console.Write("Digite qualquer tecla para voltar ao menu principal... ");
                    Console.ReadKey();
                }
                else if (opcaoPix.Equals("N"))
                {
                    Console.WriteLine("\nEncerramento de conta cancelado, digite qualquer tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("\nOpção inválida! Digite qualquer teclar para retornar ao menu principal.");
                Console.ReadKey();
                return;
            }
        } else
        {
            Console.WriteLine("\nNenhuma conta foi encontrada cujo titular tenha esse CPF, digite qualquer tecla para voltar ao menu principal. ");
            Console.ReadKey();
            return;
        }
    }
}
