namespace univesp.almox.apae.Database.Domain
{
    public class Material
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorMedio { get; set; }
        public int AlmoxarifadoId { get; set; }
        public Almoxarifado Almoxarifado { get; set; }
        public int UnidadeArmazenamentoId { get; set; }
        public Unidade UnidadeArmazenamento { get; set; }
        public List<Entrada> Entradas { get; set; }
        public List<Saida> Saidas { get; set; }
    }
}
