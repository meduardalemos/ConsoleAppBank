using ConsoleAppBank.Model;

namespace ConsoleAppBank.Service;

internal class DepositoViaPix
{
    private ContaCorrente Conta { get; set; }
    private decimal Valor { get; set; }

    public DepositoViaPix(ContaCorrente conta)
    {
        Conta = conta;
    }
    public void DepositarViaPix()
    {
        Console.Clear();
        Console.WriteLine("***   DEPÓSITO VIA PIX   ***");
        Console.Write("\nDigite o valor que você gostaria de depositar (mínimo R$ 100,00): R$ ");
        decimal valorDepositoInput = decimal.Parse(Console.ReadLine());
        VerificaECorrigeValorDeposito(valorDepositoInput);
        string codigoPix = GerarCodigoPix();
        Thread.Sleep(1000);
        Console.WriteLine("\nCopie o código abaixo e faça o depósito em sua conta através do pix: ");
        Console.WriteLine(codigoPix);
        ConfirmaPagamentoPix();
        return;
    }

    private string GerarCodigoPix()
    {
        Guid guid = Guid.NewGuid();
        decimal valorMultiplicadoPor100 = Valor * 100;
        int valorConvertidoParaInt = (int)valorMultiplicadoPor100;

        string valorHexadecimal = valorConvertidoParaInt.ToString("X4");

        Console.WriteLine($"\nGerando um código copia e cola para o valor R$ {Valor} ser depositado na conta " + $"AG {Conta.NumeroAgencia} CC {Conta.NumeroConta}...");

        return $"00020126580014br.gov.bcb.pix{guid.ToString()}52040000{Conta.Titular.Cpf}BR5913{Conta.Titular.Nome}6008BRASILIA62070503***630{valorHexadecimal}";
    }

    private void VerificaECorrigeValorDeposito(decimal valorDepositoInput)
    {
        if (valorDepositoInput < 100.00m || valorDepositoInput.Equals(null))
        {
            Console.WriteLine("O valor digitado não é válido. O código para depósito será gerado com o valor mínimo de R$ 100,00.");
            Valor = 100.00m;
        }
        else
        {
            Valor = valorDepositoInput;
        }
    }

    private void ConfirmaPagamentoPix()
    {
        Console.Write("\nDigite OK para confirmar que o pix foi feito ou qualquer outra tecla para cancelar a operação: ");
        string? confirmacaoPixInput = Console.ReadLine();

        if (confirmacaoPixInput != null && confirmacaoPixInput.Trim().Length == 2)
        {
            if (confirmacaoPixInput.Trim().ToUpper().Equals("OK"))
            {
                Conta.Depositar(Valor);
                Console.Clear();
                Console.WriteLine("... DEPÓSITO REALIZADO COM SUCESSO ...");
                Console.WriteLine($"\nSeu saldo agora é R$ {Conta.ObterSaldo()}.");
                Console.Write("\nDigite qualquer tecla para voltar ao Menu Principal...");
                Console.ReadKey();
                return;
            }
        }
        
        Console.Write("\nOperação cancelada! Digite qualquer tecla para voltar ao Menu Principal...");
        Console.ReadKey();
        return;
    }
}
