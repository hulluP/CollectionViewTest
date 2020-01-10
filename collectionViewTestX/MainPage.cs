using System;
using System.Net;
using Xamarin.Forms;
using System.IO;
using System.Linq;

namespace collectionViewTestX

{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MonkeysViewModel();
            CollectionView collectionView = new CollectionView
            {
                SelectionMode = SelectionMode.Single,
                ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical)
            };
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Monkeys");
            collectionView.SelectionChanged += OnCollectionViewSelectionChanged;

            collectionView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid { Padding = 10 };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                Image image = new Image { Aspect = Aspect.AspectFill, HeightRequest = 60, WidthRequest = 60 };
                image.SetBinding(Image.SourceProperty, "ImageUrlSource");
                image.IsAnimationPlaying = true;
                Label nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label locationLabel = new Label { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
                locationLabel.SetBinding(Label.TextProperty, "Location");

                Grid.SetRowSpan(image, 2);

                grid.Children.Add(image);
                grid.Children.Add(nameLabel, 1, 0);
                grid.Children.Add(locationLabel, 1, 1);

                return grid;
            });
            Content = collectionView;


        }
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string previous = (e.PreviousSelection.FirstOrDefault() as Monkey)?.Name;
            string current = (e.CurrentSelection.FirstOrDefault() as Monkey)?.Name;

        }
    }
}
