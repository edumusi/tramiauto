using System;
using System.Collections.Generic;
using System.Text;
using tramiauto.Common.Model.Request;

namespace tramiauto.App.ViewModels.VM
{
    public class LoginVM
    {
        private LoginTARequest _loginForm;
        
        public LoginTARequest LoginForm
        {
            get { return _loginForm;  }
            set { _loginForm = value; }
        }
        public LoginVM()
        {
            _loginForm = new LoginTARequest();
        }
    }
}
