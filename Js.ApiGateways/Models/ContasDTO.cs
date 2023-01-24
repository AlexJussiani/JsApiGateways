using System;
using System.Collections.Generic;

namespace Js.ApiGateways.Models
{
    public class ContasDTO
    {
        #region Conta
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public int StatusConta { get; set; }
        public int tipoConta { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime dataCompra { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataVencimento { get; set; }
        public List<ContaItemDTO> ContaItems { get; set; }
        #endregion


        #region Cliente
        public string Nome { get; set; }
        public Guid ClienteId { get; set; }
        #endregion
    }
}
