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
        // Sprites will be the visible representation of objects in the game.

        // Sprites have a position in the gameworld and occupy an area with their dimensions and scale.
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

        // Sprites' Textures are what is seen by the users. The sourceRect is what portion of the png is shown.
        protected Texture2D Texture;
        protected Rectangle sourceRect;
        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        // Sprite Rotation and Tint are used to change its appearance to the user.
        public float Rotation;
        public Color Tint;

        // Sprite origin is the center of the image being drawn.
        protected Vector2 origin;
        public Vector2 Origin
        { 
            get { return origin; } 
        }

        // This constructor is used for creating generic copies of a sprite into the game.
        // The path is the route to the image in the save file. The position is the gameworld position.
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

        // This constructor is used for creating sprites whose scale is different than the original image.
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

        // This constructor is used for creating sprites whose origin is not in the center of the image.
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

        // Update is for updating the image should it need to be change. This is mostly used for inheritance.
        public virtual void Update(GameTime gameTime)
        {

        }

        // Draw instructs the game how to draw the image into the game.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Dimensions.X, (int)Dimensions.Y),
                sourceRect, Tint, Rotation, Origin, SpriteEffects.None, 0.0f);
        }
    }
}
