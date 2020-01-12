using System;
using Xamarin.Forms;

namespace collectionViewTestX
{
    public class ViewImage
    {

        private string myUrl;
        private string myThumbnailURL;
        public string ID { get; }
        private bool myIsAnimated = false;

        public ViewImage(string url, string thumbnail, string id)
        {
            myUrl = url;
            myThumbnailURL = thumbnail;
            if (myThumbnailURL.Contains(".gif"))
            {
                myIsAnimated = true;
            }
            ID = id;
        }
        public bool IsAnimated
        {
            get => myIsAnimated;
            private set { }
        }
        public string ImageUrl
        {
            get => myUrl;
            set
            {
                if (value != myUrl)
                {
                    myUrl = value;
                }
            }
        }
        public string ThumbnailURL
        {
            get => myThumbnailURL;
            set
            {
                if (value != myThumbnailURL)
                {
                    myThumbnailURL = value;

                }
            }
        }
        public ImageSource ImageSource
        {
            get
            {
                return ImageSource.FromUri(new Uri(myThumbnailURL));
            }
            set
            {

            }
        }

    }
}
