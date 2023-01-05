using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace popUp
{
    public partial class ButtonPopup : Popup
    {
        protected Button CancelButton = null;

        public ButtonPopup()
        {
            StackLayout contentLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            CancelButton = new Button()
            {
                //FontFamily = EltepiGlobalUI.FONT_MAIN_FONT,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HeightRequest = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 3,
                BorderWidth = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Chocolate,
            };
            CancelButton.Text = "exit";
            CancelButton.Command = new Command(() => Dismiss(null));
            contentLayout.Children.Add(CancelButton);
            Content = contentLayout;
        }


    }
}