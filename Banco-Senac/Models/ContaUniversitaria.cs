using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_Senac.Models;

internal class ContaUniversitaria : ContaBancaria
{
    private double _valorBonus = 1.05; // 5% de bônus no depósito

    public ContaUniversitaria(int numeroConta, string titular) : base(numeroConta, titular) {}

    public override void Depositar(double valor)
    {
        if (valor > 0)
        {
            double Bonus =  (valor * this._valorBonus) - valor; // Adiciona 5% ao valor do depósito
            base.Depositar(valor);
            Console.WriteLine("Um bonus de 5% foi adicionado ao valor de deposito.");
            this._saldo += Bonus;
            
            return;
        }
        throw new ArgumentException("O valor do depósito deve ser positivo.");
    }
}
