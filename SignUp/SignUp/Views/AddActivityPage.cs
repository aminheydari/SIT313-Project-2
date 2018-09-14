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
    public class AddActivityPage : ContentPage
    {

        private Entry _topicEntry;
        private Entry _descriptionEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");


        public AddActivityPage()
        {
            this.Title = "Add Activity";

            StackLayout stackLayout = new StackLayout();

            _topicEntry = new Entry();
            _topicEntry.Keyboard = Keyboard.Text;
            _topicEntry.Placeholder = "Topic";
            stackLayout.Children.Add(_topicEntry);

            _descriptionEntry = new Entry();
            _descriptionEntry.Keyboard = Keyboard.Text;
            _descriptionEntry.Placeholder = "Description";
            stackLayout.Children.Add(_descriptionEntry);

            _saveButton = new Button();
            _saveButton.Text = "Add Activity";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;

        }
        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Activity>();

            var maxPk = db.Table<Activity>().OrderByDescending(c => c.Id).FirstOrDefault();

            Activity activity = new Activity()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Topic = _topicEntry.Text,
                Description = _descriptionEntry.Text
            };

            // insert activity into database table

            db.Insert(activity);

            await DisplayAlert(null, activity.Topic + " Saved", "Ok");
            // after click on ok button back to home page
            await Navigation.PopAsync();
        }
    }
}