using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger2
{
    class Juego
    {
        RenderWindow ventana;
        Mapa mapa;
        public Juego()
        {
            //ventana
            ventana = new RenderWindow(new VideoMode(320, 480), "Digger2");
            mapa = new Mapa();
        }
        public void Comienzo() 
        {
            //ventana
            ventana.SetFramerateLimit(60);
            //Escuchadores
            ventana.Closed += CerrarVentana;//escuchador de cerrar ventana con x.
            ventana.KeyReleased += SoltarEsc;//escuchador de cerrar cuando suelto una tecla.
            ventana.KeyPressed += PresionarShift;//escuchador para cerrar presionando una tecla
            //Inicio del Juego, bucle
            while (ventana.IsOpen)
            {
                ventana.DispatchEvents();//escuchadores
                ventana.Clear(new Color(146,108,66));
                mapa.Draw(ventana);
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
