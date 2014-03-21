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

        private const int StartPositionX = 0;
        private const int StartPositionY = 6;

        public int posX;
        public int posY;
        public bool movingDown;
        public bool movingUp;
        public bool movingRight;
        public bool movingLeft;
        public bool moving;
        public bool left;
        public bool right; 
        public Rectangle rec;
        

        private void InitializeAll()
        {
            posX = StartPositionX;
            posY = StartPositionY;
            movingDown = false;
            movingUp = false;
            movingRight = false;
            movingLeft = false;
            moving = false;
            left = false;
            right = true;
            rec = new Rectangle(20 + 400, 692, 70, 83);
        }

        public Mole()
        {
            InitializeAll();
        }

        public void Reset()
        {
            InitializeAll();
        }

        public void Load(Texture2D mole_right, Texture2D mole_left)
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
