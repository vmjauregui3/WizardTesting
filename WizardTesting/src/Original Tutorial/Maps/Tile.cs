using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class Tile
    {
        /*
        Vector2 position;
        Rectangle sourceRect;
        string state;

        public Rectangle SourceRect
        {
            get { return sourceRect; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void LoadContent(Vector2 position, Rectangle sourceRect, string state)
        {
            this.position = position;
            this.sourceRect = sourceRect;
            this.state = state;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime, ref Player wizard)
        {
            if(state == "Solid")
            {
                Rectangle tileRect = new Rectangle((int)Position.X, (int)Position.Y,
                    sourceRect.Width, sourceRect.Height);
                Rectangle playerRect = new Rectangle((int)wizard.Image.Position.X, (int)wizard.Image.Position.Y,
                    (int)wizard.Image.SourceRect.Width, (int)wizard.Image.SourceRect.Height);
            
                if(playerRect.Intersects(tileRect))
                {
                    
                    if (wizard.Velocity.X < 0)
                    {
                        wizard.Image.Position.X -= wizard.Velocity.X;
                    }
                    else if (wizard.Velocity.X > 0)
                    {
                        wizard.Image.Position.X -= wizard.Velocity.X;
                    } 

                    if (wizard.Velocity.Y < 0)
                    {
                        wizard.Image.Position.Y -= wizard.Velocity.Y;
                    }
                    else if (wizard.Velocity.Y > 0)
                    {
                        wizard.Image.Position.Y -= wizard.Velocity.Y;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
        */
    }
}
