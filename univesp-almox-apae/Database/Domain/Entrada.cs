namespace univesp.almox.apae.Database.Domain
{
    public class Entrada
    {
        public int Id { get; set; }
        public int AlmoxarifadoId { get; set; }
        public Almoxarifado Almoxarifado { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int UnidadeArmazenamentoId { get; set; }
        public Unidade UnidadeArmazenamento { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string Fornecedor { get; set; }
        public string DocumentoFornecedor { get; set; }
        public string NumeroDocumentoFiscal { get; set; }
        public string Observacoes { get; set; }
    }
}
