using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace TEST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lumememm_Page : ContentPage
    {
        Slider invis;
        Slider rgb;
        Xamarin.Forms.BoxView head;
        Xamarin.Forms.BoxView body;
        Xamarin.Forms.BoxView legs;
        Xamarin.Forms.Button rastopitj;
        Xamarin.Forms.Button vernutj;
        private bool proverka;
        private bool isButton1Pressed = false;
        private bool isButton2Pressed = false;
        public Lumememm_Page()
        {
            rastopitj = new Xamarin.Forms.Button
            { 
                Text = "Растопить" 
            };
            rastopitj.Clicked += async (sender, e) =>
            {
                if (isButton1Pressed)
                {
                    await DisplayAlert("Alert", "Снеговик уже растаял", "OK");
                }
                else
                {
                    isButton1Pressed = true;
                    await Task.Run(async () =>
                    {
                        await head.FadeTo(0, 1000);
                        await body.FadeTo(0, 1000);
                        await legs.FadeTo(0, 1000);
                    });
                    isButton1Pressed = false;
                }
            };

            vernutj = new Xamarin.Forms.Button 
            { 
                Text = "Вернуть" 
            };
            vernutj.Clicked += async (sender, e) =>
            {
                if (isButton2Pressed)
                {
                    await DisplayAlert("Alert", "Снеговик уже вернулся", "OK");
                }
                else
                {
                    isButton2Pressed = true;
                    await Task.Run(async () =>
                    {
                        await legs.FadeTo(1, 1000);
                        await body.FadeTo(1, 1000);
                        await head.FadeTo(1, 1000);
                    });
                    isButton2Pressed = false;
                }
            };




            invis = new Slider
                {
                    Minimum = 0,
                    Maximum = 10,
                    Value = 5,
                    MinimumTrackColor = Color.White,
                    MaximumTrackColor = Color.Black,
                    ThumbColor = Color.Red,
                    VerticalOptions = LayoutOptions.End
                };
                invis.ValueChanged += (sender, e) =>
                {
                    head.Opacity = e.NewValue;
                    body.Opacity = e.NewValue;
                    legs.Opacity = e.NewValue;
                };
                rgb = new Slider
                {
                    Minimum = 0,
                    Maximum = 1,
                    Value = 0,
                    MinimumTrackColor = Color.White,
                    MaximumTrackColor = Color.Black,
                    ThumbColor = Color.Red,
                    VerticalOptions = LayoutOptions.End
                };
                rgb.ValueChanged += Rgb_ValueChanged;
                head = new Xamarin.Forms.BoxView
                {
                    Color = Color.Gray,
                    CornerRadius = 100,
                    WidthRequest = 50,
                    HeightRequest = 50,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };

                body = new Xamarin.Forms.BoxView
                {
                    Color = Color.Gray,
                    CornerRadius = 100,
                    WidthRequest = 90,
                    HeightRequest = 90,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };

                legs = new Xamarin.Forms.BoxView
                {
                    Color = Color.Gray,
                    CornerRadius = 100,
                    WidthRequest = 150,
                    HeightRequest = 150,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };

                AbsoluteLayout abs = new AbsoluteLayout
                {
                    Children = { head, body, legs, rgb, invis, rastopitj, vernutj }

                };
                AbsoluteLayout.SetLayoutBounds(head, new Rectangle(0.5, 0.3, 200, 200));
                AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(body, new Rectangle(0.5, 0.4, 200, 200));
                AbsoluteLayout.SetLayoutFlags(body, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(legs, new Rectangle(0.5, 0.6, 300, 300));
                AbsoluteLayout.SetLayoutFlags(legs, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(rgb, new Rectangle(0.1, 0.9, 150, 300));
                AbsoluteLayout.SetLayoutFlags(rgb, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(invis, new Rectangle(0.1, 0.8, 150, 300));
                AbsoluteLayout.SetLayoutFlags(invis, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(rastopitj, new Rectangle(0.9, 0.8, 110, 50));
                AbsoluteLayout.SetLayoutFlags(rastopitj, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(vernutj, new Rectangle(0.9, 0.9, 110, 50));
                AbsoluteLayout.SetLayoutFlags(vernutj, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
            }

        Random rnd;
        private void Rgb_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            rnd = new Random();
            head.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            body.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            legs.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

            if (e.NewValue == 0)
            {
                head.Color = Color.Gray; body.Color = Color.Gray; legs.Color = Color.Gray;
            } 
        }
    }
}