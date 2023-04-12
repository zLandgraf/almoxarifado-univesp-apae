namespace univesp.almox.apae.Database.Domain
{
    public class Estoque
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public int MedidaId { get; set; }
        public Medida Medida { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorMedio { get; set; }
    }
}
