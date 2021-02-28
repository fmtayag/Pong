using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Texture2D playerTexture = Content.Load<Texture2D>("Paddle");
            Texture2D ballTexture = Content.Load<Texture2D>("Ball");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture)
                {
                    Position = new Vector2(50,50),
                    Color = Color.White,
                    SpeedY = 300f,
                    Input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S
                    }
                },
                new Player(playerTexture)
                {
                    Position = new Vector2(_graphics.PreferredBackBufferWidth - 50, _graphics.PreferredBackBufferHeight - 150),
                    Color = Color.White,
                    SpeedY = 300f,
                    Input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down
                    }
                },
                new Ball(ballTexture)
                {
                    Position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                    Color = Color.White,
                    SpeedX = -200f,
                    Graphics = _graphics
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (Sprite sprite in _sprites)
                sprite.Update(gameTime, _sprites); 
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Sprite sprite in _sprites)
                sprite.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
