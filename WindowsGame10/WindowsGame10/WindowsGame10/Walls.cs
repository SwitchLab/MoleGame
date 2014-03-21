using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame10
{
    enum State
    {
        Empty,
        NotChange,
        Change,
        Come
    }

    class Wall
    {
        public State[] states;
        public Rectangle[] baseBelowRectangles, baseAboveRectangles;
        public Rectangle[] baseBelowRectanglesNow, baseAboveRectanglesNow;

        int animation;//1)E-C 2)C-CH 3)CH-C 4)C-NCH 5)CH-E 6)NCH-CH

        public Vector2 wallPosition;
       // Rectangle[] rectNow;
        static Random r = new Random();

        public Wall(int width, int height, Vector2 pos, State[] st)
        {
            wallPosition = pos;
            states = st;
            int y,x;
            
            baseBelowRectangles = new Rectangle[200];
            baseAboveRectangles = new Rectangle[200];
           // baseBelowRectanglesNow = new Rectangle[200];
            //baseAboveRectanglesNow = new Rectangle[200];

            for (int i = 0; i < baseBelowRectangles.Length; i++)
            {
                x = r.Next(width);
                y = r.Next(height);
                baseBelowRectangles[i] = new Rectangle((int)pos.X + x, (int)pos.Y+y, 10, 10);
                baseAboveRectangles[i] = new Rectangle((int)pos.X+x + 2,(int)pos.Y+ y + 2, 6, 6);
            }
           // baseAboveRectangles.CopyTo(baseAboveRectanglesNow, 0);
           // baseBelowRectangles.CopyTo(baseBelowRectanglesNow, 0);
           // if (st[0] == State.Come)
            //    for (int i = 0; i < baseAboveRectanglesNow.Length; i++)
             //   {
             //       baseAboveRectanglesNow[i].Height = 2;
             //       baseAboveRectanglesNow[i].Width = 2;
             //   }
        }
        /*
        public void ReState(int from, int to)
        {
            if (states[from] == State.Empty && states[to]==State.Come)
            {
                animation = 1;
            }
            if (states[from] == State.Come && states[to] == State.Change)
            {
                animation = 2;
            }
            if (states[from] == State.Change && states[to] == State.Come)
            {
                animation = 3;
            }
            if (states[from] == State.Come && states[to] == State.NotChange)
            {
                animation = 4;
            }
            if (states[from] == State.Change && states[to] == State.Empty)
            {
                animation = 5;
            }
            if (states[from] == State.NotChange && states[to] == State.Change)
            {
                animation = 6;
            }
        }*/

     /*    public void Update()
        {
            if (animation<80)
                if (animation % 10 == 2)
                {
                    animation += 10;
                    for (int i = 0; i < baseBelowRectanglesNow.Length; i++)
                    {
                        baseBelowRectanglesNow[i].Width = baseBelowRectanglesNow[i].Width + 2 < 10 ? baseBelowRectanglesNow[i].Width + 2 : 10;
                        baseBelowRectanglesNow[i].Height = baseBelowRectanglesNow[i].Height + 2 < 10 ? baseBelowRectanglesNow[i].Height + 2 : 10;
                        baseAboveRectanglesNow[i].Width = baseBelowRectanglesNow[i].Width + 1 < 6 ? baseBelowRectanglesNow[i].Width + 2 : 6;
                        baseAboveRectanglesNow[i].Height = baseBelowRectanglesNow[i].Height + 1< 6 ? baseBelowRectanglesNow[i].Height + 2 : 6;
                    }
                }
        }*/
    }
}
