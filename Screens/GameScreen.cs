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
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Defend_your_home.Screens
{
    public class GameScreen : Screen
    {
        //Fields
        Model nave;
        float aspectRatio;
        #region Properties
        #endregion

        #region Initialize
        public GameScreen()
            : base()
        {

        }

        public override void LoadContent()
        {
            nave = GameGlobals.content.Load<Model>("xwing");
            aspectRatio = GameGlobals.device.Viewport.AspectRatio;

        }

        #endregion

        #region Public Methods
        public override void Initialize()
        {

        }

        public override void Update()
        {
            KeyboardState teclado = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || teclado.IsKeyDown(Keys.Escape))
            {
                ScreenManager.TransitionTo("MainMenu", "BlackFade");
            }
            if (teclado.IsKeyDown(Keys.Right))
                modelPosition = new Vector3 ( modelPosition.X+2, modelPosition.Y, modelPosition.Z);
            if (teclado.IsKeyDown(Keys.Left))
                modelPosition = new Vector3(modelPosition.X - 2, modelPosition.Y, modelPosition.Z);
            if (teclado.IsKeyDown(Keys.Up))
                modelPosition = new Vector3(modelPosition.X, modelPosition.Y+2, modelPosition.Z);
            if (teclado.IsKeyDown(Keys.Down))
                modelPosition = new Vector3(modelPosition.X, modelPosition.Y-2, modelPosition.Z);
            modelRotation += (float)GameGlobals.gameTime.ElapsedGameTime.TotalMilliseconds *MathHelper.ToRadians(0.1f);
        }

        // Set the position of the model in world space, and set the rotation.
        Vector3 modelPosition = Vector3.Zero;
        float modelRotation = 0.0f;
        // Set the position of the camera in world space, for our view matrix.
        Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 1500.0f);

        public override void Draw()
        {
            //spriteBatch.Begin();
           
            //spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState);
            //spriteBatch.DrawString(GameGlobals.defaultFont, "Juego aun no implementado, chupe el boton exit para salir", new Vector2(200, 400), Color.BlanchedAlmond);
            //spriteBatch.End();

            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[nave.Bones.Count];
            nave.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in nave.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] *
                        Matrix.CreateRotationY(modelRotation)
                        * Matrix.CreateTranslation(modelPosition);
                    effect.View = Matrix.CreateLookAt(cameraPosition,
                        Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(45.0f), aspectRatio,
                        1.0f, 10000.0f);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
            //nave.Draw(Matrix.Identity, Matrix.Identity, Matrix.Identity);

        }
        #endregion

        #region Private Methods
        private void pintaDebug()
        {
            
        }
        
        #endregion
    }
}
