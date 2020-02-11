using Biblioteca.Lentes;
using System;

namespace ConsoleTeste
{
    class Program
    {   
        static int dnp = 0;
        static int tamanho = 0;
        static int diametro = 0;
        static decimal indiceRefracao = 0;
        static decimal curvaBase = 0;

        static Receita receita = new Receita();

        static void Main(string[] args)
        {
            Exe1();
            Exe2();
            Exe3();
            Exe4();

            Exe5_Cil();

            Console.WriteLine("Digite os dados:");

            Console.WriteLine($"Rx {receita}");
            Console.WriteLine($"DNP {dnp}");
            Console.WriteLine($"TA {tamanho}");
            Console.WriteLine($"Diametro {diametro}");
            Console.WriteLine($"CB {curvaBase}");
            Console.WriteLine($"Indice Refração {indiceRefracao}");
            Console.WriteLine($"----------------------------------");
            
            DadosBasico dados = new DadosBasico();
            dados.Rx = receita.Dioptria;
            dados.Dnp = dnp;
            dados.Tamanho = tamanho;
            dados.Diametro = diametro;
            dados.IndiceRefracao = indiceRefracao;
            dados.CurvaBase = curvaBase;


            //LenteEsferica lente = new LenteEsferica(dados);
            LenteCilindrica lente = new LenteCilindrica(dados);

            lente.Calcula_ND();
            lente.Calcula_CO();
            lente.Calcula_Ezinho();
            lente.Calcula_Ezao();
            lente.Calcula_Ds();
            lente.Calcula_DB();
            lente.Calcula_Et();
            lente.Calcula_Eo();
                       
            Console.WriteLine($"Fator de Conversao {lente.FatorConversao}");
            Console.WriteLine($"Nova Diptria {lente.Receita.Dioptria}");

            Console.WriteLine($"Curva Oposta {lente.Co}");
            Console.WriteLine($"Ezinho {lente.Ezinho}");
            Console.WriteLine($"Ezao {lente.Ezao}");
            Console.WriteLine($"Dessentração {lente.Ds}");
            Console.WriteLine($"Diferença de Borda {lente.Db}");
            Console.WriteLine($"Espessura Total {lente.Et}");
            Console.WriteLine($"Espessura Oposta {lente.Eo}");

            Console.WriteLine("Final");

            Console.ReadKey();
        }

        public static void Exe1()
        {
            receita.Dioptria = -3.50m;
            dnp = 32;
            tamanho = 68;
            diametro = 70;
            indiceRefracao = 1.499m;
            curvaBase = 5.00m;
        }

        public static void Exe2()
        {
            receita.Dioptria = +6.00m;
            dnp = 31;
            tamanho = 70;
            diametro = 60;
            indiceRefracao = 1.499m;
            curvaBase = 8.50m;
        }

        public static void Exe3()
        {
            receita.Dioptria = -2.50m;
            dnp = 33;
            tamanho = 70;
            diametro = 60;
            indiceRefracao = 1.499m;
            curvaBase = 5.50m;
        }

        public static void Exe4()
        {
            receita.Dioptria = 1.00m;
            dnp = 34;
            tamanho = 70;
            diametro = 60;
            indiceRefracao = 1.499m;
            curvaBase = 5.00m;
        }

        public static void Exe5_Cil()
        {
            receita.Dioptria = -3.00m;
            receita.Cilindro = 0.75m;
            receita.Eixo = 40;

            dnp = 30;
            tamanho = 70;
            diametro = 60;
            indiceRefracao = 1.499m;
            curvaBase = 4.00m;
        }
    }
}
