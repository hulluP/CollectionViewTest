using System;
using Xamarin.Forms;

namespace collectionViewTestX
{
    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public ImageSource ImageUrlSource
        {
            get
            {
                return new UriImageSource
                {
                    CachingEnabled = false,
                    Uri = new Uri(ImageUrl)
                };
            }
            set { }
        }
        public bool IsFavorite { get; set; }
    }
}
