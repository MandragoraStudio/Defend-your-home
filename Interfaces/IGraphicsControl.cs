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
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Defend_your_home.Interfaces
{
    public interface IGraphicsControl
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
