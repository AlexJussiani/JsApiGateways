using System;

namespace Js.ApiGateways.Models
{
    #region ContaItems
    public class ContaItemDTO
    {
        public Guid ContaId { get; set; }
        public Guid ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
    #endregion
}
