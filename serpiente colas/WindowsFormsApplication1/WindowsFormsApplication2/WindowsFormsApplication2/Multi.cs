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
    class Multi : Comida.OnPingListener, Interface1
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
        private Serpiente[] _aSerpiente;
        private Timer timerJuego;
        private Comida comida;
        private int _tamaño;
        private int[] comidaCoor;
        private Boolean _hayFin;
        private int _player;
        private int[] _direccionSerpiente;
        public Boolean _block = false;
        private CNivel[] niveles;
        private CNivel nivelActual;
        private int _puntos;
        private int _numserpientes=2;
        private Random r = new Random(DateTime.Now.Millisecond);


        private OnPingListener cListener;
        public interface OnPingListener
        {
            void onColor(bool color);

        }
        public void setOnPingListener(OnPingListener listener)
        {
            cListener = listener;
        }





        public Multi(int tamaño,int opcion, int nivel /*, OnPingListener listener*/)
        {
//            setOnPingListener(listener);
            _aSerpiente = new Serpiente[_numserpientes];
            _direccionSerpiente = new int[_numserpientes];
            _tamaño = tamaño;
            comidaCoor = new int[2];
            timerJuego = new Timer();
            niveles = new CNivel[4];
            niveles[0].dificultad = 0;
            niveles[0].velocidad = 500;
            niveles[0].objetivo = 6;
            niveles[0].nivel = new Nivel(niveles[0].dificultad, niveles[0].velocidad, niveles[0].objetivo, _tamaño);
            niveles[1].dificultad = 1;
            niveles[1].velocidad = 400;
            niveles[1].objetivo = 12;
            niveles[1].nivel = new Nivel(niveles[1].dificultad, niveles[1].velocidad, niveles[1].objetivo, _tamaño);
            niveles[2].dificultad = 2;
            niveles[2].velocidad = 300;
            niveles[2].objetivo = 18;
            niveles[2].nivel = new Nivel(niveles[2].dificultad, niveles[2].velocidad, niveles[2].objetivo, _tamaño);
            niveles[3].dificultad = 3;
            niveles[3].velocidad = 200;
            niveles[3].objetivo = 10;
            niveles[3].nivel = new Nivel(niveles[3].dificultad, niveles[3].velocidad, niveles[3].objetivo, _tamaño);

                nivelActual = niveles[nivel];
            generarSerpiente();
            generarComida();

            timerJuego.Interval = nivelActual.velocidad;

            timerJuego.Elapsed += new ElapsedEventHandler(timerJuego_tick);
            timerJuego.Start();

        }

        //Transmite a serpiente la direccion actual
        public void cambiardireccion(int[] direccion)
        {
            for (int i = 0; i < _numserpientes;i++ )
                _aSerpiente[i].CambiarDireccion(direccion[i]);
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
            } while (nivelActual.nivel.buscarenTablero(x, y) || _aSerpiente[0].buscarenSerpiente(x,y,true)|| _aSerpiente[1].buscarenSerpiente(x,y,true));
          
       

            comida = new Comida(x, y);
            comida.setOnPingListener(this);
            comidaCoor[0] = comida.X;
            comidaCoor[1] = comida.Y;
        //    cListener.onColor(comida.EstaSenyal);
        }

        private void generarSerpiente()
        {
            
            int x, y;


            for (int i = 0; i < _numserpientes; i++)
            {


                do
                {
                    x = r.Next(1, (_tamaño - 1)/2 + i*(_tamaño-1)/2);
                    y = r.Next(1, _tamaño - 1);
                } while (nivelActual.nivel.buscarenTablero(x, y));

                if (!nivelActual.nivel.buscarenTablero(x + 1, y)) _direccionSerpiente[i] = 0;
                else if (!nivelActual.nivel.buscarenTablero(x, y + 1)) _direccionSerpiente[i] = 1;
                else if (!nivelActual.nivel.buscarenTablero(x - 1, y)) _direccionSerpiente[i] = 2;
                else if (!nivelActual.nivel.buscarenTablero(x, y - 1)) _direccionSerpiente[i] = 3;


                _aSerpiente[i] = new Serpiente(x, y, _direccionSerpiente[i]);
            }
        }


        //Metodo llamado en cada tick del timer, mueve la serpiente y comprueba si hay colisiones
        public void actualizar()
        {

             for (int i =0; i<_numserpientes;i++)
            _aSerpiente[i].Mover();
            for (int i =0; i<_numserpientes;i++){
            
            if (comida.buscarenComida(_aSerpiente[i].X, _aSerpiente[i].Y))
            {
                _aSerpiente[i].crecer(comida.Cantidad);
                generarPuntuacion(comida.Cantidad);
                generarComida();

            }

            if (_hayFin == false) _hayFin = nivelActual.nivel.buscarenTablero(_aSerpiente[i].X, _aSerpiente[i].Y);

            if (_hayFin == false) _hayFin = _aSerpiente[i].buscarenSerpiente(_aSerpiente[i].X, _aSerpiente[i].Y, false);
            
            }

            if (_hayFin == false) _hayFin = _aSerpiente[0].buscarenSerpiente(_aSerpiente[1].X, _aSerpiente[1].Y, true);
            if (_hayFin == false) _hayFin = _aSerpiente[1].buscarenSerpiente(_aSerpiente[0].X, _aSerpiente[0].Y, true);
        }
        //Busca si la posicion de la cabeza coincide con un nodo de la misma, del tablero o comida y acaba el juego o crea una nueva comida y crece



        Queue Interface1.getTablero()
        {
            return nivelActual.nivel.Tablero;
        }
        Queue Interface1.getSerpiente()
        {
            return _aSerpiente[_player].Cuerpo;
        }



        void Interface1.setDir(int dir)
        {
            _direccionSerpiente[_player] = dir;

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
        
        void Interface1.setPlayer(int player)
        {
            _player=player;
        }

       int Interface1.getPlayer()
        {
            return _player;
        }

        public void onPing()
        {




            Random r = new Random(DateTime.Now.Millisecond);
            int x, y;
            do
            {
                x = r.Next(1, _tamaño - 1);
                y = r.Next(1, _tamaño - 1);
            } while (nivelActual.nivel.buscarenTablero(x, y) || _aSerpiente[0].buscarenSerpiente(x, y, true) || _aSerpiente[0].buscarenSerpiente(x, y, true));

            comida.X = x;
            comida.Y = y;

            comidaCoor[0] = comida.X;
            comidaCoor[1] = comida.Y;

            if (!comida.EstaSenyal)
            {
                comida.EstaSenyal = true;
              //  cListener.onColor(comida.EstaSenyal);
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