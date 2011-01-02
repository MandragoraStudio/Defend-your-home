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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Defend_your_home.Interfaces;
#endregion

namespace Defend_your_home.UI
{
    public class Label : IGraphicsControl
    {
        //Fields
        protected string text;
        protected Vector2 textSize;
        protected SpriteFont font;
        protected Vector2 position = Vector2.Zero;
        protected Color color = Color.White;

        #region Properties
        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                textSize = font.MeasureString(text);
            }
        }

        protected SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }

        #endregion

        #region Initialize
        public Label(string text, SpriteFont font, Vector2 position)
        {
            Font = font;
            Text = text;
            Position = position;
        }

        #endregion

        #region Public Methods

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
