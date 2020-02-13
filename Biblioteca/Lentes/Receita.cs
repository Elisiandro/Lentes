using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Lentes
{
    public class Receita
    {
        public decimal Dioptria { get; set; }
        public decimal Cilindro { get; set; }
        public int Eixo { get; set; }


        public override string ToString()
        {
            string retorno = Dioptria > 0 ? $"+{Dioptria}" : $"{Dioptria}";
            retorno += Cilindro > 0 ? $" +{Cilindro}" : $" {Cilindro}";
            retorno += $"x {Eixo}º";
            return retorno;
        }
    }


}
