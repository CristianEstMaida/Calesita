using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using View;

namespace Entidades
{
    public delegate void InformacionDeAvance(object sender, short movimiento);
    public class Juego
    {
        public event InformacionDeAvance InformarAvance;
        private static short velocidad;
        private short ubicacion;
        private object controlVisual;

        static Juego()
        {
            Juego.velocidad = 8;
        }

        public Juego() { }

        public Juego(short ubicacion, object objetoVisual)
        {
            this.ubicacion = ubicacion;
            this.controlVisual = objetoVisual;
        }

        public short Ubicacion { get => this.ubicacion; set => this.ubicacion = value; }
        public static short Velocidad { get => Juego.velocidad; set => Juego.velocidad = value; }

        [System.Text.Json.Serialization.JsonIgnore]
        public object ControlVisual
        {
            get
            {
                return this.controlVisual;
            }
            set
            {
                this.controlVisual = value;
            }
        }

        public short Avanzar()
        {
            if (ubicacion == 0)
            {
                velocidad = 8;
            }
            /*else
            {
                FrmView f = new FrmView();
                velocidad = f.numericUpDown1.Value;
            }*/
            this.ubicacion += velocidad;
            return this.ubicacion;
        }

        /// <summary>
        /// Simular la animación del Carrusel
        /// </summary>
        public void IniciarCarrusel(CancellationToken token)
        {
            //Juego.velocidad = 8;
            do
            {
                if(this.InformarAvance is not null)
                    this.InformarAvance.Invoke(this, this.Avanzar());

                System.Threading.Thread.Sleep(60 + Juego.velocidad);

                if (token.IsCancellationRequested)
                    return;
            } while (true);

        }


    }

    
}
