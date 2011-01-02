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
using Defend_your_home.Interfaces;
#endregion

namespace Defend_your_home.Screens
{
    public class Screen : IScreen
    {
        //Fields
        protected GraphicsDevice device;
        protected SpriteBatch spriteBatch;

        #region Properties

        #endregion

        #region Initialize
        public Screen()
        {
            device = GameGlobals.graphicsManager.GraphicsDevice;
            spriteBatch = new SpriteBatch(device);
        }

        #endregion

        #region Public Methods
        public virtual void LoadContent()
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }

        #endregion

        #region Private Methods

        #endregion
    }
}
