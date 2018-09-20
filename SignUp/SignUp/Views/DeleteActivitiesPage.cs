using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SignUp.Models;
using SQLite;
using System.IO;

using Xamarin.Forms;

namespace SignUp.Views
{
	public class DeleteActivitiesPage : ContentPage
	{

        private ListView _listView;
        private Button _button;

        Activity _activity = new Activity();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteActivitiesPage ()
		{
            this.Title = "Edit Activity";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Activity>().OrderBy(x => x.Topic).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _button = new Button();
            _button.Text = " Delete";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }
        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _activity = (Activity)e.SelectedItem;
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Activity>().Delete(x => x.Id == _activity.Id);
            await Navigation.PopAsync();
        }
    }
}