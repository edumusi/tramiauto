﻿using System.Linq;
using System.Threading.Tasks;
using tramiauto.Web.Helpers;
using tramiauto.Web.Models.Entities;
using tramiauto.Common.Model.DataEntity;
using tramiauto.Common;

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
            await CheckStatusTAAsync();
            await CheckFormasDePagoAsync();
            await CheckRoles();
            await CheckUserAsync( "Eduardo" , "Admin"    , "ems@convivere.mx"            , "350 634 2747", "admin123" , RoleTA.Admin);
            await CheckUserAsync( "Irving"  , "Ejecutivo", "isanchez@everestgestoria.com", "350 634 2747", "eje123"   , RoleTA.Ejecutivo);
            await CheckUserAsync( "Juan"    , "Gestor"   , "eduardo_m81@hotmail.com"     , "350 634 2747", "gestor123", RoleTA.Gestor);
            await CheckUserAsync( "Mauricio", "Usuario"  , "ems@convivere.casa"          , "350 634 2747", "user123"  , RoleTA.Usuario);
            CheckTipoTramitesAsync();
        }


        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync(RoleTA.Admin);
            await _userHelper.CheckRoleAsync(RoleTA.Ejecutivo);
            await _userHelper.CheckRoleAsync(RoleTA.Gestor);
            await _userHelper.CheckRoleAsync(RoleTA.Usuario);
        }

        private void CheckTipoTramitesAsync()
        {
            if (!_context.TipoTramites.Any() && !_context.Requisitos.Any())
            {                
                _context.TipoTramites.Add(new TipoTramite { Orden = 1, Nombre = "Renovación Trajeta Circulación", Descripcion = "Renovación Trajeta Circulación", Costo = 850 , CostoUrgente = 100, CostoAtencionEjecutiva = 200 , TiempoOperacion = 3 });
                _context.TipoTramites.Add(new TipoTramite { Orden = 2, Nombre = "Cambio de Propetario"          , Descripcion = "Cambio de Propetario"          , Costo = 750 , CostoUrgente = 100, CostoAtencionEjecutiva = 200, TiempoOperacion = 5 });
                _context.TipoTramites.Add(new TipoTramite { Orden = 3, Nombre = "Placas"                        , Descripcion = "Placas"                        , Costo = 1000, CostoUrgente = 100, CostoAtencionEjecutiva = 200 , TiempoOperacion = 8 });
                _context.TipoTramites.Add(new TipoTramite { Orden = 0, Nombre = "Seleccione un Tramite"         , Descripcion = "Favor de seleccionar un tramite", Costo = -1, CostoUrgente=-1, CostoAtencionEjecutiva=-1, TiempoOperacion = -1 });
                _context.SaveChanges();

                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 0).FirstOrDefault(), Orden = 0, Nombre = "Seleccione un requisito", Descripcion = "Favor de seleccionar un requisito" });

                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 1).FirstOrDefault(), Orden = 0, Nombre = "Seleccione un requisito", Descripcion = "Favor de seleccionar un requisito" });
                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 1).FirstOrDefault(), Orden = 1, Nombre = "Tenencia"               , Descripcion = "Pago de Tenencia" });
                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 1).FirstOrDefault(), Orden = 2, Nombre = "Verificacion"           , Descripcion = "Pago de Verificacion" });
                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 1).FirstOrDefault(), Orden = 3, Nombre = "Factura"                , Descripcion = "Factura / Carta Factura" });

                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 2).FirstOrDefault(), Orden = 0, Nombre = "Seleccione un requisito", Descripcion = "Favor de seleccionar un requisito" });
                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 2).FirstOrDefault(), Orden = 1, Nombre = "Tenencia"               , Descripcion = "Pago de Tenencia" });
                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 2).FirstOrDefault(), Orden = 2, Nombre = "Verificacion"           , Descripcion = "Verificacion" });

                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 3).FirstOrDefault(), Orden = 0, Nombre = "Seleccione un requisito" , Descripcion = "Favor de seleccionar un requisito" });
                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 3).FirstOrDefault(), Orden = 1, Nombre = "Multas"                  , Descripcion = "Pago de Multas" });
                _context.Requisitos.Add(new Requisito { TipoTramite = _context.TipoTramites.Where(tt => tt.Orden == 3).FirstOrDefault(), Orden = 2, Nombre = "Comprobante de Domicilio", Descripcion = "Comprobante de Domicilioo" });
                _context.SaveChanges();
            }
        }

       

        private async Task CheckStatusTAAsync()
        {
            if (!_context.StatusTA.Any())
            {
                _context.StatusTA.Add(new StatusTA { Nombre = "Registrado", Descripcion = "Tramite registrado y pagado", Orden = 1 });
                _context.StatusTA.Add(new StatusTA { Nombre = "Validado"  , Descripcion = "Validacion de documentación y armado de expediente para imprimir", Orden = 2 });
                _context.StatusTA.Add(new StatusTA { Nombre = "Asignado"  , Descripcion = "Asignado a Gestor para ejecutar el tramite, entrega de expediente y costo del tramite", Orden = 3 });
                _context.StatusTA.Add(new StatusTA { Nombre = "Reasignado", Descripcion = "Reasignado a Gestor para ejecutar el tramite, entrega de expediente y costo del tramite", Orden = 4 });
                _context.StatusTA.Add(new StatusTA { Nombre = "Completo"  , Descripcion = "Tramite realizado en la dependcia gubernamental", Orden = 5 });
                _context.StatusTA.Add(new StatusTA { Nombre = "Entregado" , Descripcion = "Tramite entregado al cliente", Orden = 6 });
                _context.StatusTA.Add(new StatusTA { Nombre = "Evaluado"  , Descripcion = "Cliente califica el servicio", Orden = 7 });
                await _context.SaveChangesAsync();
            }
          
         }

        private async Task CheckFormasDePagoAsync()
        {
            if (!_context.FormasDePago.Any())
            {
                _context.FormasDePago.Add(new FormaDePago { Tipo = MessageCenter.FormaDePagoCard , IdOpenPay = 6, Nombre = "Tarjeta Crédito/Débito", Descripcion = "Pago con tarjeta de crédito ó débito" });
                _context.FormasDePago.Add(new FormaDePago { Tipo = MessageCenter.FormaDePagoBank , IdOpenPay = 7, Nombre = "Banco" , Descripcion = "Pago mediante cuenta bancaria" });
                _context.FormasDePago.Add(new FormaDePago { Tipo = MessageCenter.FormaDePagoStore, IdOpenPay = 8, Nombre = "Tienda", Descripcion = "Pago mediante supermercados, farmacias o tiendas de conveniencia" });
                _context.FormasDePago.Add(new FormaDePago { Tipo = "-"    , IdOpenPay = 0, Nombre = "Seleccione un método de Pago", Descripcion = "-" });
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

                var defaultToken = await _userHelper.GenerateEmailConfirmationTokenAsync(userLogin);
                await _userHelper.ConfirmEmailAsync(userLogin, defaultToken);
            }
        }

        }//class
}//namespace
