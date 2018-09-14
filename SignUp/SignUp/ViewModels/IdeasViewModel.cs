using SignUp.Models;
using SignUp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SignUp.ViewModels
{
    public class IdeasViewModel : INotifyPropertyChanged
    {

        ApiServices _apiServices = new ApiServices();
        private List<Idea> _ideas;

        public string AccessToken { get; set; }

        public List<Idea> Ideas
        {
            get { return _ideas; }
            set
            {
                _ideas = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetIdeasCommand
        {
            get
            {
                return new Command(async () =>
                {
                    
                    Ideas = await _apiServices.GetIdeasAsync(AccessToken);
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
