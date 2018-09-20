using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using SignUp.Models;
using System.IO;

using Xamarin.Forms;

namespace SignUp.Views
{
	public class EditActivitiesPage : ContentPage
	{
        private ListView _listView;
        private Entry _idEntry;
        private Entry _topicEntry;
        private Entry _descriptionEntry;
        private Button _button;

        Activity _activity = new Activity();
        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditActivitiesPage ()
		{
            this.Title = "Edit Activity";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Activity>().OrderBy(x => x.Topic).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _topicEntry = new Entry();
            _topicEntry.Keyboard = Keyboard.Text;
            _topicEntry.Placeholder = "Topic";
            stackLayout.Children.Add(_topicEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "Topic";
            stackLayout.Children.Add(_descriptionEntry);


            _button = new Button();
            _button.Text = " Update";
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;
        }
        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            Activity activity = new Activity()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                Topic = _topicEntry.Text,
                Description = _descriptionEntry.Text
            };

            db.Update(activity);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _activity = (Activity)e.SelectedItem;
            _idEntry.Text = _activity.Id.ToString();
            _topicEntry.Text = _activity.Topic;
            _descriptionEntry.Text = _activity.Description;
        }
    }
}