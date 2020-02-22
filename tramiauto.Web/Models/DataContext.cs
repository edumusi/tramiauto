
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tramiauto.Common.Model.DataEntity;
using tramiauto.Web.Models.Entities;
using TipoTramite = tramiauto.Common.Model.DataEntity.TipoTramite;

namespace tramiauto.Web.Models
{
    public class DataContext : IdentityDbContext<UserLogin>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Automotor>       Automotores     { get; set; }
        public DbSet<DatosFiscales>   DatosFiscales   { get; set; }
        public DbSet<StatusTA>        StatusTA        { get; set; }
        public DbSet<TipoTramite>     TipoTramites    { get; set; }
        public DbSet<Tramite>         Tramites        { get; set; }
        public DbSet<TramiteAdjuntos> TramiteAdjuntos { get; set; }        
        public DbSet<Usuario>         Usuarios        { get; set; }
    }//class
}//NameSpace
