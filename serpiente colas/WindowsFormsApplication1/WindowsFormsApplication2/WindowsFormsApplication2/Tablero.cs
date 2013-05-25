using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WindowsFormsApplication1
{
    class Tablero
    {

        /// <summary>
        /// Clase tablero que genera la cola donde almacena los puntos donde (Podria usarse Nodos para almacenar los puntos pero se usan arrays de pares)
        /// Se relaciona con juego  en 1 a 1
        /// 
        /// </summary>
        private Queue _mapa;
        private int _tamaño;

        public Tablero(int tamaño, int dificultad)
        {
            _tamaño = tamaño;
            _mapa = new Queue();

            generarNivel(dificultad);
        }

        public Queue Mapa
        {
            get { return _mapa; }

        }




        //Genera las paredes bases 
        public void generarNivel(int dificultad)
        {




            switch (dificultad)
            {
                case 0:
                    generarBase();


                    break;
                case 1:
                   // generarBase();
                    generarPuntos();

                    break;

                case 2:
                    generarBase();

                   

                    break;
                case 3:
                    generarBase();
                    generarPuntos();
                
                    break;


            }
        }


        private void generarBase()
        {
            int[] coordenadas = new int[2];

        
            _mapa.Enqueue(coordenadas);
            for (int i = 0; i < _tamaño; i++)
            {
                for (int j = 0; j < _tamaño; j++)
                {//ÑAPA
                    if (j == 0 || i == 0 || j == _tamaño - 2 || i == _tamaño - 1)
                    {
                        coordenadas = new int[2];
                        coordenadas[0] = i;
                        coordenadas[1] = j;
                        _mapa.Enqueue(coordenadas);
                    }
                }
            }

        }

        private void generarPuntos()
        {
            int[] coordenadas = new int[2];
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 15; i++)
            {
                coordenadas = new int[2];
                coordenadas[0] = r.Next(2, _tamaño - 2);
                coordenadas[1] = r.Next(2, _tamaño - 2);
                _mapa.Enqueue(coordenadas);
            }
        }


       
    }


}