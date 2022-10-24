using System;
using System.Drawing;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter {
        string Path;
        public FilterTwitter (string path){
            this.Path = path;
        }
        public IPicture Filter (IPicture image){
            PictureProvider provider = new PictureProvider();
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("text", Path));
            return image;
        }
    }
}