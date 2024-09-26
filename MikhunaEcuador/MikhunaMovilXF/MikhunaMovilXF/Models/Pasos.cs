namespace MikhunaMovilXF.Models
{
    public partial class Pasos
    {
        public int PasosID { get; set; }

        public string Paso { get; set; }
        public int numeroPaso { get; set; }

        public int RecetaID { get; set; }

        public Recetas Recetas { get; set; }
    }
}
