using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Senac.Models;

internal class ContaEmpresarial : ContaBancaria
{
    private double _taxaSaque = 5; // Taxa fixa de saque para contas empresariais
    private double _limiteEmprestimo;

    public ContaEmpresarial(int numeroConta, string titular) : base(numeroConta, titular) { this._limiteEmprestimo = 2000; }

    public override bool Sacar(double valor)
    {
        if (valor < 0)
        {
            throw new ArgumentException("O valor do saque deve ser positivo.");
        }

        double taxa = this._taxaSaque;

        this._saldo -= (valor + taxa);
        Console.WriteLine($"\nSaque de {valor:C} realizado com sucesso da conta Nº{this._numeroConta} - Titular: {this._titular}");
        return true;
    }

    public override void Transferir(double valor, ContaBancaria contaDestino)
    {
        if (valor < 0)
        {
            throw new ArgumentException("O valor da transferência deve ser positivo.");
        }
        
        if (Sacar(valor))
        {
            contaDestino.Depositar(valor);
        }
        else
        {
            Console.WriteLine("Transferência falhou: saldo insuficiente.");
        }
    }

    public void Emprestimo(double valor)
    {
        if (valor < 0)
            throw new ArgumentException("Valor do emprestimo deve ser positivo e maior que zero.");

        if (valor <= this._limiteEmprestimo)
        {
            this._limiteEmprestimo -= valor;
            base.Depositar(valor);
            Console.WriteLine($"Saldo atualizado!! Sua conta recebeu um depósito no valor de {valor:C}. Saldo atualizado {this._saldo:C}");
        }
        else
        {
            throw new InvalidOperationException("A conta não possui limite de emprestimo suficiente para a operação.");
        }
    }
}
