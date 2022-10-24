using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        protected FilterConditional filterConditional; 
        protected IFilter falseFilter;
        protected IFilter trueFilter;
        protected IPipe nextPipe;

        /// <summary>
        /// Emplea un filtro condicional, si este es verdadero o falso, utilizará un filtro u otro de los 2 dados, y seguirá al próximo Pipe
        /// </summary>
        /// <param name="filterConditional"></param>
        /// <param name="nextPipe"></param>
        /// <param name="falseFilter"></param>
        /// <param name="trueFilter"></param>
        public PipeConditional(FilterConditional filterConditional, IPipe nextPipe, IFilter falseFilter, IFilter trueFilter) 
        {
            this.nextPipe = nextPipe; 
            this.filterConditional = filterConditional;
            this.falseFilter = falseFilter;
            this.trueFilter = trueFilter;

        }
        /// <summary>
        /// Devuelve si la imagen tiene o no una cara, el path de la img sera FilterSaveImage.Path 
        /// </summary>
        /// <value></value>
        public bool Face
        {
            get { return this.filterConditional.FaceRecognition(FilterSaveImage.Path); }
        }
        /// <summary>
        /// En caso de tener o no una cara, aplica el filtro correspondiente
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public IPicture Send(IPicture picture)
        {
            if(Face){
                picture = this.trueFilter.Filter(picture);
            } else {
                picture = this.falseFilter.Filter(picture);
            }
            return this.nextPipe.Send(picture);
        }
    }
}
