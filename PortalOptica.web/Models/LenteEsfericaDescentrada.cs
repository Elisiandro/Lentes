using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalOptica.web.Models
{
    public class LenteEsfericaDescentrada
    {
        [DisplayName("Esferico/RX")]
        public double Rx { get; set; }

        [DisplayName("DNP")]
        public int Dnp { get; set; }

        [DisplayName("Diametro mm")]
        public double Diametro { get; set; }

        [DisplayName("Tamanho da Armação mm")]
        public double TamanhoArmacao { get; set; }
                        
        [DisplayName("(M) Índice de Refração")]
        public double IndiceRefracao { get; set; }
        
        
        [DisplayName("(CB) Curva Base")]
        public double CurvaBase { get; set; }


        //[DisplayName("(FC) Fator de Conversão")]
        //public decimal FatorConversao { get; set; }

        //[DisplayName("(ND) Nova Dioptria")]
        //public decimal NovaDiopdria { get; set; }

        //[DisplayName("(CO) Curva Oposta")]
        //public decimal CurvaOposta { get; set; }

        //[DisplayName("(DS) Descentração")]
        //public decimal Descentracao { get; set; }

        //[DisplayName("(DB) Diferença de Borda")]
        //public decimal DiferencaBorda { get; set; }

        //[DisplayName("(ET) Espessura Total")]
        //public decimal EspessuraTotal { get; set; }

        //[DisplayName("(EO) Espessura Oposta")]
        //public decimal EspessuraOposta { get; set; }

        //[DisplayName("(e) Espessura Minima")]
        //public decimal EspessuraMinima { get; set; }

        //[Required(ErrorMessage = "Informe o Email")]
        //[RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email inválido.")]
        //public string Email { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[MaxLength(2, ErrorMessage = "BloggerName must be 10 characters or less"), MinLength(2)]
    }
}
