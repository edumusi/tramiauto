using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tramiauto.Web.Models.InitDB
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTipoTramitesAsync();
            await CheckUsersAsync();            
        }

        private async Task CheckTipoTramitesAsync()
        {
            if (!_context.TipoTramites.Any())
            {
                _context.TipoTramites.Add(new Entities.TipoTramite { Nombre = "Renovación Trajeta Circulación", Descripcion = "Renovación Trajeta Circulación", Costo = 450, TiempoOperacion = 3 });
                _context.TipoTramites.Add(new Entities.TipoTramite { Nombre = "Cambio de Propetario", Descripcion = "Cambio de Propetario", Costo = 450, TiempoOperacion = 5 });
                _context.TipoTramites.Add(new Entities.TipoTramite { Nombre = "Placas", Descripcion = "Placas", Costo = 450, TiempoOperacion = 5 });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckUsersAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new Entities.User { Email = "ems@convivere.mx", FirstName = "Eduardo", LastName = "Muñoz", CellPhone = "5554364795" });
                await _context.SaveChangesAsync();
            }
        }
    }//class
}//namespace
