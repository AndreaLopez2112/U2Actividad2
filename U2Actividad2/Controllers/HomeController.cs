using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U2Actividad2.Models.Entities;
using U2Actividad2.Models.ViewModels;

namespace U2Actividad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string Id)
        {
            PerrosContext context = new PerrosContext();
            List<Raza> razas = new();
            IndexViewModel indexvm = new IndexViewModel();
            if (Id != null) 
            {
                razas = context.Razas.Where(x=> x.Nombre.StartsWith(Id)).Select(x => new Raza
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre
                }).ToList();
            }
            else
            {
                razas = context.Razas.Select(x => new Raza
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre
                }).ToList();
            }
            
            indexvm.raza = razas;
            return View(indexvm);
        }
        public IActionResult Pais()
        {
            PerrosContext context = new PerrosContext();
            PaisViewModel paisvm = new PaisViewModel();
            List<Pais> pais = context.Paises.Select(x => new Pais
            {
                raza = x.Razas.Select(x => new Raza
                {
                    Id = (int)x.Id,
                    Nombre = x.Nombre
                }).ToList(),
                Nombre = x.Nombre ?? "Sin nombre"
            }).ToList();
            paisvm.pais = pais;
            return View(paisvm);
        }
        public IActionResult RazaPerro(string Id)
        {
            PerrosContext context = new PerrosContext();
            RazaPerroViewModel pvm = new RazaPerroViewModel();
            Razas p = context.Razas
                .Include(x => x.Caracteristicasfisicas)
                .Include(x => x.Estadisticasraza)
                .Where(x => Id == x.Nombre).First();
            List<Raza> ListaOtrosP = new();
            Random NumeroRandom = new();
            List<int> PerrosIDRegistrados = context.Razas.Select(x => (int)x.Id).ToList();
            for (int i = 0; i <= 4; i++)
            {
                int NumeroAleatorio = NumeroRandom.Next(0, PerrosIDRegistrados.Count());
                Raza OtroP = context.Razas.Where(x => x.Id == PerrosIDRegistrados[NumeroAleatorio])
                    .Select(x => new Raza
                    {
                        Id = (int)x.Id,
                        Nombre = x.Nombre
                    }).First();
                ListaOtrosP.Add(OtroP);
            }
            pvm.masacota = p;
            pvm.otros = ListaOtrosP;
            return View(pvm);
        }
    }
}
