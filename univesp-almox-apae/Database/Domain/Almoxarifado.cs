namespace univesp.almox.apae.Database.Domain
{
    public class Almoxarifado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Material> Materiais { get; set; }
    }
}
