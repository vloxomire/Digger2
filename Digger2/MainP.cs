using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Digger2
{
    class MainP
    {
        static void Main(string[] args) 
        {
            //Campos
            Juego juego = new Juego();
            juego.Comienzo();
            //player
            var rigby = new Sprite(new Texture("sprite/minero.png"));
            rigby.Position = new Vector2f(0.0f,0.0f);
        }
    }
}
