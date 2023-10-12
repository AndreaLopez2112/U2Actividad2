using U2Actividad2.Models.Entities;

namespace U2Actividad2.Models.ViewModels
{
    public class RazaPerroViewModel
    {
        public Razas masacota { get; set; } = null!;
        public List<Raza> otros { get; set; } = null!;
    }

}
