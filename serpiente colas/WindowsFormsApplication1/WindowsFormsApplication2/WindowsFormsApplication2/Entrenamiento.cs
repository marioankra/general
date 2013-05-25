using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Timers;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Clase encargada de establecer la comunicacion entre la logica y la visual, asi como de hacer ciertas funcionas comunes
    /// Genera los objetos de las demas clases relacionadas y crea una nueva comida cada vez que la serpiente colisiona con una comida
    /// Tambien es la encargada de comprobar si existen colisiones
    /// comidaCoor, n e y son variables temporales
    ///
    /// </summary>
    class Entrenamiento : Comida.OnPingListener, Interface1
    {

        public struct CNivel {
            public int velocidad;
            public int objetivo;
            public int dificultad;
            public Nivel nivel;
            // public Boolean TableroN;
        
        }


        // Genera todas los objetos 
        private Nodo n;
        private Timer timerJuego;
        private Serpiente serpiente;
        private Comida comida;
        private int _tamaño;
        private int[] comidaCoor;
        private Boolean _hayFin;
        private Tablero tablero;
        private int _direccionSerpiente;
        public Boolean _block = false;
        private CNivel[] niveles;
        private CNivel nivelActual;



        public Entrenamiento(int tamaño)
        {
            _tamaño = tamaño;
            comidaCoor = new int[2];
            timerJuego = new Timer();
            niveles= new CNivel[4];
            niveles[0].dificultad=0;
            niveles[0].velocidad=500;
            niveles[0].objetivo=3;
            niveles[0].nivel = new Nivel(niveles[0].dificultad, niveles[0].velocidad, niveles[0].objetivo,_tamaño);
           niveles[1].dificultad = 0;
            niveles[1].velocidad = 500;
            niveles[1].objetivo = 3;
            niveles[1].nivel = new Nivel(niveles[1].dificultad, niveles[1].velocidad, niveles[1].objetivo,_tamaño);
           niveles[2].dificultad = 1;
            niveles[2].velocidad = 400;
            niveles[2].objetivo = 4;
            niveles[2].nivel = new Nivel(niveles[2].dificultad, niveles[2].velocidad, niveles[2].objetivo,_tamaño);
            niveles[3].dificultad = 2;
            niveles[3].velocidad = 300;
            niveles[3].objetivo = 5;
            niveles[3].nivel = new Nivel(niveles[3].dificultad, niveles[3].velocidad, niveles[3].objetivo,_tamaño);
         
            /////

            nivelActual= niveles[1];
            ////
            
            
            
            serpiente = new Serpiente(niveles[1].nivel.Tablero, _tamaño);
            generarComida();

            timerJuego.Interval = niveles[1].velocidad;
           
            timerJuego.Elapsed += new ElapsedEventHandler(timerJuego_tick);
            timerJuego.Start();
        
        }

        //Transmite a serpiente la direccion actual
        public void cambiardireccion(int direccion)
        {
            serpiente.CambiarDireccion(direccion);
        }

        //Genera un nuevo objeto comida  y actualiza las coordenadas
        private void generarComida()
        {

            if (comida != null ) comida.pararTimer();
            comida = new Comida(niveles[1].nivel.Tablero, serpiente.Cuerpo, _tamaño, serpiente.X, serpiente.Y);
            comida.setOnPingListener(this);
            comidaCoor[0] = comida.X;
            comidaCoor[1] = comida.Y;
       
        }

        //Metodo llamado en cada tick del timer, mueve la serpiente y comprueba si hay colisiones
        public void actualizar()
        {  
            serpiente.Mover();
            colision();
        }
        //Busca si la posicion de la cabeza coincide con un nodo de la misma, del tablero o comida y acaba el juego o crea una nueva comida y crece
        private void colision() {
            System.Collections.IEnumerator ent = niveles[1].nivel.Tablero.GetEnumerator();
            System.Collections.IEnumerator ens = serpiente.Cuerpo.GetEnumerator();

            int[] coordenadas = new int[2];
            
            Boolean estaChocado = false;
            int numNodos = serpiente.Cuerpo.Count;

            
            while (ens.MoveNext() && !estaChocado && numNodos>1 )
            {
                numNodos--;
                n = (Nodo)ens.Current;
                if (n.X == serpiente.X && n.Y == serpiente.Y)
                    estaChocado = true;
                else
                    estaChocado = false;
            }

            while (ent.MoveNext() && !estaChocado)
                {
                    coordenadas = (int[])ent.Current;
                    if (coordenadas[0] == serpiente.X && coordenadas[1] == serpiente.Y)
                        estaChocado = true;
                    else
                        estaChocado = false;
                }
         
      
            
                if (serpiente.X == comida.X && serpiente.Y == comida.Y)
                {
                    serpiente.crecer(comida.Cantidad);
                    generarComida();
               
                }

                if (estaChocado)
                { 
                _hayFin=true;
                }
 
        }


        Queue Interface1.getTablero()
        {
            return nivelActual.nivel.Tablero;
        }
        Queue Interface1.getSerpiente()
        {
            return serpiente.Cuerpo;
        }



        void Interface1.setDir(int dir)
        {
         _direccionSerpiente=dir;
         
        }


      int Interface1.getTamaño()
      {
            return _tamaño;
        }

       int[] Interface1.getComida()
        {
            return comidaCoor;
        }
       int Interface1.getCantidadComida() {
            return comida.Cantidad;
        }
       Boolean Interface1.getHayFin()
        {
            return _hayFin;
        }
        void Interface1.setHayFin(bool hayfin)
        {
             _hayFin = hayfin;
        }

        public void onPing(){
            _block = true;
            comida.generarCoordenadasComida(nivelActual.nivel.Tablero, serpiente.Cuerpo, _tamaño, serpiente.X, serpiente.Y);
            comidaCoor[0] = comida.X;
            comidaCoor[1] = comida.Y;
            _block = false;
        }

        private void timerJuego_tick(object source, ElapsedEventArgs e) {
            _block = true;
            cambiardireccion(_direccionSerpiente);
            colision();
            actualizar();
            _block = false;
            if (_hayFin == true) timerJuego.Stop();
        }


        
    }
}
