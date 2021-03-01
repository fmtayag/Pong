using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Pong
{
    public class Player : Sprite
    {
        public GraphicsDeviceManager Graphics;

        public Player(Texture2D texture) : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move(gameTime);

            Position += Velocity;
            Velocity = Vector2.Zero;

            base.Update(gameTime, sprites);
        }

        private void Move(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (Position.Y < 0)
            {
                Position.Y = 0;
            }
            else if (Position.Y > Graphics.PreferredBackBufferHeight - Rectangle.Height)
            {
                Position.Y = Graphics.PreferredBackBufferHeight - Rectangle.Height;
            }

            if (kstate.IsKeyDown(Input.Up))
                Velocity.Y -= SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (kstate.IsKeyDown(Input.Down))
                Velocity.Y += SpeedY * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
    }

}
