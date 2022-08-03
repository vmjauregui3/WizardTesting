using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class AnimatedSprite : Sprite
    {
        public int FrameCounter;
        public int SwitchFrame;
        public Vector2 CurrentFrame;
        public Vector2 AmountOfFrames;
        public bool IsActive;

        protected int frameWidth;
        public int FrameWidth
        {
            get
            {
                return frameWidth;
            }
        }
        protected int frameHeight;
        public int FrameHeight
        {
            get
            {
                return frameHeight;
            }
        }

        public AnimatedSprite(string path, Vector2 position) : base(path, position)
        {
            AmountOfFrames = Vector2.One;
            CurrentFrame = Vector2.Zero;
            SwitchFrame = 0;
            FrameCounter = 0;
        }

        public AnimatedSprite(string path, Vector2 position, Vector2 frameCount, int switchFrame) : base(path, position)
        {
            AmountOfFrames = frameCount;
            CurrentFrame = Vector2.Zero;
            SwitchFrame = switchFrame;
            FrameCounter = 0;

            if (Texture != null)
            {
                frameWidth = Texture.Width / (int)AmountOfFrames.X;
                frameHeight = Texture.Height / (int)AmountOfFrames.Y;
            }

            origin = new Vector2((int)FrameWidth / 2, (int)FrameHeight / 2);
            Dimensions = new Vector2((int)FrameWidth, (int)FrameHeight);
        }

        public AnimatedSprite(string path, Vector2 position, float scale, Vector2 frameCount, int switchFrame) : base(path, position)
        {
            AmountOfFrames = frameCount;
            CurrentFrame = Vector2.Zero;
            SwitchFrame = switchFrame;
            FrameCounter = 0;

            if (Texture != null)
            {
                frameWidth = Texture.Width / (int)AmountOfFrames.X;
                frameHeight = Texture.Height / (int)AmountOfFrames.Y;
            }

            origin = new Vector2((int)FrameWidth / 2, (int)FrameHeight / 2);
            dimensions = new Vector2((int)FrameWidth, (int)FrameHeight);
            Scale = scale;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (IsActive)
            {
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (FrameCounter >= SwitchFrame)
                {
                    FrameCounter = 0;
                    CurrentFrame.X++;

                    if (CurrentFrame.X * FrameWidth >= Texture.Width)
                    { CurrentFrame.X = 0; }
                }
            }
            else
            { CurrentFrame.X = 0; }

            sourceRect = new Rectangle((int)CurrentFrame.X * FrameWidth,
                (int)CurrentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
        }
    }
}
