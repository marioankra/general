using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace WindowsFormsApplication1
{
    interface Interface1
    {
        void setDir(int dir);
         int  getTamaño();
         int[] getComida();
         int getCantidadComida();
         Boolean getHayFin();
         void setHayFin(bool hayfin);
         Queue getTablero();
         Queue getSerpiente();
         int getPuntuacion();
         int getObjetivo();
         void setPlayer(int player);
         int getPlayer();
         int getnumPlayer();
    }
}
