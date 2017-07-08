using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.OneSignal;

namespace AppUnap.Droid
{
	[Activity (Label = "AppUnap", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

            //APP ID en OneSignal: 2dd4372e-7506-4f8f-b440-dde5e2ffe8ef

            OneSignal.Current.StartInit("476618db-f2f3-4fb7-940f-530bee13e428").EndInit();
            base.OnCreate (bundle);
            //SetContentView(Resource.Layout.);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new AppUnap.App ());


			
		}
	}
}

