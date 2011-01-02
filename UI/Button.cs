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
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Defend_your_home.Interfaces;
#endregion

namespace Defend_your_home.UI
{
    public class Button : IGraphicsControl
    {
        //Fields
        protected bool pressed;
        protected string text;
        protected Vector2 textSize;
        protected SpriteFont font;
        protected Vector2 position = Vector2.Zero;
        protected Color tintColor = Color.BlueViolet;
        protected Color tintWhenTouched = Color.DarkGray;

        #region Events
        public event EventHandler Click;
        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
                Click.Invoke(this, e);
        }

        public event EventHandler TouchDown;
        protected virtual void OnTouchDown(EventArgs e)
        {
            if (TouchDown != null)
                TouchDown.Invoke(this, e);
        }

        #endregion

        #region Properties
        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Color Color
        {
            get { return tintColor; }
            set { tintColor = value; }
        }

        public Color TintColor
        {
            get { return pressed ? tintWhenTouched : tintColor; }
        }

        public virtual Rectangle Bounds
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)textSize.X, (int)textSize.Y); }
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
        public Button(string text, SpriteFont font, Vector2 position)
        {
            Font = font;
            Text = text;
            Position = position;
        }

        #endregion

        #region Public Methods
        public virtual void Update()
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            Vector2 touchPosition = Vector2.Zero;
            MouseState raton = Mouse.GetState();
            if (raton.LeftButton == ButtonState.Pressed)
            {
                touchPosition = new Vector2(raton.X, raton.Y);
            }

            if (touchCollection.Count > 0)
                touchPosition = touchCollection[0].Position;

            if (CheckIfFirstTouchDown(touchPosition))
            {
                DoOnTouchDown();
            }
            else if (CheckIfTouchRelease(touchPosition))
            {
                DoOnTouchRelease();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, TintColor);
        }

        #endregion

        #region Private Methods
        protected bool CheckIfFirstTouchDown(Vector2 touchPosition)
        {
            return !pressed && Bounds.Contains((int)touchPosition.X, (int)touchPosition.Y);
        }

        protected bool CheckIfTouchRelease(Vector2 touchPosition)
        {
            return pressed && touchPosition == Vector2.Zero;
        }

        protected virtual void DoOnTouchDown()
        {
            pressed = true;
            OnTouchDown(EventArgs.Empty);
        }

        protected virtual void DoOnTouchRelease()
        {
            pressed = false;
            OnClick(EventArgs.Empty);
        }

        #endregion
    }
}
