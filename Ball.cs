using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Pong
{
    class Ball : Sprite 
    {
        public GraphicsDeviceManager Graphics;
        public static float initSpeed = 200f;
        public float initSpeedX = initSpeed;
        public float initSpeedY = -initSpeed;

        public Ball(Texture2D texture) : base(texture)
        {
            SpeedX = initSpeedX;
            SpeedY = initSpeedY;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            // Sprite collision check
            foreach (Sprite sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 & this.IsTouchingRight(sprite)))
                    SpeedX = -SpeedX;
            }

            // Restart if ball goes out of bounds
            if (Position.X < 0 || Position.X > Graphics.PreferredBackBufferWidth)
            {
                Restart();
            }

            // Bounce back
            if (Position.Y > Graphics.PreferredBackBufferHeight - Rectangle.Height || Position.Y < 0)
            {
                SpeedY = -SpeedY;
            }

            Velocity.X = SpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity.Y = SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Velocity;
        }

        public void Restart()
        {
            List<float> speeds = new List<float> { -initSpeed, initSpeed };
            int rng = new Random().Next(speeds.Count);
            Position = new Vector2(Graphics.PreferredBackBufferWidth / 2, Graphics.PreferredBackBufferHeight / 2);
            SpeedX = speeds[rng];
            SpeedY = speeds[rng];
        }

    }
}
