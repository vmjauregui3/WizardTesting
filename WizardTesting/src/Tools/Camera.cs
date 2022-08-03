using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace WizardTesting
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        private Vector2 centerPosition;

        private static Camera instance;
        public static Camera Instance
        {
            get
            {
                if (instance == null)
                { 
                    instance = new Camera(); 

                }
                return instance;
            }
        }

        private Camera()
        {
            centerPosition = Vector2.Zero;
        }

        public void FollowSprite(Sprite target)
        {
            if (centerPosition.X - target.Position.X < -(int)(0.1 * WizardTesting.GameWidth))
            { centerPosition.X = target.Position.X - (int)(0.1 * WizardTesting.GameWidth); }
            else if (centerPosition.X - target.Position.X > (int)(0.1 * WizardTesting.GameWidth))
            { centerPosition.X = target.Position.X + (int)(0.1 * WizardTesting.GameWidth); }

            if (centerPosition.Y - target.Position.Y < -(int)(0.1 * WizardTesting.GameHeight))
            { centerPosition.Y = target.Position.Y - (int)(0.1 * WizardTesting.GameHeight); }
            else if (centerPosition.Y - target.Position.Y > (int)(0.1 * WizardTesting.GameHeight))
            { centerPosition.Y = target.Position.Y + (int)(0.1 * WizardTesting.GameHeight); }

            UpdatePosition(centerPosition);
        }

        public void Follow(Sprite target)
        {
            Vector2 centerPosition = target.Position;

            var position = Matrix.CreateTranslation(
                -target.Position.X - target.Origin.X,
                -target.Position.Y - target.Origin.Y,
                0);

            var offset = Matrix.CreateTranslation(
                WizardTesting.GameWidth / 2,
                WizardTesting.GameHeight / 2,
                0);

            Transform = position * offset;
        }

        public void UpdatePosition(Vector2 targetPosition)
        {
            var position = Matrix.CreateTranslation(
                -targetPosition.X,
                -targetPosition.Y,
                0);

            var offset = Matrix.CreateTranslation(
                WizardTesting.GameWidth / 2,
                WizardTesting.GameHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}
