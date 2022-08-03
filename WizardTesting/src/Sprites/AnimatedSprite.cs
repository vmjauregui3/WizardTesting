using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WizardTesting
{
    public class AnimatedSprite : Sprite
    {
        // AnimatedSprites are special variants of Sprites that change over time with and animation.
        // The spritesheets used must progress left to right for this to function.

        // ASprites have a spritesheet, so the current frame, amount of frames, and time between switch needs to be recorded.
        public int FrameCounter;
        public int SwitchFrame;
        public Vector2 CurrentFrame;
        public Vector2 AmountOfFrames;
        // The animation can be halted by turning off the ASprite activity.
        public bool IsActive;

        // The size of the frames is used for determining the which portion of the image to print.
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

        // This constructor is used when the ASprite is not initially going to be animated but could be later.
        public AnimatedSprite(string path, Vector2 position) : base(path, position)
        {
            AmountOfFrames = Vector2.One;
            CurrentFrame = Vector2.Zero;
            SwitchFrame = 0;
            FrameCounter = 0;
        }

        // This is the primary constructor that makes ASprites animate.
        // It requires initial information about the spritesheet to properly animate: the framecount and time to switch.
        public AnimatedSprite(string path, Vector2 position, Vector2 frameCount, int switchFrame) : base(path, position)
        {
            AmountOfFrames = frameCount;
            CurrentFrame = Vector2.Zero;
            SwitchFrame = switchFrame;
            FrameCounter = 0;

            // The dimensions of the image is calculated by dividing the image size by the sive of the spritesheet.
            if (Texture != null)
            {
                frameWidth = Texture.Width / (int)AmountOfFrames.X;
                frameHeight = Texture.Height / (int)AmountOfFrames.Y;
            }
            Dimensions = new Vector2((int)FrameWidth, (int)FrameHeight);

            // The origin is found by calculating the center of a frame. 
            origin = new Vector2((int)FrameWidth / 2, (int)FrameHeight / 2);
        }

        // This constructor functions the same as the primary except that it scales the image.
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

        // Update overrides the base Sprite's update to animate the image.
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // The ASprite updates only while active.
            if (IsActive)
            {
                // When time has elapsed to update the frame, it progresses the frame to the right.
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (FrameCounter >= SwitchFrame)
                {
                    FrameCounter = 0;
                    CurrentFrame.X++;

                    // It loops when there is no further frame.
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
