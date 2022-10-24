using System;
using System.Drawing;
using CompAndDel;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter {
        IPicture Image;
        public IPicture Filter (IPicture image){
            this.Image = image;
            return image;
        }

        public bool FaceRecognition (string path){
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(path);
            return cog.FaceFound;
        }
    }
}