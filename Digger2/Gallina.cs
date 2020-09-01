using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger2
{
    class Gallina : AnimarPersonajes
    {
        public Gallina() :base("Sprites/chicken_walk.png", 32)
        {
            //Mover
            Aarriba = new Animacion(0, 0, 4);
            Aizq = new Animacion(32, 0, 4);//pq es de 32px
            Ader = new Animacion(96, 0, 4);
            Aabajo = new Animacion(64, 0, 4);
        }
    }
}
