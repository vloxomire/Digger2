using SFML.Graphics;
using SFML.System;
using System;


namespace Digger2
{
    public enum EstadosDelPersonaje
    {
        idle,
        MoverArriba,
        MoverAbajo,
        MoverIzq,
        MoverDer
    }
    abstract class AnimarPersonajes
    {
        public float Xpos { get; set; }
        public float Ypos { get; set; }
        public EstadosDelPersonaje estadoActual { get; set; }

        private Sprite sprite;
        private IntRect spriteRect;
        private int frameTamanio;
        readonly Clock clock;

        protected Animacion Aarriba;
        protected Animacion Aizq;
        protected Animacion Ader;
        protected Animacion Aabajo;
        protected float moverVelocidad = 50;
        protected float animacionVelocidad = 0.1f;

        public AnimarPersonajes(string nombreArchivo, int frameTamanio)
        {
            this.frameTamanio = frameTamanio;
            Texture textura = new Texture(nombreArchivo);

            spriteRect = new IntRect(0, 0, frameTamanio, frameTamanio);
            sprite = new Sprite(textura, spriteRect);
           

            clock = new Clock();
            Time time = clock.Restart();
        }
        public virtual void Update(float deltaTime)
        {
            Animacion animacionActual = null;
            switch (estadoActual)
            {
                case EstadosDelPersonaje.MoverArriba:
                    animacionActual = Aarriba;
                    Ypos -= moverVelocidad * deltaTime;
                    break;
                case EstadosDelPersonaje.MoverAbajo:
                    animacionActual = Aabajo;
                    Ypos += moverVelocidad * deltaTime;
                    break;
                case EstadosDelPersonaje.MoverIzq:
                    animacionActual = Aizq;
                    Xpos -= moverVelocidad * deltaTime;
                    break;
                case EstadosDelPersonaje.MoverDer:
                    animacionActual = Ader;
                    Xpos += moverVelocidad * deltaTime;
                    break;
            }
            sprite.Position = new Vector2f(Xpos, Ypos);

            if (clock.ElapsedTime.AsSeconds() > animacionVelocidad)
            {
                if (animacionActual != null)
                {
                    spriteRect.Top = animacionActual.offSetArriba;
                    if (spriteRect.Left == (animacionActual.numFrames - 1) * frameTamanio)
                    {
                        spriteRect.Left = 0;
                    }
                    else
                    {
                        spriteRect.Left += frameTamanio;
                    }
                }
                clock.Restart();
            }
            sprite.TextureRect = spriteRect;
        }
        public void Draw(RenderWindow ventana)
        {
            ventana.Draw(sprite);
        }
    }
}
