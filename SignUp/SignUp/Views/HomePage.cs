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

            // button to edit activities
            button = new Button();
            button.Text = "Edit";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);

            // button to delete activities
            button = new Button();
            button.Text = "Delete";
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new DeleteActivitiesPage());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditActivitiesPage());
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