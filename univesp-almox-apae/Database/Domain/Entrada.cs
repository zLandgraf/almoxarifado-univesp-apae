namespace univesp.almox.apae.Database.Domain
{
    public class Entrada
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string DocumentoFornecedor { get; set; }
        public string Fornecedor { get; set; }
        public List<ItemEntrada> ItemEntrada { get; set; }
    }
}
