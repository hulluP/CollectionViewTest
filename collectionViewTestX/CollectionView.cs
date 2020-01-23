using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace collectionViewTestX
{
    public class CollectionViewX : ContentPage
    {
        private StackLayout _VerticallViewStack;

        private Color COLOR_SCHEME_COLOR_2 = Color.White;
        private CollectionXModel PageModel;
        private CollectionView ImageCollectionView;
        private RefreshView RefreshImageCollection;

        public CollectionViewX()
        {
            PageModel = new CollectionXModel();
        }

        public Page GetMainPage()
        {
            _VerticallViewStack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 0,
                BackgroundColor = COLOR_SCHEME_COLOR_2

            };
            int numberOfColums = 2;

            ImageCollectionView = new CollectionView
            {
                SelectionMode = SelectionMode.Single,
                ItemsLayout = new GridItemsLayout(numberOfColums, ItemsLayoutOrientation.Vertical),
                BackgroundColor = COLOR_SCHEME_COLOR_2
            };
            //RefreshImageCollection = new RefreshView()
            //{
            //    BackgroundColor = COLOR_SCHEME_COLOR_2
            //};
            //RefreshImageCollection.Command = RefreshCommand;
            //RefreshImageCollection.Content = ImageCollectionView;
            _VerticallViewStack.Children.Add(ImageCollectionView);
            //_VerticallViewStack.Children.Add(RefreshImageCollection);
            LoadCollectionView();
            Content = _VerticallViewStack;
            return this;
        }

        private void LoadCollectionView()
        {
            BindingContext = PageModel;

            ImageCollectionView.SetBinding(ItemsView.ItemsSourceProperty, "ViewImages");
            ImageCollectionView.SelectionChanged += OnCollectionViewSelectionChanged;

            ImageCollectionView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid { Padding = 10 };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                Image image = new Image
                {
                    Aspect = Aspect.AspectFill,
                    HorizontalOptions = LayoutOptions.Center,
                    HeightRequest = 60,
                    WidthRequest = 60
                };
                image.SetBinding(Image.SourceProperty, "ImageSource");
                image.IsAnimationPlaying = true;

                grid.Children.Add(image);

                return grid;
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (PageModel != null)
            {
                PageModel.Dispose();
            }
            //BindingContext = null; 
            ImageCollectionView.RemoveBinding(ItemsView.ItemsSourceProperty);
            ImageCollectionView.SelectionChanged -= OnCollectionViewSelectionChanged;
        }
        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
        }

        public ICommand RefreshCommand => new Command(async () => RefreshItemsAsync());

        private async Task RefreshItemsAsync()
        {
            RefreshImageCollection.IsRefreshing = true;
            await PageModel.LoadMoreResults();
            RefreshImageCollection.IsRefreshing = false;
        }
    }
}
