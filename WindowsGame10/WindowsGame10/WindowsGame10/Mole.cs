using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame10
{
    class Mole
    {
        Texture2D mole_right;
        Texture2D mole_left;

        public int posX=0;
        public int posY=6;
        public bool movingDown = false;
        public bool movingUp = false;
        public bool movingRight = false;
        public bool movingLeft = false;
        public bool moving = false;
        public bool left=false;
        public bool right=true;

       public  void Load(Texture2D mole_right, Texture2D mole_left)
        {
            this.mole_right = mole_right;
            this.mole_left = mole_left;
        }

       public void Draw(SpriteBatch spriteBatch)
       {
           spriteBatch.Begin();
           if (right)
               spriteBatch.Draw(mole_right, rec, Color.White);
           if (left)
               spriteBatch.Draw(mole_left, rec, Color.White);
           spriteBatch.End();
       }
       
        public Rectangle rec = new Rectangle(30,780,50,70);
        public void MoveDown()
        {
            rec.Y += 4;
            
        }
        public void MoveUp()
        {
            rec.Y -= 4;
            
        }
        public void MoveRight()
        {
            rec.X += 4;

        }
        public void MoveLeft()
        {
            rec.X -= 4;

        }
    }
}
