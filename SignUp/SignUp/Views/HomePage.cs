using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SignUp.Views
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
            this.Title = "Select Options";

            // button to add activity
            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            button.Text = "Add Activity";
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            // button to show all activities
            button = new Button();
            button.Text = "Show activities";
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddActivityPage());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllActivitiesPage());
        }
    }
}