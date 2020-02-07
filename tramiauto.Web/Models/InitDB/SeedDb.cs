using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models.Entities;
using tramiauto.Common.Model;

namespace tramiauto.Web.Models.InitDB
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
                    {
                        _context = context;
                        _userHelper = userHelper;
                    }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();            
            await CheckTipoTramitesAsync();
            await CheckRoles();
            await CheckUserAsync( "Eduardo", "Muñoz", "ems@convivere.mx", "350 634 2747", "admin123", RoleTA.Admin);
            await CheckUserAsync( "Irving", "Sanchez", "eduardo.munoz.siller@gmail.com", "350 634 2747", "gestor123", RoleTA.Gestor);
            await CheckUserAsync( "Mauricio", "test", "ems@convivere.casa", "350 634 2747", "user123", RoleTA.Usuario);           
        }


        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync(RoleTA.Admin);
            await _userHelper.CheckRoleAsync(RoleTA.Gestor);
            await _userHelper.CheckRoleAsync(RoleTA.Usuario);
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

        private async Task CheckUserAsync(string firstName, string lastName, string email, string phone, string pwd, string role)
        {
            var userLogin = await _userHelper.GetUserByEmailAsync(email);
            if (userLogin == null)
            {
                userLogin = new UserLogin { Email = email, PhoneNumber = phone, UserName = email };
                var user  = new Usuario   { FirstName = firstName, LastName = lastName, UserLogin = userLogin };

                await _userHelper.AddUserAsync(userLogin, pwd);
                await _userHelper.AddUserToRoleAsync(userLogin, role);

                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();
            }
        }

        }//class
}//namespace
