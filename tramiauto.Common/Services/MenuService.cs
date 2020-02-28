using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tramiauto.Common.Model;
using tramiauto.Common.Model.DataEntity;

namespace tramiauto.Common.Services
{
    public class MenuService : IMenuService
    {
        
        public static List<Menu> GenerateMenuApp( string rol)
        {
          var menu = new List<Menu>
            {
                new Menu{ Icon     = "ic_action_home",
                          PageName = "TramitesPage",
                          Title    = "Tramites"
                        }
                /*,new Menu{ Icon = "ic_action_list_alt",
                           PageName = "ContractsPage",
                           Title = "Contracts"
                         }
               */
                ,new Menu{Icon     = "ic_action_person",
                          PageName = "ModifyUserPage",
                          Title    = "Perfil"
                         }
                ,new Menu{ Icon     = "ic_action_map",
                           PageName = "MapPage",
                           Title    = "Map"
                }
                ,new Menu{ Icon     = "ic_action_exit_to_app",
                           PageName = "LoginPage",
                           Title    = "Cerrar Sesión"
                        }
            };

            return menu;
        }

        public List<Menu> GenerateMenuWebAppRightHeader(bool IsAuthenticated, string name)
        {           
            if (IsAuthenticated)
                return new List<Menu>
                {                
                    new Menu{ Icon       = "fa fa-user",
                              PageName   = "ChangeUser",
                              Controller = "Account",
                              Title      = name
                            },
                    new Menu{ Icon       = "fa fa-sign-out",
                              PageName   = "Logout",
                              Controller = "Account",
                              Title      = "Salir"
                            }
                };
            else
                return new List<Menu>
                {
                    new Menu{ Icon       = "fa fa-sign-in",
                              PageName   = "Login",
                              Controller = "Account",
                              Title      = "Ingresar"
                            }
                };
        }

        public List<Menu> GenerateMenuWebAppLeftHeader(bool IsAuthenticated, string rol)
        {
            if (IsAuthenticated && rol == RoleTA.Admin)
            return new List<Menu>
            {
                new Menu{ Icon       = "fa fa-users",
                          PageName   = "Index",
                          Controller = "Usuarios",
                          Title      = "Usuarios"
                        },
                new Menu{ Icon       = "fa fa-id-card",
                          PageName   = "Index",
                          Controller = "Tramites",
                          Title      = "Tramites"
                        },
                new Menu{ Icon       = "fa fa-address-card",
                          PageName   = "Index",
                          Controller = "TipoTramites",
                          Title      = "Tipo de Tramite"
                        }
            };            

            if (IsAuthenticated && rol == RoleTA.Ejecutivo)
                return new List<Menu>
                {
                    new Menu{ Icon     = "fa fa-id-card",
                              PageName = "Index",
                              Controller = "Tramites",
                              Title    = "Validar Tramites"
                            }
                };

            if (IsAuthenticated && rol == RoleTA.Gestor)
                return new List<Menu>
                {
                    new Menu{ Icon       = "fa fa-id-card",
                              PageName   = "Index",
                              Controller = "Tramites",
                              Title      = "Tramites asignados"
                            }
                };

            if (IsAuthenticated && rol == RoleTA.Usuario)
                return new List<Menu>
                {
                    new Menu{ Icon       = "fa fa-id-card",
                              PageName   = "Index",
                              Controller = "Tramites",
                              Title      = "Mis Tramites"
                            }
                };

            return new List<Menu>();
        }

    }//Class

}//NameSpace
