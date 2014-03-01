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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        BaseMap bm;
        Map map;
        Texture2D soil;
        Mole mole;

        //ContentManager content;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            bm = new BaseMap(new int[3, 7, 7]{{{14, 8, 8, 12, 13, 10, 9}, {14, 0, 0, 9, 15, 3, 7}, {15, 2, 1, 7, 11, 2, 9}, {11, 7, 7, 14, 4, 0, 1}, {2, 9, 10, 8, 9, 2, 5}, {3, 6, 5, 3, 3, 2, 9}, {6, 13, 14, 5, 7, 6, 5}}, {{15, 15, 15, 14, 12, 8, 13}, {10, 13, 10, 9, 10, 4, 13}, {2, 12, 0, 4, 4, 8, 9}, {7, 14, 0, 13, 10, 4, 1}, {14, 13, 6, 8, 5, 10, 1}, {14, 8, 9, 7, 15, 7, 7}, {14, 5, 7, 15, 15, 14, 13}}, {{15, 14, 13, 10, 13, 15, 15}, {11, 14, 8, 5, 15, 10, 9}, {7, 14, 1, 15, 10, 4, 5}, {14, 13, 7, 15, 3, 10, 9}, {14, 9, 15, 15, 3, 7, 3}, {10, 1, 11, 15, 6, 12, 1}, {6, 5, 6, 12, 12, 12, 5}}});
            map = new Map(bm);
            mole = new Mole();
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();  
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map.Load(Content.Load<Texture2D>("circle"));
            soil = Content.Load<Texture2D>("backC");
            mole.Load(Content.Load<Texture2D>("mole_right"), Content.Load<Texture2D>("mole_left"));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            
            if(
            (!bm.array[map.stateIndexNow,mole.posY,mole.posX].belowWall&&UpdateCases.CaseDown(mole))||
            (!bm.array[map.stateIndexNow, mole.posY, mole.posX].aboveWall&&UpdateCases.CaseUp(mole)) ||
            (!bm.array[map.stateIndexNow,mole.posY,mole.posX].rightWall&&UpdateCases.CaseRight(mole))||
            (!bm.array[map.stateIndexNow,mole.posY,mole.posX].leftWall&&UpdateCases.CaseLeft(mole)))
                map.Update();

            // TODO: Add your update logic here
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGoldenrodYellow);
            spriteBatch.Begin();
           spriteBatch.Draw(soil, Vector2.Zero, Color.White);
            spriteBatch.End();

            map.Draw(spriteBatch);

            mole.Draw(spriteBatch);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
