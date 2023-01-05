using System;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;


namespace popUp

{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            StackLayout contentView = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Button showList = new Button()
            {
                Text = "click",
                BackgroundColor = Color.DarkGreen
            };
            showList.Clicked += ShowList_ClickedAsync;
            contentView.Children.Add(showList);
            Content = contentView;
        }

        private async void ShowList_ClickedAsync(object sender, EventArgs e)
        {
            var result = await Navigation.ShowPopupAsync(new ButtonPopup());
        }
    }
}
