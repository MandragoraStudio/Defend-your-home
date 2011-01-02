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
using Defend_your_home.Interfaces;
using Defend_your_home.Screens.Transitions;
#endregion

namespace Defend_your_home.Screens
{
    public class ScreenManager
    {
        //Statics
        public static IScreen CurrentScreen;

        //Fields
        private static Dictionary<string, IScreen> screens;

        #region Properties

        #endregion

        #region Initialize
        static ScreenManager()
        {
            screens = new Dictionary<string, IScreen>();
        }

        #endregion

        #region Public Methods
        public static void AddScreen(string name, IScreen newScreen)
        {
            newScreen.LoadContent();
            screens.Add(name, newScreen);

            if (CurrentScreen == null)
            {
                CurrentScreen = newScreen;
                CurrentScreen.Initialize();
            }
        }

        public static void TransitionTo(string nextScreen)
        {
            IScreen screen = screens[nextScreen];
            CurrentScreen = screen;
            CurrentScreen.Initialize();
        }

        public static void TransitionTo(string nextScreen, string transition)
        {
            Transition currentTransition = (Transition)screens[transition];
            currentTransition.Source = CurrentScreen;

            currentTransition.Destination = screens[nextScreen];

            currentTransition.Initialize();
            CurrentScreen = currentTransition;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}
