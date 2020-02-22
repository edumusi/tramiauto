using System.Linq;
using System.Threading.Tasks;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models.Entities;
using tramiauto.Common.Model.DataEntity;

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
            await CheckStatusTAAsync();
            await CheckRoles();
            await CheckUserAsync( "Eduardo", "Admin", "ems@convivere.mx", "350 634 2747", "admin123", RoleTA.Admin);
            await CheckUserAsync( "Irving", "Ejecutivo", "isanchez@everestgestoria.com", "350 634 2747", "eje123", RoleTA.Ejecutivo);
            await CheckUserAsync("Juan", "Gestor", "eduardo_m81@hotmail.com", "350 634 2747", "gestor123", RoleTA.Gestor);
            await CheckUserAsync( "Mauricio", "Usuario", "ems@convivere.casa", "350 634 2747", "user123", RoleTA.Usuario);           
        }


        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync(RoleTA.Admin);
            await _userHelper.CheckRoleAsync(RoleTA.Ejecutivo);
            await _userHelper.CheckRoleAsync(RoleTA.Gestor);
            await _userHelper.CheckRoleAsync(RoleTA.Usuario);
        }

        private async Task CheckTipoTramitesAsync()
        {
            if (!_context.TipoTramites.Any())
            {
                _context.TipoTramites.Add(new TipoTramite { Nombre = "Renovación Trajeta Circulación", Descripcion = "Renovación Trajeta Circulación", Costo = 450, TiempoOperacion = 3 });
                _context.TipoTramites.Add(new TipoTramite { Nombre = "Cambio de Propetario", Descripcion = "Cambio de Propetario", Costo = 450, TiempoOperacion = 5 });
                _context.TipoTramites.Add(new TipoTramite { Nombre = "Placas", Descripcion = "Placas", Costo = 450, TiempoOperacion = 5 });
                await _context.SaveChangesAsync();
            }
        }

         private async Task CheckStatusTAAsync()
        {
            if (!_context.StatusTA.Any())
            {
                _context.StatusTA.Add(new StatusTA { Nombre = "Registrado", Descripcion = "Tramite registrado y pagado" });
                _context.StatusTA.Add(new StatusTA { Nombre = "Validado"  , Descripcion = "Validacion de documentación y armado de expediente para imprimir" });
                _context.StatusTA.Add(new StatusTA { Nombre = "Asignado"  , Descripcion = "Asignado a Gestor para ejecutar el tramite, entrega de expediente y costo del tramite" });
                _context.StatusTA.Add(new StatusTA { Nombre = "Reasignado", Descripcion = "Reasignado a Gestor para ejecutar el tramite, entrega de expediente y costo del tramite" });
                _context.StatusTA.Add(new StatusTA { Nombre = "Completo"  , Descripcion = "Tramite realizado en la dependcia gubernamental" });
                _context.StatusTA.Add(new StatusTA { Nombre = "Entregado" , Descripcion = "Tramite entregado al cliente" });
                _context.StatusTA.Add(new StatusTA { Nombre = "Evaluado"  , Descripcion = "Cliente califica el servicio" });
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
