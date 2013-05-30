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
    class Individual : Comida.OnPingListener, Interface1
    {

        public struct CNivel
        {
            public int velocidad;
            public int objetivo;
            public int dificultad;
            public Nivel nivel;
         
            // public Boolean TableroN;

        }


        // Genera todas los objetos 
        
        private Timer timerJuego;
        private Serpiente serpiente;
        private Comida comida;
        private int _tamaño;
        private int[] comidaCoor;
        private Boolean _hayFin;

        private int _direccionSerpiente;

        private CNivel[] niveles;
        private CNivel nivelActual;
        private int _puntos;
       
        private Random r = new Random(DateTime.Now.Millisecond);


        private OnPingListener cListener;
        private int opcion;
        private Juego juego;
        public interface OnPingListener
        {
            void onColor(bool color);

        }
        public void setOnPingListener(OnPingListener listener)
        {
            cListener = listener;
        }





        public Individual(int tamaño, int opcion /*,OnPingListener listener*/)
        {
          //  setOnPingListener(listener);
          
            _tamaño = tamaño;
            comidaCoor = new int[2];
            timerJuego = new Timer();
            niveles = new CNivel[4];
            niveles[0].dificultad = 0;
            niveles[0].velocidad = 500;
            niveles[0].objetivo = 6;
            niveles[0].nivel = new Nivel(niveles[0].dificultad, niveles[0].velocidad, niveles[0].objetivo, _tamaño);
            niveles[1].dificultad = 1;
            niveles[1].velocidad = 500;
            niveles[1].objetivo = 12;
            niveles[1].nivel = new Nivel(niveles[1].dificultad, niveles[1].velocidad, niveles[1].objetivo, _tamaño);
            niveles[2].dificultad = 2;
            niveles[2].velocidad = 500;
            niveles[2].objetivo = 1;
            niveles[2].nivel = new Nivel(niveles[2].dificultad, niveles[2].velocidad, niveles[2].objetivo, _tamaño);
            niveles[3].dificultad = 3;
            niveles[3].velocidad = 500;
            niveles[3].objetivo = 1;
            niveles[3].nivel = new Nivel(niveles[3].dificultad, niveles[3].velocidad, niveles[3].objetivo, _tamaño);
            nivelActual = niveles[3];
            generarSerpiente();
            generarComida();
            timerJuego.Interval = nivelActual.velocidad;
            timerJuego.Elapsed += new ElapsedEventHandler(timerJuego_tick);
            timerJuego.Start();

        }




        private void cambiarNivel()
        {
            if (_puntos >= nivelActual.objetivo)
            {
                int hola = niveles.Length;
                if (nivelActual.dificultad == niveles.Length-1) _hayFin = true;
                else
                {
                    
                        timerJuego.Stop();
                        nivelActual = niveles[nivelActual.dificultad + 1];
                        generarSerpiente();
                        generarComida();
                        timerJuego.Interval = nivelActual.velocidad;
                        timerJuego.Start();
 
                }
            }
        }


        //Transmite a serpiente la direccion actual
        public void cambiardireccion(int direccion)
        {
            serpiente.CambiarDireccion(direccion);
        }

        //Genera un nuevo objeto comida  y actualiza las coordenadas
        private void generarComida()
        {

            if (comida != null) comida.pararTimer();

          
            int x, y;
            do
            {
            x = r.Next(1, _tamaño - 1);
                y = r.Next(1, _tamaño - 1);
            } while (nivelActual.nivel.buscarenTablero(x, y) || serpiente.buscarenSerpiente(x,y,true));
          
       

            comida = new Comida(x, y);
            comida.setOnPingListener(this);
            comidaCoor[0] = comida.X;
            comidaCoor[1] = comida.Y;
            //cListener.onColor(comida.EstaSenyal);
        }

        private void generarSerpiente()
        {
            
            int x, y;
            do
            {
                x = r.Next(1, _tamaño - 1);
                y = r.Next(1, _tamaño - 1);
            } while (nivelActual.nivel.buscarenTablero(x, y));

            if (!nivelActual.nivel.buscarenTablero(x+1, y)) _direccionSerpiente=0;
            else if (!nivelActual.nivel.buscarenTablero(x, y+1)) _direccionSerpiente=1;
            else if (!nivelActual.nivel.buscarenTablero(x-1, y)) _direccionSerpiente = 2;
            else if (!nivelActual.nivel.buscarenTablero(x, y-1)) _direccionSerpiente = 3;

            serpiente = new Serpiente(x, y, _direccionSerpiente);
        }


        //Metodo llamado en cada tick del timer, mueve la serpiente y comprueba si hay colisiones
        public void actualizar()
        {
            cambiarNivel();
            serpiente.Mover();
            if (comida.buscarenComida(serpiente.X, serpiente.Y))
            {
                serpiente.crecer(comida.Cantidad);
                generarPuntuacion(comida.Cantidad);
                generarComida();

            }
            if (_hayFin == false) _hayFin = nivelActual.nivel.buscarenTablero(serpiente.X, serpiente.Y);

            if (_hayFin == false) _hayFin = serpiente.buscarenSerpiente(serpiente.X, serpiente.Y, false);
        }
        //Busca si la posicion de la cabeza coincide con un nodo de la misma, del tablero o comida y acaba el juego o crea una nueva comida y crece



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
            _direccionSerpiente = dir;

        }

        void Interface1.setPlayer(int player)
        {
        
        }

        int Interface1.getPlayer()
        {
            return 1;
        }

        int Interface1.getnumPlayer()
        {
            return 1;
        }


        int Interface1.getTamaño()
        {
            return _tamaño;
        }

        int[] Interface1.getComida()
        {
            return comidaCoor;
        }
        int Interface1.getCantidadComida()
        {
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
        int Interface1.getPuntuacion()
        {
            return _puntos;
        }
        int Interface1.getObjetivo()
        {
            return nivelActual.objetivo;
        }
        public void onPing()
        {



            Random r = new Random(DateTime.Now.Millisecond);
            int x, y;
            do
            {
                x = r.Next(1, _tamaño - 1);
                y = r.Next(1, _tamaño - 1);
            } while (nivelActual.nivel.buscarenTablero(x, y) || serpiente.buscarenSerpiente(x, y, true));

            comida.X = x;
            comida.Y = y;

            comidaCoor[0] = comida.X;
            comidaCoor[1] = comida.Y;

            if (!comida.EstaSenyal)
            {
                comida.EstaSenyal = true;
             //   cListener.onColor(comida.EstaSenyal);
            }

        }

        private void timerJuego_tick(object source, ElapsedEventArgs e)
        {

            cambiardireccion(_direccionSerpiente);

            actualizar();

            if (_hayFin == true) timerJuego.Stop();
        }

        public void generarPuntuacion(int cantidadComida)
        {

            _puntos = _puntos + cantidadComida;

        }


    }
}