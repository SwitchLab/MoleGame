using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame10
{
    struct Square {
        public bool leftWall;
        public bool rightWall;
        public bool aboveWall;
        public bool belowWall;
    }


    class BaseMap
    {
        public int layerNow;
        public Square[,,] array;

       public  BaseMap(int[,,] inArr) 
        {
            layerNow = 0;
            array = new Square[inArr.GetLength(0), inArr.GetLength(1), inArr.GetLength(2)];
            for (int l = 0; l < inArr.GetLength(0); l++)
                for (int i = 0; i < inArr.GetLength(1); i++)
                    for (int j = 0; j < inArr.GetLength(2); j++)
                    {
                        if ((inArr[l, i, j] & 8) == 8)
                            array[l, i, j].aboveWall = true;
                        if ((inArr[l, i, j] & 4) == 4)
                            array[l, i, j].belowWall = true;
                        if ((inArr[l, i, j] & 2) == 2)
                            array[l, i, j].leftWall = true;
                        if ((inArr[l, i, j] & 1) == 1)
                            array[l, i, j].rightWall = true;

                    }
        }


    }
}
