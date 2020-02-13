using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tramiauto.Common.Model
{
    public static class MessageCenter
    {
        public const String labelTextFieldRequired  = "El campo {0} es obligatorio.";
        public const String labelTextFieldMaxLength = "El campo {0} no puede tener más de {1} caractéres.";

        public const String labelTextEmailRequired = "El correo electrónico es obligatorio.";
        public const String labelTextEmailInvalid  = "Correo electrónico invalido. Ej.: micorreo@midominio.com";

        public const String labelLoginFail = "Usuario o Contraseña invalidos, intente de nuevo.";

        public const String labelEmailNotFound = "Usuario no encontrado.";
    }
}
