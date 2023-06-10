﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Application.DTOs
{
    public class ProdutoDto
    {
        public int CoProduto { get; set; }
        public string? NoProduto { get; set; }
        public decimal PcTaxaJuros { get; set; }
        public short NuMinimoMeses { get; set; }
        public short? NuMaximoMeses { get; set; }
        public decimal VrMinimo { get; set; }
        public decimal? VrMaximo { get; set; }
    }
}
