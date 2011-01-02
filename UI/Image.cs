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
    public class Image : IGraphicsControl
    {
        //Fields
        protected Texture2D texture;
        protected Vector2 position = Vector2.Zero;
        protected Color tintColor = Color.White;

        #region Properties
        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Color TintColor
        {
            get { return tintColor; }
            set { tintColor = value; }
        }

        #endregion

        #region Initialize
        public Image(string assetName, Vector2 position)
        {
            texture = GameGlobals.content.Load<Texture2D>(assetName);
            Position = position;
        }
        #endregion

        #region Public Methods
        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, tintColor);
        }

        #endregion

        #region Private Methods
        #endregion
    }
}
