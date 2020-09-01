using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger2
{
    class Jugador : AnimarPersonajes
    {
        //Campos
        //Heredados de la clase abstracta            
        //Metodos
        public Jugador() : base("Sprites/male.png",64)
        {
            //abstracta de animacionCaracter
            Aarriba = new Animacion(512, 0, 9);
            Aizq = new Animacion(578, 0, 9);
            Ader = new Animacion(704, 0, 9);
            Aabajo = new Animacion(640, 0, 9);

            moverVelocidad = 150;
            animacionVelocidad = 0.05f;
        }
        public override void Update(float deltaTime) 
        {
            this.estadoActual = EstadosDelPersonaje.idle;

            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) { this.estadoActual = EstadosDelPersonaje.MoverArriba; }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S)) { this.estadoActual = EstadosDelPersonaje.MoverAbajo; }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { this.estadoActual = EstadosDelPersonaje.MoverIzq; }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { this.estadoActual = EstadosDelPersonaje.MoverDer; }

            base.Update(deltaTime);
        }
        public void Dibujar() 
        {

        }
    }
}
