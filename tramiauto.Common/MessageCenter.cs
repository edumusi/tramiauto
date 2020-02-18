using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tramiauto.Common
{
    public static class MessageCenter
    {
        /*******URL CONSTANT********/
        public const String URL     = "https://tramiauto.azurewebsites.net/";
        public const String URL_API = "https://tramiauto.azurewebsites.net/api/";
        /*******URL CONSTANT********/

        /*******WEB APP Messages********/
        public const String webAppTextFieldRequired  = "El campo {0} es obligatorio.";
        public const String webAppTextFieldMaxLength = "El campo {0} no puede tener más de {1} caractéres.";

        public const String webAppTextEmailRequired = "El correo electrónico es obligatorio.";
        public const String webAppTextEmailInvalid  = "Correo electrónico invalido. Ej.: micorreo@midominio.com";

        public const String webApplabelLoginFail    = "Usuario o Contraseña invalidos. Intente de nuevo.";

        public const String webApplabelEmailNotFound = "Usuario no encontrado.";
        /*******WEB APP Messages********/

        /*******APP Messages********/
        public const String appTextEmailFieldRequired = "El correo electrónico es obligatorio, para ingresar a la app.";
        public const String appTextPassFieldRequired  = "La contraseña es obligatoria, para ingresar a la app.";

        public const String appLabelError   = "Error";        
        public const String appLabelAceptar = "Aceptar";

        public const String appLabelErrorConnect = "Error de Conectividad";
        public const String appLabelErrorNoInter = "Tramiuto para su correcto funcionamiento necesita de acceso a internet, verifique su conexión.";
        public const String appLabelErrorNoUserToken = "Hubo un problema con elu usuario y su acceso.";


        /*******APP Messages********/
    }
}
