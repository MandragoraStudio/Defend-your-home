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
#endregion

namespace Defend_your_home.Interfaces
{
    public interface IScreen
    {
        void LoadContent();
        void Initialize();
        void Update();
        void Draw();
    }
}
