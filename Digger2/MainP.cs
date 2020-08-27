using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace Digger2
{
    class MainP
    {
        //ventana
        static RenderWindow renderWindow = new RenderWindow(new VideoMode(320, 480), "Digger2");
        static void Main(string[] args) 
        {
            //Escuchadores
            renderWindow.Closed +=CerrarVentana;//escuchador de cerrar ventana con x.
            renderWindow.KeyReleased +=SoltarEsc;//escuchador de cerrar cuando suelto una tecla.
            renderWindow.KeyPressed += PresionarShift;//escuchador para cerrar presionando una tecla
            //player
            var rigby = new Sprite(new Texture("sprite/minero.png"));
            rigby.Position = new Vector2f(0.0f,0.0f);
            
            //Inicio del Juego, bucle
            while (renderWindow.IsOpen) 
            {
                renderWindow.DispatchEvents();//escuchadores
                renderWindow.Draw(rigby);
                renderWindow.Display();//Muestro la ventana
            }
        }
        //Cierro con x
        private static void CerrarVentana(object sender,EventArgs e) 
        {
            renderWindow.Close();
        }
        //Cierro soltando
        private static void SoltarEsc(object sender,KeyEventArgs e) 
        {
            var win = (Window)sender;
            if (e.Code==Keyboard.Key.Escape)
            {
                win.Close();
            }
        }
        //Cierro presionando
        private static void PresionarShift(object sender,KeyEventArgs e) 
        {
            var win = (Window)sender;
            if (e.Code==Keyboard.Key.LShift)
            {
                win.Close();
            }
        }
    }
}
