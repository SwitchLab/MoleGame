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
            Content.RootDirectory = "Content";
            bm = new BaseMap(new int[3, 7, 7] { { { 14, 8, 8, 13, 11, 10, 9 }, { 11, 6, 5, 14, 0, 5, 3 }, { 2, 9, 14, 8, 4, 12, 5 }, { 2, 0, 8, 0, 8, 12, 9 }, { 2, 4, 5, 3, 3, 14, 1 }, { 3, 10, 12, 5, 7, 11, 7 }, { 6, 4, 12, 12, 12, 4, 13 } }, { { 10, 8, 9, 15, 10, 12, 13 }, { 7, 2, 1, 11, 7, 11, 11 }, { 15, 6, 5, 3, 10, 5, 3 }, { 11, 15, 10, 1, 7, 10, 1 }, { 3, 10, 1, 6, 8, 1, 3 }, { 2, 4, 1, 14, 0, 1, 7 }, { 6, 13, 7, 15, 6, 4, 13 } }, { { 14, 8, 12, 12, 12, 13, 11 }, { 10, 4, 9, 10, 8, 13, 3 }, { 3, 14, 4, 0, 5, 15, 7 }, { 6, 9, 15, 6, 8, 13, 11 }, { 14, 0, 13, 10, 0, 13, 3 }, { 15, 7, 10, 0, 5, 15, 3 }, { 14, 12, 4, 4, 12, 12, 5 } } });
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
