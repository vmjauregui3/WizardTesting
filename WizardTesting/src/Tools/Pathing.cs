using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WizardTesting
{
    public static class Pathing
    {
        public static float GetDistance(Vector2 pos, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        /*
        public static Vector2 RadialMovement(Vector2 pos, Vector2 target, float speed)
        {
            float distance = GetDistance(pos, target);

            if (distance <= speed)
            {
                return target - pos;
            }
            else
            {
                return (target - pos) * speed / distance;
            }
        }
        */

        public static Vector2 DirectionToward(Vector2 pos, Vector2 target)
        {
            Vector2 direction = Vector2.Zero;
            direction = target - pos;
            direction.Normalize();
            return direction;
        }

        public static Vector2 OrbitToward(Vector2 pos, Vector2 target, float orbitDis, float orbitAngle)
        {
            Vector2 targetDestination = new Vector2( (float)(target.X + orbitDis * Math.Cos(orbitAngle)), (float)(target.Y + orbitDis * Math.Sin(orbitAngle)));
            Vector2 direction = DirectionToward(pos, targetDestination);
            return direction;
        }

        public static float RotateTowards(Vector2 pos, Vector2 target)
        {
            float h, sineTheta, angle;
            if (pos.Y - target.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
                sineTheta = (float)(Math.Abs(pos.Y - target.Y) / h); //* ((item.Pos.Y-focus.Y)/(Math.Abs(item.Pos.Y-focus.Y))));
            }
            else
            {
                h = pos.X - target.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagonial lines here.
            //Quadrant 2
            if (pos.X - target.X > 0 && pos.Y - target.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            //Quadrant 3
            else if (pos.X - target.X > 0 && pos.Y - target.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            //Quadrant 1
            else if (pos.X - target.X < 0 && pos.Y - target.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (pos.X - target.X < 0 && pos.Y - target.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (pos.X - target.X > 0 && pos.Y - target.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (pos.X - target.X < 0 && pos.Y - target.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (pos.X - target.X == 0 && pos.Y - target.Y > 0)
            {
                angle = (float)0;
            }
            else if (pos.X - target.X == 0 && pos.Y - target.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }

    }
}
