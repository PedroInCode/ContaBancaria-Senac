using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Senac.Models;

internal abstract class ContaBancaria
{
    protected int _numeroConta;
    protected string _titular;
    protected double _saldo;

    public int NumeroConta { get => _numeroConta; protected set => _numeroConta = value; }
    public string Titular { get => _titular; protected set => _titular = value; }

    public ContaBancaria(int numeroConta, string titular)
    {
        this._numeroConta = numeroConta;
        this._titular = titular;
        this._saldo = 0;
    }


    public virtual void Depositar(double valor)
    {
        if (valor > 0)
        {
            this._saldo += valor;
            Console.WriteLine($"\nDepósito de {valor} realizado com sucesso para a conta: N°{this._numeroConta} - Titular: {this._titular}");
            return;
        }
        
        throw new ArgumentException("O valor do depósito deve ser positivo.");
    }

    public virtual bool Sacar(double valor)
    {
        if (valor > 0 && valor <= this._saldo)
        {
            this._saldo -= valor;
            Console.WriteLine($"\nSaque de {valor:C} realizado com sucesso da conta Nº{this._numeroConta} - Titular: {this._titular}");
            return true;
        }
        
        throw new ArgumentException("Saldo insuficiente ou valor inválido para saque.");
    }

    public virtual void Transferir(double valor, ContaBancaria contaDestino)
    {
        if (valor > 0 && valor <= this._saldo)
        {
            this._saldo -= valor;
            contaDestino.Depositar(valor);
            Console.WriteLine($"Transferência de {valor:C} realizada com sucesso para a conta {contaDestino.NumeroConta}. Novo saldo: {this._saldo:C}");
            return;
        }
        
        throw new ArgumentException("Saldo insuficiente ou valor inválido para transferência.");
    }

    public virtual void ExibirDados()
    {
        Console.WriteLine($"\nNúmero da Conta: {this._numeroConta}");
        Console.WriteLine($"Titular: {this._titular}");
        Console.WriteLine($"Saldo: {this._saldo:C}");
    }
}
