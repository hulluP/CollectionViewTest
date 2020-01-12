using System;
using Xamarin.Forms;


namespace collectionViewTestX

{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            StackLayout contentView = new StackLayout();
            Button showList = new Button()
            {
                Text = "click"
            };
            showList.Clicked += ShowList_ClickedAsync;
            contentView.Children.Add(showList);
            Content = contentView;
        }

        private async void ShowList_ClickedAsync(object sender, EventArgs e)
        {
            CollectionViewX newView = new CollectionViewX();
            await Navigation.PushAsync(newView.GetMainPage());
        }
    }
}
