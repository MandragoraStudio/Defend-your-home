#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
#endregion

public class GameGlobals
{
    public static GraphicsDeviceManager graphicsManager;
    public static GraphicsDevice device;
    public static ContentManager content;
    public static SpriteFont defaultFont;
    public static GameTime gameTime;
    public static int Width = 1280;
    public static int Height = 800;
    public static bool isExiting;
}