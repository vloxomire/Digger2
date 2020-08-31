using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger2
{
    class Animacion
    {
        public int offSetArriba;
        public int offSetIzq;
        public int numFrames;

        public Animacion(int offSetArriba,int offSetIzq,int numFrames)
        {
            this.offSetArriba = offSetArriba;
            this.offSetIzq = offSetIzq;
            this.numFrames = numFrames;
        }
    }
}
