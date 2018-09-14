using SignUp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SignUp.Views
{
	public class GetAllActivitiesPage : ContentPage
	{
		private ListView _listView;
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public GetAllActivitiesPage()
        {
            this.Title = "Activities";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Activity>().OrderBy(x => x.Topic).ToList();

            // post list view to stack layout
            stackLayout.Children.Add(_listView);

            Content = stackLayout;

        }
	}
}