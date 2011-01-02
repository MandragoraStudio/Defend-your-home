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

namespace Defend_your_home.Screens.Transitions
{
    public class Transition : Screen
    {
        //Fields
        protected IScreen source;
        protected IScreen destination;
        protected TimeSpan time;

        #region Properties
        public IScreen Source
        {
            get { return source; }
            set { source = value; }
        }

        public IScreen Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        #endregion

        #region Initialize
        public Transition()
            : base()
        {

        }

        public override void LoadContent()
        {

        }
        #endregion

        #region Public Methods
        public override void Initialize()
        {

        }

        public override void Update()
        {
            time -= GameGlobals.gameTime.ElapsedGameTime;

            if (time < TimeSpan.Zero)
                ScreenManager.CurrentScreen = destination;
        }

        public override void Draw()
        {

        }
        #endregion

        #region Private Methods

        #endregion
    }
}
