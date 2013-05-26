                               using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    class Serpiente
    {
       /// <summary>
       /// Serpiente es la clase encargada de almacenar las posiciones de los nodos, mover y crecer
       /// Esta relacionada con juego a 1 a 1 y con nodo de forma 1 a N
       /// direccion empieza por 0 (derecha ) y continua en el sentido de las agujas del reloj
       /// cantidadCrecer alamacena cuanto debe de crecer la serpiente (no confundir con cantidad comida)
       /// X e Y almacenan las posiciones de la cabeza de la serpiente (aunque estan contenidas en la cola)
       /// </summary>
     
        private int _x, _y ,_direccion;
        private Queue _cuerpoSerpiente = new Queue();
        private int _cantidadCrecer = 0;
        

       //Constructor de serpiente, sigue la misma filosofia que comida para no empezar en una zona ocupada
        public Serpiente(int x, int y, int direccion)
        {
            _direccion = direccion;
            _x = x;
            _y = y;
            _cuerpoSerpiente.Enqueue(new Nodo(_x, _y));
             }




        //Calcula cuantos nodos debe crecer
        public void crecer(int cantidad) {
            _cantidadCrecer = _cantidadCrecer + cantidad;
        }

      

        //Cambia la direccion de la serpiente evitando que cambie a la direccion opuesta
        public void CambiarDireccion(int direccion) {
            if ((_direccion+2)%4 != direccion )
                _direccion = direccion;
        }

        //Se encarga del movimiento de la serpiente en funcion de la direccion, 
        // Se calcula a donde debe moverse y se añade un nodo a el cuerpo con esas posiciones
        //Si no debe crecer se desencola y en caso contrario se disminuye cantidadCrecer
        public void Mover() {
           
            switch (_direccion)
            {
                case 0:
                    _x++;
                    break;
                case 3:
                    _y--;
                    break;
                case 2:
                    _x--;
                    break;
                case 1:
                    _y++;
                    break;


            }
            _cuerpoSerpiente.Enqueue(new Nodo(_x, _y));
            
            if (_cantidadCrecer == 0)
                _cuerpoSerpiente.Dequeue();
            else
                _cantidadCrecer--;
            
             
        }

        public Queue Cuerpo
        {
            get { return _cuerpoSerpiente; } 
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }     
        }

        public bool buscarenSerpiente(int x, int y, bool enCabeza)
        {
            bool estaSerpiente= false;
            Nodo n;
            int numColision = 0;
            System.Collections.IEnumerator ent = _cuerpoSerpiente.GetEnumerator();
         
            if (enCabeza == true) {
            while (ent.MoveNext() && !estaSerpiente)
            {
               n = (Nodo)ent.Current;
                if (n.X == x && n.Y == y)
                    estaSerpiente = true;
            }
        }
            else
            {
               
                while (ent.MoveNext() && !estaSerpiente)
                {
                    n = (Nodo)ent.Current;
                    if (n.X == x && n.Y == y)
                        numColision++;
                     
                       
                }
                if (numColision == 2)
                    estaSerpiente = true;
            }

            return estaSerpiente;
        }
    
    }        
}
