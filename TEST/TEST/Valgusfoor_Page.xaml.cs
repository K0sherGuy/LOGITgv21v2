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
    public partial class Valgusfoor_Page : ContentPage
    {
        private BoxView RedBox;
        private BoxView YellowBox;
        private BoxView GreenBox;
        private Label RedBoxLabel;
        private Label YellowBoxLabel;
        private Label GreenBoxLabel;

        Action<Label> RedBoxTapped = (label) =>
        {
            if (label.Text == "Turn on traffic light")
            {
                label.Text = "Stop";
            }
            else
            {
                label.Text = "Turn on traffic light";
            }
        };

        Action<Label> YellowBoxTapped = (label) =>
        {
            if (label.Text == "Turn on traffic light")
            {
                label.Text = "Wait";
            }
            else
            {
                label.Text = "Turn on traffic light";
            }
        };

        Action<Label> GreenBoxTapped = (label) =>
        {
            if (label.Text == "Turn on traffic light")
            {
                label.Text = "Go";
            }
            else
            {
                label.Text = "Turn on traffic light";
            }
        };

        public Valgusfoor_Page()
        {
            InitializeComponent();

            RedBox = new BoxView
            {
                Color = Color.Gray,
                HeightRequest = 100,
                WidthRequest = 50
            };
            YellowBox = new BoxView
            {
                Color = Color.Gray,
                HeightRequest = 100,
                WidthRequest = 50
            };
            GreenBox = new BoxView
            {
                Color = Color.Gray,
                HeightRequest = 100,
                WidthRequest = 50
            };
            RedBoxLabel = new Label
            {
                Text = "Red",
                HorizontalTextAlignment = TextAlignment.Center
            };
            YellowBoxLabel = new Label
            {
                Text = "Yellow",
                HorizontalTextAlignment = TextAlignment.Center
            };
            GreenBoxLabel = new Label
            {
                Text = "Green",
                HorizontalTextAlignment = TextAlignment.Center
            };

            RedBox.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => RedBoxTapped(RedBoxLabel))
            });
            YellowBox.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => YellowBoxTapped(YellowBoxLabel))
            });
            GreenBox.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => GreenBoxTapped(GreenBoxLabel))
            });

            var layout = new StackLayout
            {
                Children = { RedBoxLabel, RedBox, YellowBoxLabel, YellowBox, GreenBoxLabel, GreenBox }
            };
            var button1 = new Button
            {
                Text = "Sisse"
            };
            var button2 = new Button
            {
                Text = "Valja"
            };
            layout.Children.Add(button1);
            layout.Children.Add(button2);
            Content = layout;

            button1.Clicked += (sender, args) =>
            {
                RedBox.Color = Color.Red;
                YellowBox.Color = Color.Yellow;
                GreenBox.Color = Color.Green;
                RedBoxLabel.Text = "Turn on traffic light";
                YellowBoxLabel.Text = "Turn on traffic light";
                GreenBoxLabel.Text = "Turn on traffic light";
            };
            button2.Clicked += (sender, args) =>
            {
                RedBox.Color = Color.Gray;
                YellowBox.Color = Color.Gray;
                GreenBox.Color = Color.Gray;
                RedBoxLabel.Text = "Red";
                YellowBoxLabel.Text = "Yellow";
                GreenBoxLabel.Text = "Green";
            };
        }
    
}
}