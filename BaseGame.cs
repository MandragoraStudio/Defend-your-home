#region Using Statements
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
using Defend_your_home.Screens;
#endregion

namespace Defend_your_home
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BaseGame : Game
    {
        public BaseGame()
        {
            GameGlobals.graphicsManager = new GraphicsDeviceManager(this);
            GameGlobals.graphicsManager.PreferredBackBufferWidth = GameGlobals.Width;
            GameGlobals.graphicsManager.PreferredBackBufferHeight = GameGlobals.Height;
            GameGlobals.content = new ContentManager(Services);
            GameGlobals.content.RootDirectory = "Content";



#if WINDOWS_PHONE
            GameGlobals.graphicsManager.IsFullScreen = true;
#endif

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            //To test
            this.IsMouseVisible = true;

            //Assigned device
            GameGlobals.device = GameGlobals.graphicsManager.GraphicsDevice;

            //Start with LoadingScreen
            ScreenManager.AddScreen("Loading", new LoadingScreen());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            GameGlobals.defaultFont = GameGlobals.content.Load<SpriteFont>("GameFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GameGlobals.gameTime = gameTime;

            if (GameGlobals.isExiting)
                Exit();

            ScreenManager.CurrentScreen.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GameGlobals.device.Clear(Color.CornflowerBlue);

            ScreenManager.CurrentScreen.Draw();


            base.Draw(gameTime);
        }
    }
}
