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
#endregion

namespace Defend_your_home.Screens.Transitions
{
    public class Fade : Transition
    {
        //Fields
        Texture2D back;
        bool firstSection;
        Rectangle rectangle;
        Color color;
        bool initializeDestination;

        #region Initialize
        public Fade(Color transitionColor)
            : base()
        {
            color = transitionColor;
        }

        public override void LoadContent()
        {
            rectangle = new Rectangle(0, 0, GameGlobals.Width, GameGlobals.Height);

            back = new Texture2D(device, 1, 1);
            back.SetData<Color>(new Color[] { Color.White });
        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {
            time = TimeSpan.FromSeconds(1);
            firstSection = true;
            color.A = 0;
            initializeDestination = false;
        }

        public override void Update()
        {
            if (time > TimeSpan.FromSeconds(0.5f))
            {
                //Update Alpha
                float amount = (1000f / (float)(time.TotalMilliseconds)) - 1;
                if (amount > 1f)
                    amount = 1;

                color.A = (byte)MathHelper.Lerp(0, 255, amount);
            }
            else
            {
                if (!initializeDestination)
                {
                    initializeDestination = true;
                    destination.Initialize();
                }

                firstSection = false;

                //Update Alpha
                float amount = (500f / (float)(time.TotalMilliseconds)) - 1;
                if (amount > 1f)
                    amount = 1;

                color.A = (byte)MathHelper.Lerp(255, 0, amount);
            }

            base.Update();
        }

        public override void Draw()
        {
            if (firstSection)
                source.Draw();
            else
                destination.Draw();

            spriteBatch.Begin();
            spriteBatch.Draw(back, rectangle, color);
            spriteBatch.End();
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
