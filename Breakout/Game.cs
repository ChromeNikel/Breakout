using Breakout.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;

namespace Breakout
{
    class Game
    {        
        public Point Move(int x, int y, double edge = 45, int direction = 0, int speed = 10)
        {
            Point p = new Point();
            int k = 0;           
            k = (int)Math.Tan(edge);

            switch (direction)
            {
                case 0:
                    {
                        p.X = x + speed;
                        p.Y = y - speed * k;
                        break;
                    }
                case 1:
                    {
                        p.X = x - speed;
                        p.Y = y - speed * k;
                        break;
                    }
                case 2:
                    {
                        p.X = x - speed;
                        p.Y = y + speed * k;
                        break;
                    }
                case 3:
                    {
                        p.X = x + speed;
                        p.Y = y + speed * k;
                        break;
                    }
                default:
                    break;
            }
            return p;
        }
       
    }
}