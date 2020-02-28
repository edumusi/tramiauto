using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace tramiauto.Common.Helpers
{
    public static class Settings
    {
        private const string _tramite = "tramite";
        private const string _token   = "token";
        private const string _usuario = "usuario";

        private static readonly string _stringDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string Tramite
        {
            get => AppSettings.GetValueOrDefault(_tramite, _stringDefault);
            set => AppSettings.AddOrUpdateValue (_tramite, value);
        }

        public static string Token
        {
            get => AppSettings.GetValueOrDefault(_token, _stringDefault);
            set => AppSettings.AddOrUpdateValue (_token, value);
        }

        public static string Usuario
        {
            get => AppSettings.GetValueOrDefault(_usuario, _stringDefault);
            set => AppSettings.AddOrUpdateValue (_usuario, value);
        }


    }//Class
}//Namespace
