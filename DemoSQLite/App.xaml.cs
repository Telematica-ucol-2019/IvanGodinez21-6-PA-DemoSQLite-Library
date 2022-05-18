using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite
{
    public partial class App : Application
    {
        #region Repository
        private static LibroRepository _LibrosDb;
        public static LibroRepository LibrosDb
        {
            get
            {
                if (_LibrosDb == null)
                {
                    _LibrosDb = new LibroRepository();
                }
                return _LibrosDb;

            }
        }
        private static FechaDePublicacionRepository _FechasDePublicacionDb;
        public static FechaDePublicacionRepository FechasDePublicacionDb
        {
            get
            {
                if (_FechasDePublicacionDb == null)
                {
                    _FechasDePublicacionDb = new FechaDePublicacionRepository();
                }
                return _FechasDePublicacionDb;
            }
        }
        #endregion
        public App()
        {
            InitializeComponent();
            FechasDePublicacionDb.Init();
            LibrosDb.Init();
            MainPage = new NavigationPage(new Inicio());
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
