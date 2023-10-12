namespace U2Actividad2.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Raza> raza { get; set; } = null!;
   
    }

    public class Raza
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
