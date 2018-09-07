using SignUp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SignUp.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices _apiServices = new ApiServices(); 

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        // crerate a command when user press a button
        public ICommand RegisterCommand
        {
            get
            {
                //here we create api service that is responsible to create a user and all the communications. 
                return new Command(async() =>
                {
                   var isSuccess = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);

                    if (isSuccess)
                        Message = "You Sign Up Successfully";
                    else
                        Message = "Something is wrong in your registeration, Retry Later";
                });
            }
        }
    }


}
