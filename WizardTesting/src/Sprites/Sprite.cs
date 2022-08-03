using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace WizardTesting
{
    public class Sprite
    {
        public Vector2 Position;
        protected Vector2 dimensions;
        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }
        protected float scale;
        public float Scale
        {
            get { return scale; }
            set 
            { 
                scale = value;
                Dimensions = dimensions * scale;
            }
        }

        protected Texture2D Texture;
        protected Rectangle sourceRect;
        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        public float Rotation;

        public Color Tint;

        protected Vector2 origin;
        public Vector2 Origin
        { 
            get { return origin; } 
        }

        public Sprite(string path, Vector2 position)
        {
            Texture = WizardTesting.WContent.Load<Texture2D>(path);
            sourceRect = new Rectangle(0, 0, (int)Texture.Bounds.Width, (int)Texture.Bounds.Height);
            origin = new Vector2((int)Texture.Bounds.Width / 2, (int)Texture.Bounds.Height / 2);
            dimensions = new Vector2((int)Texture.Bounds.Width, (int)Texture.Bounds.Height);

            Position = position;
            Scale = 1f;
            Rotation = 0.0f;
            Tint = Color.White;
        }

        public Sprite(string path, Vector2 position, float scale)
        {
            Texture = WizardTesting.WContent.Load<Texture2D>(path);
            sourceRect = new Rectangle(0, 0, (int)Texture.Bounds.Width, (int)Texture.Bounds.Height);
            origin = new Vector2((int)Texture.Bounds.Width / 2, (int)Texture.Bounds.Height / 2);
            dimensions = new Vector2((int)Texture.Bounds.Width, (int)Texture.Bounds.Height);

            Position = position;
            Scale = scale;
            Rotation = 0.0f;
            Tint = Color.White;
        }

        public Sprite(string path, Vector2 position, Vector2 dimensions, Vector2 origin)
        {
            Texture = WizardTesting.WContent.Load<Texture2D>(path);
            sourceRect = new Rectangle(0, 0, (int)Texture.Bounds.Width, (int)Texture.Bounds.Height);
            this.origin = origin;
            this.dimensions = dimensions;

            Position = position;
            Scale = 1f;
            Rotation = 0.0f;
            Tint = Color.White;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Dimensions.X, (int)Dimensions.Y),
                sourceRect, Tint, Rotation, Origin, SpriteEffects.None, 0.0f);
        }
    }
}
