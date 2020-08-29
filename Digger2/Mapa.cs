using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger2
{
    class Mapa
    {
        //Campos
        int CmapaAncho;
        int CmapaAlto;
        int casilleroTamanio;
        int mapaAncho;
        int mapaAlto;
        Texture textura;
        Sprite[] mapaCasillero;
        Sprite[,] casilleros;
        //Metodos
        public Mapa() 
        {
            CmapaAncho = 21;
            CmapaAlto = 23;
            mapaAlto = 100;
            mapaAncho = 100;
            casilleroTamanio = 32;

            textura = new Texture("Mapa/Terrain_atlas.png");
            mapaCasillero= new Sprite[CmapaAncho *CmapaAlto];

            for (int y = 0; y < CmapaAlto; y++)
            {
                for (int x = 0; x < CmapaAncho; x++)
                {
                    IntRect rect = new IntRect(x * casilleroTamanio, y*casilleroTamanio,casilleroTamanio,casilleroTamanio);
                    mapaCasillero[(y * CmapaAncho) + x] = new Sprite(textura,rect);
                }
            }

            casilleros = new Sprite[mapaAncho,mapaAlto];
            StreamReader lector = new StreamReader("Mapa/Cueva1.csv");

            for (int y = 0; y < mapaAlto; y++)
            {
                string linea = lector.ReadLine();
                string[] objetos = linea.Split(',');

                for (int x = 0; x < mapaAncho; x++)
                {
                    int id = Convert.ToInt32(objetos[x]);
                    casilleros[x, y] = new Sprite(mapaCasillero[id]);
                    casilleros[x, y].Position = new Vector2f(casilleroTamanio*x,casilleroTamanio*y);
                }
            }
            lector.Close();
        }
        public void Draw(RenderWindow ventana) 
        {
            for (int y = 0; y < mapaAlto; y++)
            {
                for (int x = 0; x < mapaAncho; x++)
                {
                    //En el Game crear un objeto para poder llamarlo
                    ventana.Draw(casilleros[x,y]);
                }
            }
        }
    }
}
