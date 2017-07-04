using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppUnap
{
	public class PPrincipal : ContentPage
	{
		public PPrincipal ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "bienvenido a pagina principal" }
				}
			};
		}
	}
}