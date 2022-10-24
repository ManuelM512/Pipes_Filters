using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parte1();
            Parte2();
            
        
        }

        public static void Parte1()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            PipeNull pipeNull = new PipeNull();
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeSerialNegative);
            IPicture image = pipeSerialGrey.Send(picture);

            provider.SavePicture(image, @"NewBeer.jpg");
        }

        public static void Parte2()
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            PipeNull pipeNull = new PipeNull();
            FilterSaveImage filterSaveImage = new FilterSaveImage();
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            PipeSerial pipeSerialSave1 = new PipeSerial(filterSaveImage, pipeNull);
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialSave1);
            PipeSerial pipeSerialSave = new PipeSerial(filterSaveImage, pipeSerialNegative);
            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeSerialSave);
            pipeSerialGrey.Send(picture);
        }

        public static void Parte3(){
             PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            PipeNull pipeNull = new PipeNull();
            FilterTwitter filterTwitter = new FilterTwitter(FilterSaveImage.Path);
            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            FilterSaveImage filterSaveImage = new FilterSaveImage();
            PipeSerial pipeSerialSave1 = new PipeSerial(filterSaveImage, pipeNull);
            PipeSerial pipeSerialTwitter1 = new PipeSerial(filterTwitter, pipeSerialSave1); 
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialTwitter1);
            PipeSerial pipeSerialTwitter = new PipeSerial(filterTwitter, pipeSerialNegative);
            PipeSerial pipeSerialSave = new PipeSerial(filterSaveImage, pipeSerialTwitter);
            PipeSerial pipeSerialGrey = new PipeSerial(filterGreyscale, pipeSerialSave);
            pipeSerialGrey.Send(picture);
        }

        public void Parte4(){
            
        }
    }
}
