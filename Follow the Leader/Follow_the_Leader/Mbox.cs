using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Follow_the_Leader
{
    public class Mbox
    {
        public static Texture2D Tex;

        public Rectangle Position = new Rectangle(0, 0, 32, 32);

        public void Update(MouseState ms)
        {
            Position.X = ms.X - 16;
            Position.Y = ms.Y - 16;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Tex, Position, Color.Red);
        }
    }
}
