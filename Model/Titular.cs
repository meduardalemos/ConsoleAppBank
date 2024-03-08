namespace ConsoleAppBank.Model;

internal class Titular
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Profissao { get; set; }

    public Titular() 
    {
        Nome = "";
        Cpf = "";
        Profissao = "";
    }

    public Titular(string nome, string cpf, string profissao)
    {
        Nome = nome;
        Cpf = cpf;
        Profissao = profissao;
    }


    public void CadastrarInformacoesTitular()
    {
        Console.WriteLine("Digite as informações do titular da conta abaixo");
        Console.Write("Nome: ");
        Nome = Console.ReadLine();
        Console.Write("CPF (apenas números): ");
        Cpf = Console.ReadLine();
        Console.Write("Profissão: ");
        Profissao = Console.ReadLine();

        Console.WriteLine($"\nInformações do titular foram atualizadas!");
    }

    public override string ToString()
    {
        return $"{Nome} - CPF: {Cpf} - PROF: {Profissao}";
    }
}
