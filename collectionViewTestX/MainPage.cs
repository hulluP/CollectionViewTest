using System;
using Xamarin.Forms;


namespace collectionViewTestX

{
    public class MainPage : ContentPage
    {
        private Label Counter;
        private Label InitialCounter;
        public MainPage()
        {
            StackLayout contentView = new StackLayout();
            Button showList = new Button()
            {
                Text = "click"
            };
            InitialCounter = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "---"
            };
            Counter = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "---"
            };
            showList.Clicked += ShowList_ClickedAsync;
            contentView.Children.Add(showList);
            contentView.Children.Add(InitialCounter);
            contentView.Children.Add(Counter);
            Content = contentView;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Counter.Text = "Total Memory:" + GC.GetTotalMemory(false);
            if (InitialCounter.Text.Length < 5)
            {
                InitialCounter.Text = "inital Memory:" + GC.GetTotalMemory(false);
            }
        }
        private async void ShowList_ClickedAsync(object sender, EventArgs e)
        {
            CollectionViewX newView = new CollectionViewX();
            await Navigation.PushAsync(newView.GetMainPage());
        }
    }
}
