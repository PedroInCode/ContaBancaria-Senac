using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Senac.Models;

internal class ContaPoupanca : ContaBancaria
{
    private double _taxaRendimento;
    public double TaxaRendimento { get => _taxaRendimento; private set => _taxaRendimento = value; }

    public ContaPoupanca(int numeroConta, string titular, double taxaRendimento) 
        : base(numeroConta, titular)
    {
        this._taxaRendimento = taxaRendimento;
    }

    public void AplicarRendimento()
    {
        if (_taxaRendimento <= 0 || _taxaRendimento > 100)
        {
            throw new ArgumentException("A taxa de rendimento deve ser positiva e menor ou igual a 100.");
        }

        _saldo += (_saldo * (_taxaRendimento / 100));
        Console.WriteLine($"Rendimento aplicado com sucesso. Novo saldo: {_saldo:C}");
        
    }

    public override bool Sacar(double valor)
    {
        if (valor > 0 && valor <= _saldo)
        {
            _saldo -= valor;
            Console.WriteLine($"\nSaque de {valor:C} realizado com sucesso. Novo saldo: {_saldo:C}");
            return true;
        }
        
        throw new ArgumentException("Saldo insuficiente ou valor inválido para saque.");
    }

    public override void ExibirDados()
    {
        base.ExibirDados();
        Console.WriteLine($"Taxa de Rendimento: {_taxaRendimento}%");
    }
}
