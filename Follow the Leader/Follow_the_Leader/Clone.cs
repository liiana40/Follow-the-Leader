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
    public class Clone
    {
        public static Texture2D Tex;
        public Rectangle Position = new Rectangle(0, 0, 32, 32);
        int x, y, d;

        int id;
        static int nextid = 0;
        
        public Clone(int i)
        {
            id = nextid++;

            Position.X = i * 64;
        }
        public void Update(List<Clone> clone, Mbox mbox)
        {
            foreach (var Clones in clone)
            {
                if (Clones == this) continue;
                x = Position.Center.X - Clones.Position.Center.X;
                y = Position.Center.Y - Clones.Position.Center.Y;
                d = x * x + y * y;
                if (d > 0)
                {
                    Position.X += Math.Sign(x) * 10000 / d;
                    Position.Y += Math.Sign(y) * 10000 / d;
                }
            }
            if (id == 0)
            {
                x = Position.Center.X - mbox.Position.Center.X;
                y = Position.Center.Y - mbox.Position.Center.Y;
                d = x * x + y * y;
                if (d > 256)
                {
                    Position.X -= x / 32;
                    Position.Y -= y / 32;
                    Position.X += Math.Sign(x) * 5000 / d;
                    Position.Y += Math.Sign(y) * 5000 / d;
                }
            }
            else
            {
                x = Position.Center.X - clone[id - 1].Position.Center.X;
                y = Position.Center.Y - clone[id - 1].Position.Center.Y;
                d = x * x + y * y;
                if (d > 256)
                {
                    Position.X -= x / 16;
                    Position.Y -= y / 16;
                    Position.X += Math.Sign(x) * 10000 / d;
                    Position.Y += Math.Sign(y) * 10000 / d;
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Tex, Position, Color.Green);
        }
    }
}
