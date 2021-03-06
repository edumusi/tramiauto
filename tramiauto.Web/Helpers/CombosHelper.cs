﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using tramiauto.Common.Model.DataEntity;
using tramiauto.Common;
using tramiauto.Web.Models;
using tramiauto.Common.Model.Response;

namespace tramiauto.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;
        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboRoles()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem { Value =  MessageCenter.commonMessageChooseValue, Text = MessageCenter.commonMessageChoose},
                new SelectListItem { Value = "0", Text = RoleTA.Admin     },
                new SelectListItem { Value = "1", Text = RoleTA.Ejecutivo },
                new SelectListItem { Value = "2", Text = RoleTA.Gestor    },
                new SelectListItem { Value = "3", Text = RoleTA.Usuario   }
            };

            return list;
        }

        public IEnumerable<SelectListItem> GetComboRolUser()
        {
            var list = new List<SelectListItem>{ new SelectListItem { Value = "3", Text = RoleTA.Usuario} };

            return list;
        }

        public IEnumerable<SelectListItem> GetComboStatusTA()
        {
            var list = _dataContext.StatusTA.Select(s => new SelectListItem
            {
                Text  = s.Nombre,
                Value = s.Id.ToString()
            }).OrderBy(v => v.Value).ToList();

            list.Insert(0, new SelectListItem{ Text  = MessageCenter.commonMessageChoose,
                                               Value = MessageCenter.commonMessageChooseValue
                                            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboTipoTramites()
        {
            var list = _dataContext.TipoTramites.Select(tt => new SelectListItem
            {
                Text  = tt.Nombre ,
                Value = tt.Id.ToString()
            }).OrderBy(v => v.Value).ToList();

            list.Insert(0, new SelectListItem { Text  = MessageCenter.commonMessageChoose,
                                                Value = MessageCenter.commonMessageChooseValue
                                              });

            return list;
        }

        public List<TipoTramiteResponse> GetTipoTramites()
        {
            var list = _dataContext.TipoTramites.Select(tt=> new TipoTramiteResponse { Id = tt.Id, Costo = tt.Costo, CostoUrgente = tt.CostoUrgente, CostoAtencionEjecutiva=tt.CostoAtencionEjecutiva, Nombre = tt.Nombre, Descripcion= tt.Descripcion, TiempoOperacion=tt.TiempoOperacion }
                                                       ).OrderBy(v => v.Id).ToList();          

            return list;
        }



        public string GetComboRolesByValue(string value)
        {
            var roles = GetComboRoles();

            return roles.Where(r => r.Value == value).Select(r => r.Text).FirstOrDefault();

        }

    }//Class
}//Namespace
