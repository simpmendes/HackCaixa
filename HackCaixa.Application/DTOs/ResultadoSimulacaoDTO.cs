﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCaixa.Application.DTOs
{
    public class ResultadoSimulacaoDTO
    {
        public string Tipo { get; set; }
        public List<ParcelaDTO> Parcelas { get; set; }
    }
}
