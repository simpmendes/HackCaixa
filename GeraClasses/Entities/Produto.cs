using System;
using System.Collections.Generic;

namespace GeraClasses.Entities
{
    public partial class Produto
    {
        public int CoProduto { get; set; }
        public string NoProduto { get; set; }
        public decimal PcTaxaJuros { get; set; }
        public short NuMinimoMeses { get; set; }
        public short? NuMaximoMeses { get; set; }
        public decimal VrMinimo { get; set; }
        public decimal? VrMaximo { get; set; }
    }
}
