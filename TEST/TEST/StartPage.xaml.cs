using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { new Entry_Page(), new Timer_Page(), new BoxView_Page(), new Valgusfoor_Page(), new DateTime_Page(), new StepperSlider_Page(), new RGB(), new Frame_Page(), new Picture_Page(), new Image_Page(), new Lumememm_Page(), new PopUp()};
        List<string> tekstid = new List<string> { "Ava Entry leht", "Ava Timer leht", "Ava Box leht", "Ava Valgusfoor leht", "Ava Date leht", "Ava Stepper leht", "Ava RGB leht", "Ava Frame leht", "Ava Picture leht", "Ava Image leht", "Ava Lumememm leht", "Ava PopUp leht"};
        public StartPage()
        {
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.YellowGreen
            };

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekstid[i],
                    TabIndex = i,
                    BackgroundColor = Color.Green,
                    TextColor= Color.Wheat
                };
                st.Children.Add(button);
                button.Clicked += Navigation_function;
            }
            Content = st;
        }


        private async void Navigation_function(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }

    }
}