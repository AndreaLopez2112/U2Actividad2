namespace U2Actividad2.Models.ViewModels
{
    public class PaisViewModel
    {
        public List<Pais> pais { get; set; } = null!;
    }

    public class Pais
    {
        public List<Raza> raza { get; set; } = null!;
        public string Nombre { get; set; } = null!;
    }
}
