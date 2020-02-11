using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Lentes
{
    public class LenteEsferica : LenteBase
    {
        public LenteEsferica(DadosBasico dados) : base(dados)
        {            
        }

        public override void Calcula_ND()
        {
            Receita.Dioptria = Math.Round(this.FatorConversao * this.Rx, 2);
        }
    }
}
