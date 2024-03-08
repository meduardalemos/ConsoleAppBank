using ConsoleAppBank.Model;
using ConsoleAppBank.View;


Repositorio repositorio = new();
MenuPrincipal menuPrincipal = new(repositorio);

Titular titular1 = new("Petra Lopes Souza", "12345678910", "Advogada");
Titular titular2 = new("João Pedro Camargo Antunes", "10987654321", "Empresário");
Titular titular3 = new("Carla Silva Ribeiro", "78945612300", "Atriz");

ContaCorrente conta1 = new ContaCorrente(titular1, 1010, "1234-5");
ContaCorrente conta2 = new ContaCorrente(titular2, 2020, "6789-0");
ContaCorrente conta3 = new ContaCorrente(titular3, 3030, "5432-1");
repositorio.SalvarContaCorrente(conta1);
repositorio.SalvarContaCorrente(conta2);
repositorio.SalvarContaCorrente(conta3);


menuPrincipal.ExibeMenuPrincipal();
