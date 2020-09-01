using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace Digger2
{
    class Juego
    {
        private RenderWindow ventana;
        private Mapa mapa;
        private Gallina gallina;
        private Jugador jugador;
        private Clock clock;
        private View camara;
        
        public Juego()
        {
            //ventana
            ventana = new RenderWindow(new VideoMode(800, 600), "Digger2");
            //camara
            camara = new View(new Vector2f(0,0),new Vector2f(800,600));

            mapa = new Mapa();
            gallina = new Gallina();
            jugador = new Jugador();
        }
        public void Comienzo() 
        {
            //ventana
            ventana.SetFramerateLimit(60);
            //Escuchadores
            ventana.Closed += CerrarVentana;//escuchador de cerrar ventana con x.
            ////ventana.KeyReleased += SoltarEsc;//escuchador de cerrar cuando suelto una tecla.
            ventana.KeyPressed += PresionarShift;//escuchador para cerrar presionando una tecla
            //PATRON CAMINATA
            gallina.PuntoACaminarLista = new List<PuntoACaminar>();
            gallina.PuntoACaminarLista.Add(new PuntoACaminar(0, 0));
            gallina.PuntoACaminarLista.Add(new PuntoACaminar(100, 100));
            gallina.PuntoACaminarLista.Add(new PuntoACaminar(0, 100));

            clock = new Clock();
            //Inicio del Juego, bucle
            while (ventana.IsOpen)
            {
                ventana.DispatchEvents();//escuchadores

                ventana.Clear(new Color(47,129,54));

                float deltaTime = clock.Restart().AsSeconds();
                //UPDATE
                gallina.Update(deltaTime);
                jugador.Update(deltaTime);
                //CAMARA
                camara.Center = new Vector2f(jugador.Xpos,jugador.Ypos);//Lo centro sobre el player
                ventana.SetView(camara);//Cambiar a la vista actual, lo va centrando,mientras mueve cambia
                //DRAW
                mapa.Draw(ventana);
                gallina.Draw(ventana);
                jugador.Draw(ventana);

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
