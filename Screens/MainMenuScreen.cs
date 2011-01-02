#region File Description
//-----------------------------------------------------------------------------
// Javier Cantón Ferrero
// javiercantonferrero@gmail.com
// http://geeks.ms/blogs/jcanton/
// http://xnacommunity.codeplex.com
//
// MVP XNA/DirectX
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Defend_your_home.UI;
using Defend_your_home.Interfaces;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Defend_your_home.Screens
{
    public class MainMenuScreen : Screen
    {
        //Fields
        List<IGraphicsControl> controls;
        Texture2D fondo;

        #region Properties
        #endregion

        #region Initialize
        public MainMenuScreen()
            : base()
        {
            controls = new List<IGraphicsControl>();

            Vector2 middleScreen = new Vector2(GameGlobals.Width / 2, GameGlobals.Height / 2);
            int offset = 50;

            //Title label
            string titleText = "Main Menu";
            Vector2 titleSize = GameGlobals.defaultFont.MeasureString(titleText);
            Label title = new Label(titleText, GameGlobals.defaultFont,
                new Vector2(middleScreen.X - titleSize.X / 2, 30));
            title.Color = Color.Red;

            //play button
            string playText = "Play Game";
            Vector2 playSize = GameGlobals.defaultFont.MeasureString(playText);
            Button play = new Button(playText, GameGlobals.defaultFont,
                new Vector2((middleScreen.X - playSize.X / 2), (middleScreen.Y + offset - playSize.Y / 2) - 50));
            play.Click += new EventHandler(play_Click);

            //exit button
            offset += 60;
            string exitText = "Exit";
            Vector2 exitSize = GameGlobals.defaultFont.MeasureString(exitText);
            Button exit = new Button("Exit", GameGlobals.defaultFont,
                new Vector2(middleScreen.X - exitSize.X / 2,( middleScreen.Y + offset - exitSize.Y / 2)+20));
            exit.Click += new EventHandler(delegate { GameGlobals.isExiting = true; });

            //Add controls
            controls.Add(title);
            controls.Add(play);
            controls.Add(exit);
        }

        public override void LoadContent()
        {

            //fondo = GameGlobals.content.Load<Texture2D>("mesa");
        }

        #endregion

        #region Public Methods
        public override void Initialize()
        {

        }

        public override void Update()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                GameGlobals.isExiting = true;

            //Update all controls
            foreach (IGraphicsControl c in controls)
                c.Update();
        }

        public override void Draw()
        {
            spriteBatch.Begin();
            //spriteBatch.DrawString(GameGlobals.defaultFont, "Main Menu", new Vector2(310, 30), Color.Red);

            //Draw all controls
            foreach (IGraphicsControl c in controls)
                c.Draw(spriteBatch);

            spriteBatch.End();
        }
        #endregion

        #region Private Methods
        private void play_Click(object sender, EventArgs e)
        {
            ScreenManager.TransitionTo("PlayGame", "BlackFade");
        }

        #endregion
    }
}
