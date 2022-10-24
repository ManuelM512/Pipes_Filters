using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class FilterSaveImage : IFilter {

       //int cantImgs = 0;
        public static string Path = "NewStage.jpg";
        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            //Si se quieren persistir todas las estapas
            //cantImgs++;
            //provider.SavePicture(image, @"NewStage"+this.cantImgs.ToString()+".jpg");
            //Si solo se quiere guardar etapa a etapa, reescribiendo
            provider.SavePicture(image, Path);
            return image;
        }
    }
}