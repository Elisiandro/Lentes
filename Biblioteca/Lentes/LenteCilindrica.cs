using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Lentes
{

    public class LenteCilindrica : LenteBase
    {
        public decimal ND_esferica { get; set; }
        public decimal ND_cilindrica { get; set; }
        public Receita ND { get; set; }
        public Receita T { get; set; }

        public LenteCilindrica(DadosBasico dados) : base(dados)
        {
        }

        public override void Calcula_ND()
        {
            ND_esferica = Math.Round(this.FatorConversao * this.Receita.Dioptria, 2);
            ND_cilindrica = Math.Round(this.FatorConversao * this.Receita.Cilindro, 2);

            ND = new Receita();
            ND.Dioptria = ND_esferica;
            ND.Cilindro = ND_cilindrica;
            ND.Eixo = this.Receita.Eixo;

            T = new Receita();
            T.Dioptria = (ND.Dioptria) + (ND.Cilindro);
            T.Cilindro = (ND_cilindrica * -1);

            if (this.Receita.Eixo >= 90)
                this.Receita.Eixo -= 90;
            else if (this.Receita.Eixo < 90)
                this.Receita.Eixo += 90;
            
            T.Eixo = this.Receita.Eixo;
        }
    }
}
