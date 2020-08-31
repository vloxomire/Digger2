using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Digger2
{
    class Juego
    {
        RenderWindow ventana;
        Mapa mapa;
        Gallina gallina;
        AnimarCaracter animacionDelPersonaje;

        private Clock clock;
        
        public Juego()
        {
            //ventana
            ventana = new RenderWindow(new VideoMode(800, 600), "Digger2");

            mapa = new Mapa();
            gallina = new Gallina();
        }
        public void Comienzo() 
        {
            //ventana
            ventana.SetFramerateLimit(60);
            //Escuchadores
            ventana.Closed += CerrarVentana;//escuchador de cerrar ventana con x.
            ////ventana.KeyReleased += SoltarEsc;//escuchador de cerrar cuando suelto una tecla.
            ventana.KeyPressed += PresionarShift;//escuchador para cerrar presionando una tecla

            gallina.estadoActual = estadoDelPersonaje.MoverAbajo;

            clock = new Clock();
            //Inicio del Juego, bucle
            while (ventana.IsOpen)
            {
                ventana.DispatchEvents();//escuchadores

                ventana.Clear(new Color(47,129,54));

                float deltaTime = clock.Restart().AsSeconds();
                //UPDATE
                gallina.Update(deltaTime);
                //DRAW
                mapa.Draw(ventana);
                gallina.Draw(ventana);

                ventana.Display();//Muestro la ventana
            }
        }
        //Cierro con x
        private void CerrarVentana(object sender, EventArgs e)
        {
            ventana.Close();
        }
        //Cierro soltando
        private void SoltarEsc(object sender, KeyEventArgs e)
        {
            var win = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
            {
                win.Close();
            }
        }
        //Cierro presionando
        private void PresionarShift(object sender, KeyEventArgs e)
        {
            var win = (Window)sender;
            if (e.Code == Keyboard.Key.LShift)
            {
                win.Close();
            }
        }
    }
}
