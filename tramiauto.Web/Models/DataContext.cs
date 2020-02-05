
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tramiauto.Web.Models.Entities;

namespace tramiauto.Web.Models
{
    public class DataContext : IdentityDbContext<UserLogin>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Automotor>       Automotores     { get; set; }
        public DbSet<DatosFiscales>   DatosFiscales   { get; set; }
        public DbSet<TipoTramite>     TipoTramites    { get; set; }
        public DbSet<Tramite>         Tramites        { get; set; }
        public DbSet<TramiteAdjuntos> TramiteAdjuntos { get; set; }        
        public DbSet<Usuario>         Usuarios        { get; set; }
    }//class
}//NameSpace
