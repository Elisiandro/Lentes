using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Lentes
{
    public class LenteBase
    {
        public OLHO Olho { get; set; }
        public LENTE TipoLente { get; set; }
        public decimal Rx { get; set; }
        public int Dnp { get; set; }
        public int Tamanho { get; set; }
        public int Diametro { get; set; }
        public decimal IndiceRefracao { get; set; }
        public decimal CurvaBase { get; set; }

        //------------------------------------------------------
        public decimal FatorConversao { get; set; }
        public Receita Receita { get; set; }
        public decimal Co { get; set; }
        public decimal Co2 { get; set; }
        public decimal Ds { get; set; }
        public decimal Ezao { get; set; }

        public decimal Db { get; set; }

        public decimal Ezinho { get; set; }

        public decimal Et { get; set; }
        public decimal Eo { get; set; }

        public LenteBase(DadosBasico dados)
        {
            this.Olho = dados.Olho;
            this.Rx = dados.Rx;
            this.Dnp = dados.Dnp;
            this.Tamanho = dados.Tamanho;
            this.Diametro = dados.Diametro;
            this.IndiceRefracao = dados.IndiceRefracao;
            this.CurvaBase = dados.CurvaBase;

            if (Rx < 0)
                TipoLente = LENTE.NEGATIVA;
            else
                TipoLente = LENTE.POSITIVA;
            
                Calcula_FatorConversao();
        }

        public virtual void Calcula_ND()
        {
            Receita.Dioptria  = Math.Round(this.FatorConversao * this.Rx, 2);
        }

        public void Calcula_CO()
        {
            Co = (Receita.Dioptria) - (CurvaBase);
        }

        public void Calcula_Ds()
        {
            Ds = (Tamanho / 2) - Dnp;
        }

        public void Calcula_Et()
        {
            Et = Math.Round(Ezao + (Db/2),2);
        }

        public void Calcula_Eo()
        {
            Eo = Ezinho + Db;
            if (TipoLente == LENTE.NEGATIVA)
                Eo = Et - Db;
        }

        public virtual void Calcula_CO2()
        {
            
        }

        public virtual void Calcula_DB()
        {
            Db = Math.Round(0.019m * Diametro * Ds * Math.Abs(Receita.Dioptria) * 0.1m, 2);
        }

        public void Calcula_Ezao()
        {
            Ezao = Math.Round((((decimal)Math.Pow((Diametro / 2), 2) * Math.Abs(Receita.Dioptria)) / 1000) + Ezinho, 2);
        }

        public void Calcula_Ezinho()
        {
            decimal e = 2.00m;
            if (Receita.Dioptria <= 0.50m)
                e = 2.00m;//if (nd >= 0.00 && nd <= 0.50)
            else if (Receita.Dioptria >= 0.51m && Receita.Dioptria <= 1.00m)
                e = 1.8m;
            else if (Receita.Dioptria >= 1.01m && Receita.Dioptria <= 2.50m)
                e = 1.6m;
            else if (Receita.Dioptria >= 2.51m && Receita.Dioptria <= 4.50m)
                e = 1.4m;
            else if (Receita.Dioptria >= 4.51m && Receita.Dioptria <= 6.50m)
                e = 1.2m;
            else if (Receita.Dioptria >= 6.51m && Receita.Dioptria <= 8.00m)
                e = 1.0m;
            else if (Receita.Dioptria >= 8.01m)
                e = 0.8m;

            Ezinho = e;
        }

        public void Calcula_FatorConversao()
        {
            FatorConversao = Math.Round((1.530m - 1) / (this.IndiceRefracao - 1), 2);
        }

    }

    public enum OLHO
    {
        Direito = 1,
        Esquerdo = 2,
        AmbosOsOlhos = 3
    }

    public enum LENTE
    {
        NEGATIVA = 1,
        POSITIVA = 2
    }
}
