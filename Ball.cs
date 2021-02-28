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

        public Ball(Texture2D texture) : base(texture)
        {
            SpeedY = 100;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Velocity.X = SpeedX * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity.Y = SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (Sprite sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if ((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) ||
                    (this.Velocity.X < 0 & this.IsTouchingRight(sprite)))
                    SpeedX = -SpeedX;
            }

            if (this.Position.Y > Graphics.PreferredBackBufferHeight - this.Rectangle.Height)
                SpeedY = -100;
            if (this.Position.Y <= 0)
                SpeedY = 100;

            if (this.Position.X <= 0 || this.Position.X >= Graphics.PreferredBackBufferWidth)
            {
                Position.X = Graphics.PreferredBackBufferWidth / 2;
                Position.Y = Graphics.PreferredBackBufferHeight / 2;
            }
                
            Position += Velocity;
            Velocity = Vector2.Zero;
            base.Update(gameTime, sprites);
        }

    }
}
