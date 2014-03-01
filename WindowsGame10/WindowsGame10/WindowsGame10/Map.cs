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
    class Map
    {
        public Map(BaseMap bm)
        {
            List<Wall> walls = new List<Wall>();
            for (int i = 0; i < bm.array.GetLength(1); i++)
                for (int j = 0; j < bm.array.GetLength(2); j++) 
                {
                    walls.Add(new Wall(20, 110, new Vector2(100 *i+90, 100 * j-5+160),
                        SetStates(new bool[] { bm.array[0, j, i].rightWall, bm.array[1, j, i].rightWall, bm.array[2, j, i].rightWall })));

                    walls.Add(new Wall(110, 20, new Vector2(100 * i-5, 100 * j+90+160),
                        SetStates(new bool[] { bm.array[0, j, i].belowWall, bm.array[1, j, i].belowWall, bm.array[2, j, i].belowWall })));
                }
            this.walls = walls.ToArray();
        }

        State[] SetStates(bool[] existWall)
        {
            State[] s=new State[existWall.Length];
            if (existWall[0])
                if (existWall[1])
                    if (existWall[2])
                    {
                        s[0] = State.NotChange;
                        s[1] = State.NotChange;
                        s[2] = State.NotChange;
                    }
                    else
                    {
                        s[0] = State.NotChange;
                        s[1] = State.Change;
                        s[2] = State.Come;
                    }
                else
                    if (existWall[2])
                    {
                        s[0] = State.Change;
                        s[1] = State.Come;
                        s[2] = State.NotChange;
                    }
                    else
                    {
                        s[0] = State.Change;
                        s[1] = State.Empty;
                        s[2] = State.Come;
                    }
            else
                if (existWall[1])
                    if (existWall[2])
                    {
                        s[0] = State.Come;
                        s[1] = State.NotChange;
                        s[2] = State.Change;
                    }
                    else
                    {
                        s[0] = State.Come;
                        s[1] = State.Change;
                        s[2] = State.Empty;
                    }
                else
                    if (existWall[2])
                    {
                        s[0] = State.Empty;
                        s[1] = State.Come;
                        s[2] = State.Change;
                    }
                    else
                    {
                        s[0] = State.Empty;
                        s[1] = State.Empty;
                        s[2] = State.Empty;
                    }
            return s;
        }

        public int stateIndexNow;
        Wall[] walls;
        Texture2D circle;

        public void Load(Texture2D circle)
        {
            this.circle = circle;
        }

        bool updateflag = false;
        public void Update()
        {
            stateIndexNow = (stateIndexNow + 1) % 3;
            /*if (Keyboard.GetState().IsKeyDown(Keys.A) && !updateflag)
            {
                stateIndexNow = (stateIndexNow + 1) % 3;
                updateflag = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.A))
            {
                updateflag = false;
            }*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            foreach (Wall w in walls)
                if (w.states[stateIndexNow] == State.NotChange ||
                    w.states[stateIndexNow] == State.Change)
                    foreach (Rectangle r in w.baseBelowRectangles)
                        spriteBatch.Draw(circle, r, Color.Black);
                else if (w.states[stateIndexNow] == State.Come)
                    foreach (Rectangle r in w.baseAboveRectangles)
                        spriteBatch.Draw(circle, new Rectangle(r.X, r.Y, 2, 2), Color.SandyBrown);

            /*           for (int i = 0; i < spritePositions.Length; i++)
                      {
                          spriteBatch.Draw(aboveCircle, spritePositions[i], Color.White);
              
                       }*/
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            /*           for (int i = 0; i < spritePositions.Length; i++)
                       {
                           spriteBatch.Draw(underCircle, spritePositions[i], Color.Black);
                       }*/
            foreach (Wall w in walls)
                if (w.states[stateIndexNow] == State.NotChange)
                    foreach (Rectangle r in w.baseAboveRectangles)
                        spriteBatch.Draw(circle, r, Color.Brown);
                else if (w.states[stateIndexNow] == State.Change)
                    foreach (Rectangle r in w.baseAboveRectangles)
                        spriteBatch.Draw(circle, r, Color.SandyBrown);
               // else if (w.states[stateIndexNow] == State.Come)
                //    foreach (Rectangle r in w.baseAboveRectangles)
                //        spriteBatch.Draw(circle, new Rectangle(r.X, r.Y, 2, 2), Color.SandyBrown);

            spriteBatch.End();
        }
    }
}
