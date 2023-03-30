using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUp : ContentPage
    {
        public List<decimal> numbers = new List<decimal>();
        public PopUp()
        {
            for (decimal i = 1; i <= 9; i++)
            {
                numbers.Add(i);
            }
            Button alertButton = new Button
            {
                Text = "Teade",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertButton.Clicked += AlertButton_Clicked;
            Button alertYesNoButton = new Button
            {
                Text = "Jah voi ei",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertYesNoButton.Clicked += AlertYesNoButton_Clicked;
            Button alertListButton = new Button
            {
                Text = "Valik",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertListButton.Clicked += AlertListButton_Clicked;
            Button alertQuestButton = new Button
            {
                Text = "Kusimus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertQuestButton.Clicked += AlertQuestButton_Clicked;
            Button alertMultipleButton = new Button
            {
                Text = "Multiple table",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertMultipleButton.Clicked += AlertMultipleButton_Clicked;
            Content = new StackLayout { Children = { alertButton, alertYesNoButton, alertListButton, alertQuestButton, alertMultipleButton } }; 
            
        }

        private async void AlertMultipleButton_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();

            var mulResult = await DisplayPromptAsync("Question", "Choose the range from 1 to 9", placeholder: "1,2,3,4,5,6,7,8,9", maxLength: 1, keyboard: Keyboard.Numeric);
            int mulResultDec = Convert.ToInt32(mulResult);
            await DisplayAlert("Info", "Your choice is: " + (mulResultDec), "Start");
            for (int i = 1; i < 5; i++)
            {
                int randomNumber = rnd.Next(1, 10);
                string a = Convert.ToString(randomNumber);
                string b = Convert.ToString(mulResultDec);
                string abs = await DisplayPromptAsync("How much is", a + "*" + b, maxLength: 2, keyboard: Keyboard.Numeric);
                int c = randomNumber * mulResultDec;
                int absv2 = Convert.ToInt32(abs);
                if (absv2 == c)
                {
                    await DisplayAlert("Info", "You are right", "Continue");
                }
                else
                {
                    await DisplayAlert("Info", "You are wrong", "Continue");
                }
            }


        }

        private async void AlertQuestButton_Clicked(object sender, EventArgs e)
        {
            string result1 = await DisplayPromptAsync("Kusimus", "Kuidas laheb?", placeholder: "Tore!");
            string result2 = await DisplayPromptAsync("Kusimus", "Millega vordub 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
        }

        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Mida teha?", "Loobu", "Kustutada", "Tantsida", "Laulda", "Joonestada");
        }

        private async void AlertYesNoButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Kinnistus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");
            await DisplayAlert("Teade", "Teie valik on: " + (result ? "E" : "Ei"), "OK");
        }

        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Teade", "Teil on uss teade", "OK");
        }
    }
}