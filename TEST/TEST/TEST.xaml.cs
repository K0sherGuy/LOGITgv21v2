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
    public partial class TEST : ContentPage
    {
        BoxView verticalOval;
        private bool _isRedLightOn;
        private bool _isYellowLightOn;
        private bool _isGreenLightOn;
        BoxView redLight;
        BoxView yellowLight;
        BoxView greenLight;
        Label redLabel;
        Label yellowLabel;
        Label greenLabel;
        Button button1;
        Button button2;

        public TEST()
        {

            // Create a StackLayout with Vertical orientation

            AbsoluteLayout absoluteLayout = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            // Create the vertical oval shape for the traffic light
            BoxView verticalOval = new BoxView
            {
                Color = Color.Gray,
                WidthRequest = 150,
                HeightRequest = 400,
                CornerRadius = 40,
                //Margin = new Thickness(0, 0, 0, -200)
            };

            Button button1 = new Button
            {
                Text = "Выключить",
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            Button button2 = new Button
            {
                Text = "Включить",
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            Label redLabel = new Label
            {
                Text = "red",
                TextColor = Color.Red,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Transparent
            };

            Label yellowLabel = new Label
            {
                Text = "yellow",
                TextColor = Color.Yellow,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Transparent
            };

            Label greenLabel = new Label
            {
                Text = "green",
                TextColor = Color.Green,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Transparent
            };

            // Create the red, yellow, and green light circles
            BoxView redLight = CreateLightCircle(Color.Black, new Thickness(0, -20, 0, 25)); // Initialize with black color
            BoxView yellowLight = CreateLightCircle(Color.Black, new Thickness(0, -20, 0, 25));
            BoxView greenLight = CreateLightCircle(Color.Black, new Thickness(0, -20, 0, 25));
            // Add tap gesture recognizer to the red light

            StackLayout buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = { button1, button2 }
            };
            StackLayout stack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = { absoluteLayout, buttons }
            };
            TapGestureRecognizer redLightTap = new TapGestureRecognizer();
            redLightTap.Tapped += (s, e) => ToggleRedLight(redLight, redLabel);
            redLight.GestureRecognizers.Add(redLightTap);

            TapGestureRecognizer yellowLightTap = new TapGestureRecognizer();
            yellowLightTap.Tapped += (s, e) => ToggleYellowLight(yellowLight, yellowLabel);
            yellowLight.GestureRecognizers.Add(yellowLightTap);

            TapGestureRecognizer greenLightTap = new TapGestureRecognizer();
            greenLightTap.Tapped += (s, e) => ToggleGreenLight(greenLight, greenLabel);
            greenLight.GestureRecognizers.Add(greenLightTap);


            // Add click event handler for Button 1
            button1.Clicked += (s, e) => ChangeTrafficLights(redLight, yellowLight, greenLight, redLabel, yellowLabel, greenLabel);
            button2.Clicked += (s, e) => ChangeTrafficLightsToColor(redLight, yellowLight, greenLight, redLabel, yellowLabel, greenLabel);

            AbsoluteLayout.SetLayoutBounds(verticalOval, new Rectangle(0.5, 0.5, 120, 350));
            AbsoluteLayout.SetLayoutFlags(verticalOval, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(verticalOval);

            AbsoluteLayout.SetLayoutBounds(redLight, new Rectangle(0.5, 1, 99, 99));
            AbsoluteLayout.SetLayoutFlags(redLight, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(redLight);

            AbsoluteLayout.SetLayoutBounds(yellowLight, new Rectangle(0.5, 0.6, 99, 99));
            AbsoluteLayout.SetLayoutFlags(yellowLight, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(yellowLight);

            AbsoluteLayout.SetLayoutBounds(greenLight, new Rectangle(0.5, 0.2, 99, 99));
            AbsoluteLayout.SetLayoutFlags(greenLight, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(greenLight);

            AbsoluteLayout.SetLayoutBounds(redLabel, new Rectangle(0.5, 0.95, 110, 110));
            AbsoluteLayout.SetLayoutFlags(redLabel, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(redLabel);

            AbsoluteLayout.SetLayoutBounds(yellowLabel, new Rectangle(0.5, 0.5, 80, 120));
            AbsoluteLayout.SetLayoutFlags(yellowLabel, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(yellowLabel);

            AbsoluteLayout.SetLayoutBounds(greenLabel, new Rectangle(0.5, 0.1, 200, 120));
            AbsoluteLayout.SetLayoutFlags(greenLabel, AbsoluteLayoutFlags.PositionProportional);
            absoluteLayout.Children.Add(greenLabel);

            // Set the StackLayout as the Content of the page
            Content = stack;
        }

        private BoxView CreateLightCircle(Color color, Thickness margin)
        {
            return new BoxView
            {
                Color = color,
                WidthRequest = 80,
                HeightRequest = 120,
                CornerRadius = 100,
                Margin = margin
            };
        }

        private void ToggleRedLight(BoxView redLight, Label redLabel)
        {
            if (_isRedLightOn)
            {
                redLight.Color = Color.Black;
                redLabel.Text = "red";
                redLabel.TextColor = Color.Red;
            }
            else
            {
                redLight.Color = Color.Red;
                redLabel.TextColor = Color.Black;
                redLabel.Text = "STOP";

            }
            _isRedLightOn = !_isRedLightOn;
        }

        private void ToggleYellowLight(BoxView yellowLight, Label yellowLabel)
        {
            if (_isYellowLightOn)
            {
                yellowLight.Color = Color.Black;
                yellowLabel.Text = "yellow";
                yellowLabel.TextColor = Color.Yellow;
            }
            else
            {
                yellowLight.Color = Color.Yellow;
                yellowLabel.Text = "WAIT";
                yellowLabel.TextColor = Color.Black;
            }
            _isYellowLightOn = !_isYellowLightOn;
        }

        private void ToggleGreenLight(BoxView greenLight, Label greenLabel)
        {
            if (_isGreenLightOn)
            {
                greenLight.Color = Color.Black;
                greenLabel.Text = "green";
                greenLabel.TextColor = Color.Green;
            }
            else
            {
                greenLight.Color = Color.Green;
                greenLabel.Text = "GO";
                greenLabel.TextColor = Color.Black;
            }
            _isGreenLightOn = !_isGreenLightOn;
        }

        private void ChangeTrafficLights(BoxView redLight, BoxView yellowLight, BoxView greenLight, Label redLabel, Label yellowLabel, Label greenLabel)
        {
            if (_isGreenLightOn || _isYellowLightOn || _isRedLightOn)
            {
                redLight.Color = Color.Black;
                yellowLight.Color = Color.Black;
                greenLight.Color = Color.Black;
                redLabel.Text = "red";
                redLabel.TextColor = Color.Red;
                yellowLabel.Text = "yellow";
                yellowLabel.TextColor = Color.Yellow;
                greenLabel.Text = "green";
                greenLabel.TextColor = Color.Green;
                _isGreenLightOn = false;
                _isYellowLightOn = false;
                _isRedLightOn = false;

            }
            else if (!_isGreenLightOn || !_isYellowLightOn || !_isRedLightOn)
            {
                DisplayAlert("Не всё включено", "", "OK");
            } 
            else
            {
                DisplayAlert("Не всё включено", "", "OK");
            }


        }

        private void ChangeTrafficLightsToColor(BoxView redLight, BoxView yellowLight, BoxView greenLight, Label redLabel, Label yellowLabel, Label greenLabel)
        {
            if (!_isGreenLightOn || !_isYellowLightOn || !_isRedLightOn)
            {
                redLight.Color = Color.Red;
                yellowLight.Color = Color.Yellow;
                greenLight.Color = Color.Green;
                redLabel.Text = "STOP";
                redLabel.TextColor = Color.Black;
                yellowLabel.Text = "WAIT";
                yellowLabel.TextColor = Color.Black;
                greenLabel.Text = "GO";
                greenLabel.TextColor = Color.Black;
                _isGreenLightOn = true;
                _isYellowLightOn = true;
                _isRedLightOn = true;

            }
            else if (_isGreenLightOn || _isYellowLightOn || _isRedLightOn)
            {
                DisplayAlert("Не всё выключено", "", "OK");
            }
            else
            {
                DisplayAlert("Не всё выключено", "", "OK");
            }


        }
    }
}
