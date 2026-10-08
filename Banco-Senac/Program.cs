using Banco_Senac.Models;

namespace Banco_Senac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== TESTES BANCO SENAC ==========\n");


            // TESTE 1
            Console.WriteLine("TESTE 1 - Depósito em Conta Universitária");

            ContaUniversitaria contaUniversitaria =
                new(111, "Luck XO");

            contaUniversitaria.Depositar(100);
            contaUniversitaria.ExibirDados();

            Console.WriteLine("----------------------------------------");


            // TESTE 2
            Console.WriteLine("TESTE 2 - Saque em Conta Empresarial");

            ContaEmpresarial contaEmpresarial =
                new(222, "Claudio");

            contaEmpresarial.Depositar(1000);
            contaEmpresarial.Sacar(100);
            contaEmpresarial.ExibirDados();

            Console.WriteLine("----------------------------------------");


            // TESTE 3
            Console.WriteLine("TESTE 3 - Transferência");

            ContaUniversitaria contaDestino =
                new(333, "Maria");

            contaEmpresarial.Transferir(200, contaDestino);

            Console.WriteLine("\nConta de origem:");
            contaEmpresarial.ExibirDados();

            Console.WriteLine("\nConta de destino:");
            contaDestino.ExibirDados();

            Console.WriteLine("----------------------------------------");


            // TESTE 4
            Console.WriteLine("TESTE 4 - Empréstimo");

            ContaEmpresarial contaEmprestimo =
                new(444, "Empresa Senac");

            contaEmprestimo.Emprestimo(1000);
            contaEmprestimo.ExibirDados();

            Console.WriteLine("----------------------------------------");


            // TESTE 5
            Console.WriteLine("TESTE 5 - Empréstimo acima do limite");

            try
            {
                contaEmprestimo.Emprestimo(1500);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("----------------------------------------");


            // TESTE 6
            Console.WriteLine("TESTE 6 - Depósito com valor inválido");

            try
            {
                contaUniversitaria.Depositar(-100);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("----------------------------------------");


            // TESTE 7
            Console.WriteLine("TESTE 7 - Saque com valor inválido");

            try
            {
                contaUniversitaria.Sacar(-50);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }


            Console.WriteLine("\n========== FIM DOS TESTES ==========");
        }
    }
}