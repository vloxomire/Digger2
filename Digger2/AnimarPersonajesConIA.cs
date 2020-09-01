using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger2
{
    class AnimarPersonajesConIA : AnimarPersonajes
    {
        public List<PuntoACaminar> PuntoACaminarLista { get; set; }
        private int siguientePuntoACaminarIndex = 1;

        private Clock aIClock;
        public AnimarPersonajesConIA(string archivo,int frameTamanio) : base(archivo,frameTamanio) 
        {
            aIClock = new Clock();
        }
        public override void Update(float deltaTime)
        {
            SeguirCamino();
            base.Update(deltaTime);
        }
        public void SeguirCamino() 
        {
            if (aIClock.ElapsedTime.AsSeconds() > 0.5f)
            {
                if (PuntoACaminarLista != null)
                {
                    PuntoACaminar siguienteCamino = PuntoACaminarLista[siguientePuntoACaminarIndex];
                    float xDiferencia = siguienteCamino.XPos - this.Xpos;
                    float yDiferencia = siguienteCamino.YPos - this.Ypos;
                    float absXDiferencia = Math.Abs(xDiferencia);
                    float absYDiferencia = Math.Abs(yDiferencia);

                    if (absXDiferencia < 10 && absYDiferencia < 10)
                    {
                        if (siguientePuntoACaminarIndex < PuntoACaminarLista.Count - 1)
                        {
                            siguientePuntoACaminarIndex++;
                        }
                        else
                        {
                            siguientePuntoACaminarIndex = 0;
                        }
                    }
                    if (absXDiferencia > absYDiferencia)
                    {
                        if (xDiferencia > 0)
                        {
                            this.estadoActual = EstadosDelPersonaje.MoverDer;
                        }
                        if (xDiferencia < 0)
                        {
                            this.estadoActual = EstadosDelPersonaje.MoverIzq;
                        }
                    }
                    else
                    {
                        if (yDiferencia > 0)
                        {
                            this.estadoActual = EstadosDelPersonaje.MoverAbajo;
                        }
                        if (yDiferencia < 0)
                        {
                            this.estadoActual = EstadosDelPersonaje.MoverArriba;
                        }
                    }
                }
                aIClock.Restart();
            }
        }
    }
}
