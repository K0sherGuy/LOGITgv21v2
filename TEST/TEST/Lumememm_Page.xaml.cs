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
using System.Security.Cryptography;
using System.Runtime.InteropServices.ComTypes;
using Xamarin.Forms.PlatformConfiguration;
using System.Linq.Expressions;

namespace TEST
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lumememm_Page : ContentPage
    {
        private AbsoluteLayout abs;
        bool HatResult = false;
        Label iks;
        Label igrik;
        Slider invis;
        Slider rgb;
        Xamarin.Forms.BoxView drag;
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
            
            drag = new Xamarin.Forms.BoxView
            {
                Color = Color.Black,
                WidthRequest = 40,
                HeightRequest = 70,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            var dragGestureRecognizer = new PanGestureRecognizer();
            dragGestureRecognizer.PanUpdated += OnDragBoxPanUpdated;
            drag.GestureRecognizers.Add(dragGestureRecognizer);



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
                else if (HatResult && isButton1Pressed)
                {
                    await DisplayAlert("Alert", "Снеговик уже растаял", "OK");
                }
                else if (HatResult)
                {
                    isButton1Pressed = true;
                    await Task.Run(async () =>
                    {
                        await drag.FadeTo(0, 1000);
                        await head.FadeTo(0, 1000);
                        await body.FadeTo(0, 1000);
                        await legs.FadeTo(0, 1000);
                    });
                    isButton1Pressed = false;
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
                else if (HatResult && isButton2Pressed)
                {
                    await DisplayAlert("Alert", "Снеговик уже вернулся", "OK");
                }
                else if (HatResult)
                {
                    isButton2Pressed = true;
                    await Task.Run(async () =>
                    {
                        await legs.FadeTo(1, 1000);
                        await body.FadeTo(1, 1000);
                        await head.FadeTo(1, 1000);
                        await drag.FadeTo(1, 1000);
                    });
                    isButton2Pressed = false;
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
                    Maximum = 1,
                    Value = 5,
                    MinimumTrackColor = Color.White,
                    MaximumTrackColor = Color.Black,
                    ThumbColor = Color.Red,
                    VerticalOptions = LayoutOptions.End
                };
                invis.ValueChanged += (sender, e) =>
                {
                    if(HatResult)
                    {
                        drag.Opacity = e.NewValue;
                        head.Opacity = e.NewValue;
                        body.Opacity = e.NewValue;
                        legs.Opacity = e.NewValue;
                    } 
                    else
                    {
                        head.Opacity = e.NewValue;
                        body.Opacity = e.NewValue;
                        legs.Opacity = e.NewValue;
                    }
                    
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

                var dragBoxPosition = AbsoluteLayout.GetLayoutBounds(drag);
                iks = new Label
                {
                    Text = Convert.ToString(dragBoxPosition.Y),
                    TextColor = Color.Black,
                    BackgroundColor = Color.Transparent
                };

                igrik = new Label
                {
                    Text = Convert.ToString(dragBoxPosition.Y),
                    TextColor = Color.Black,
                    BackgroundColor = Color.Transparent
                };

            AbsoluteLayout abs = new AbsoluteLayout
                {
                    Children = { head, body, legs, rgb, invis, rastopitj, vernutj, drag, iks, igrik }

                };
                AbsoluteLayout.SetLayoutBounds(head, new Rectangle(0.5, 0.3, 200, 200));
                AbsoluteLayout.SetLayoutFlags(head, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(drag, new Rectangle(0.1, 0.7, 40, 70));
                AbsoluteLayout.SetLayoutFlags(drag, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(body, new Rectangle(0.5, 0.4, 200, 200));
                AbsoluteLayout.SetLayoutFlags(body, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(legs, new Rectangle(0.5, 0.6, 300, 300));
                AbsoluteLayout.SetLayoutFlags(legs, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(rgb, new Rectangle(0.1, 0.9, 150, 300));
                AbsoluteLayout.SetLayoutFlags(rgb, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(invis, new Rectangle(0.1, 0.8, 150, 300));
                AbsoluteLayout.SetLayoutFlags(invis, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(rastopitj, new Rectangle(0.9, 0.89, 110, 40));
                AbsoluteLayout.SetLayoutFlags(rastopitj, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(vernutj, new Rectangle(0.9, 0.95, 110, 40));
                AbsoluteLayout.SetLayoutFlags(vernutj, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(iks, new Rectangle(0.1, 0.1, 200, 200));
                AbsoluteLayout.SetLayoutFlags(iks, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(igrik, new Rectangle(0.1, 0.2, 200, 200));
                AbsoluteLayout.SetLayoutFlags(igrik, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;

            
        }

        void OnDragBoxPanUpdated(object sender, PanUpdatedEventArgs e)
        {

            if (e.StatusType == GestureStatus.Running)
            {
                // Move the drag box view
                var dragBox = (Xamarin.Forms.BoxView)sender;
                var x = AbsoluteLayout.GetLayoutBounds(dragBox).X + e.TotalX;
                var y = AbsoluteLayout.GetLayoutBounds(dragBox).Y + e.TotalY;
                AbsoluteLayout.SetLayoutFlags(dragBox, AbsoluteLayoutFlags.None);
                AbsoluteLayout.SetLayoutBounds(dragBox, new Rectangle(x, y, 100, 100));
                var dragPosition = AbsoluteLayout.GetLayoutBounds(drag);
                iks.Text = Convert.ToString(dragPosition.X) + " x";
                igrik.Text = Convert.ToString(dragPosition.Y) + " y";

                var dragBoxPosition = AbsoluteLayout.GetLayoutBounds(drag);
                if (dragBoxPosition.Y > 170 && dragBoxPosition.Y < 200 && dragBoxPosition.X > 120 && dragBoxPosition.X < 160)
                {
                    AbsoluteLayout.SetLayoutFlags(drag, AbsoluteLayoutFlags.PositionProportional);
                    AbsoluteLayout.SetLayoutBounds(drag, new Rectangle(0.5, 0.25, 100, 100));
                    HatResult = true;
                }
                else
                {
                    HatResult = false;
                }
            }
            
        }
        Random rnd;
        private void Rgb_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var headBoxPosition = AbsoluteLayout.GetLayoutBounds(head);
            var dragBoxPosition = AbsoluteLayout.GetLayoutBounds(drag);
            rnd = new Random();


            if (HatResult==true && e.NewValue ==0)
            {
                head.Color = Color.Gray; body.Color = Color.Gray; legs.Color = Color.Gray; drag.Color = Color.Black;
            }
            else if (e.NewValue == 0)
            {
                head.Color = Color.Gray; body.Color = Color.Gray; legs.Color = Color.Gray;

            }
            else if (HatResult == true)
            {
                head.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                body.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                legs.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                drag.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            } 
            else
            {
                head.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                body.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                legs.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            }
        }

        


    }


}
