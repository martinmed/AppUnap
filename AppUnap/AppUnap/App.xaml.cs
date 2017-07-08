
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using Com.OneSignal;

namespace AppUnap
{
	public partial class App : Application
	{
		public App ()
		{
            //si vamos a tener el mismo comportamiento tanto para android como pa ios no tiene sentido tener la condicion de que si es android haga esto, si es ios haz esto mismo.

			InitializeComponent();

            //OneSignal.Current.StartInit("476618db-f2f3-4fb7-940f-530bee13e428").EndInit();
            #if __ANDROID__
            var cantidadCuenta = AccountStore.Create(Forms.Context).FindAccountsForService(Application.Current.ToString()).Count();

            if (cantidadCuenta == 0)
            {
                MainPage = new AppUnap.PLogin();
            }
            else
            {
                MainPage = new AppUnap.PPrincipal();
            }
            #endif
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
