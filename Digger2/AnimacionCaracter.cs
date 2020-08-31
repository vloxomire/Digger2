﻿using SFML.Graphics;
using SFML.System;
using System;


namespace Digger2
{
    public enum CaracterEstados
    {
        idle,
        MoverArriba,
        MoverAbajo,
        MoverIzq,
        MoverDer
    }
    class AnimacionCaracter
    {
        public float Xpos { get; set; }
        public float Ypos { get; set; }
        public CaracterEstados ActualEstado { get; set; }

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

        public AnimacionCaracter(string nombreArchivo, int frameTamanio)
        {
            this.frameTamanio = frameTamanio;
            Texture textura = new Texture(nombreArchivo);

            spriteRect = new IntRect(0, 0, frameTamanio, frameTamanio);
            sprite = new Sprite(textura, spriteRect);
            //Mover
            Aarriba = new Animacion(0, 0, 4);
            Aizq = new Animacion(32, 0, 4);//pq es de 32px
            Ader = new Animacion(96, 0, 4);
            Aabajo = new Animacion(64, 0, 4);

            clock = new Clock();
            Time time = clock.Restart();
        }
        public virtual void Update(float deltaTime)
        {
            Animacion animacionActual = null;
            switch (ActualEstado)
            {
                case CaracterEstados.MoverArriba:
                    animacionActual = Aarriba;
                    Ypos -= moverVelocidad * deltaTime;
                    break;
                case CaracterEstados.MoverAbajo:
                    animacionActual = Aabajo;
                    Ypos += moverVelocidad * deltaTime;
                    break;
                case CaracterEstados.MoverIzq:
                    animacionActual = Aizq;
                    Xpos -= moverVelocidad * deltaTime;
                    break;
                case CaracterEstados.MoverDer:
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
