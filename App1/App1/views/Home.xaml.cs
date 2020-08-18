using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            pageComponents();

            //async void OnButtonClicked(object sender, EventArgs args)
            //{
            //    await label.RelRotateTo(360, 1000);
            //}
        }

        private void pageComponents()
        {

            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            var width = mainDisplayInfo.Width;

            //Grid and Grid Rows Defeinitions
            var grid = new Grid();
            grid.RowSpacing = 0;
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.35, GridUnitType.Star) });//GridLength.Auto
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.15, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.30, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.20, GridUnitType.Star) }); //new GridLength(1, GridUnitType.Star)

            //Rows Containers
            var Header = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0, 20, 0, 5)
            };
            var swapButtons = new Frame
            {
                VerticalOptions = LayoutOptions.Center,
                HasShadow = false,
                BorderColor = System.Drawing.Color.Transparent
            };
            var loginForm = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(20, 5, 20, 0)
            };
            var socialIcons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 5,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.End,
                Margin = new Thickness(0, 0, 0, 10)
            };

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    socialIcons.VerticalOptions = LayoutOptions.Center;
                    break;
                case Device.Android:
                    socialIcons.VerticalOptions = LayoutOptions.End;
                    break;
                case Device.UWP:
                default:
                    socialIcons.VerticalOptions = LayoutOptions.End;
                    break;
            }

            Grid.SetRow(swapButtons, 1);
            Grid.SetRow(loginForm, 2);
            Grid.SetRow(socialIcons, 3);

            //Header Components
            var headerImage = new Image
            {
                Source = "vk.png",
                HorizontalOptions = LayoutOptions.Center
            };

            var title = new Label
            {
                Text = "Welcome",
                FontSize = (Device.GetNamedSize(NamedSize.Large, typeof(Label))) + 30,
                FontAttributes = FontAttributes.Bold,
                TextColor = System.Drawing.Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                FontFamily = ""
            };

            //Row 2 Components
            var swapGrid = new Grid
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            swapGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            swapGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });

            var loginBtn = new Button
            {
                Text = "Login",
                BackgroundColor = System.Drawing.Color.Transparent
            };

            var signBtn = new Button
            {
                Text = "Signup",
                BackgroundColor = System.Drawing.Color.Transparent
            };

            Grid.SetColumn(signBtn, 1);
            swapGrid.Children.Add(loginBtn);
            swapGrid.Children.Add(signBtn);

            //Row 3 Components

            var emailEntry = new Entry
            {
                Placeholder = "Email Address",
                PlaceholderColor = System.Drawing.Color.Gray,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                Keyboard = Keyboard.Email,
                ReturnType = ReturnType.Next,
                IsSpellCheckEnabled = false
            };

            var passGrid = new Grid();

            passGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
            passGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });

            var passEntry = new Entry
            {
                Placeholder = "Password",
                PlaceholderColor = System.Drawing.Color.Gray,
                IsPassword = true,
                ReturnType = ReturnType.Send,
                IsSpellCheckEnabled = false
            };

            var showHidePass = new Image
            {
                Source = "eye_view.png",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            var showHideGestureRecognizer = new TapGestureRecognizer();
            showHideGestureRecognizer.Tapped += (s, e) => {
                passEntry.IsPassword = passEntry.IsPassword ? false : true;
                passEntry.CursorPosition = passEntry.Text.Length;
            };
            showHidePass.GestureRecognizers.Add(showHideGestureRecognizer);

            Grid.SetColumn(passEntry, 0);
            Grid.SetColumnSpan(passEntry, 2);
            Grid.SetColumn(showHidePass, 1);

            passGrid.Children.Add(passEntry);
            passGrid.Children.Add(showHidePass);

            var submitBtn = new Button
            {
                Text = "LOGIN",
                BackgroundColor = System.Drawing.Color.Blue,
                Padding = new Thickness(0, 20),
                TextColor = System.Drawing.Color.White,
                FontAttributes = FontAttributes.Bold
            };


            //Row 4 Components
            var facebook = new ImageButton
            {
                Source = "Path_2048.png",
                BackgroundColor = System.Drawing.Color.Transparent
            };
            var twitter = new ImageButton
            {
                Source = "Path_2050.png",
                BackgroundColor = System.Drawing.Color.Transparent
            };
            var email = new ImageButton
            {
                Source = "Union_1.png",
                BackgroundColor = System.Drawing.Color.Transparent
            };


            //Add childrens to Rows
            Header.Children.Add(headerImage);
            Header.Children.Add(title);

            swapButtons.Content = swapGrid;

            loginForm.Children.Add(emailEntry);
            //loginForm.Children.Add(passEntry);
            loginForm.Children.Add(passGrid);
            loginForm.Children.Add(submitBtn);
            //loginForm.Children.Add(new BoxView() {WidthRequest = 150, HeightRequest = 5, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, Color = System.Drawing.Color.Gray});

            socialIcons.Children.Add(facebook);
            socialIcons.Children.Add(twitter);
            socialIcons.Children.Add(email);

            //Add Rows to Grid then Assign Grid to Content
            grid.Children.Add(Header);
            grid.Children.Add(swapButtons);
            grid.Children.Add(loginForm);
            grid.Children.Add(socialIcons);

            this.Content = grid;
        }
    }
}