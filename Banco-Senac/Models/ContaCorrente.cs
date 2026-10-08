using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Senac.Models;

internal class ContaCorrente : ContaBancaria
{
    private double _limiteChequeEspecial;

    public double LimiteChequeEspecial { get => _limiteChequeEspecial; private set => _limiteChequeEspecial = value; }

    public ContaCorrente(int numeroconta, string titular, int limiteChequeEspecial) 
        : base(numeroconta, titular)
    {
        this.LimiteChequeEspecial = limiteChequeEspecial;
    }


    public override bool Sacar(double valor)
    {
        if (valor > 0 && valor <= _saldo + _limiteChequeEspecial)
        {
            _saldo -= valor;
            Console.WriteLine($"Saque de {valor:C} realizado com sucesso. Novo saldo: {_saldo:C}");
            return true;
        }
        
        throw new ArgumentException("Saldo insuficiente ou valor inválido para saque.");
    }

    public override void ExibirDados()
    {
        base.ExibirDados();
        Console.WriteLine($"Limite do Cheque Especial: {_limiteChequeEspecial:C}");
        Console.WriteLine("--------------------------------------------\n\n");
    }
}
