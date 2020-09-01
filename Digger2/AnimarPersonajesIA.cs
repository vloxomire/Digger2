using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger2
{
    class AnimarPersonajesIA : AnimarPersonajes
    {
        public List<PuntoACaminar> PuntoACaminarLista { get; set; }
        private int siguientePuntoACaminarIndex = 1;
        public AnimarPersonajesIA(string archivo,int frameTamanio) : base(archivo,frameTamanio) 
        {

        }
        public override void Update(float deltaTime)
        {
            SeguirCamino();
            base.Update(deltaTime);
        }
        public void SeguirCamino() 
        {
            if (PuntoACaminarLista!=null) 
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
            }
        }
    }
}
