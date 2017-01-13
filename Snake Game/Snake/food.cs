using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using 贪食蛇;

namespace 贪吃蛇
{
    class food
    {
        public Point position;
        public void createFood(snake s)
        {
            position = createPoint();
            while (!isValid(position, s))
            {
                position = createPoint();
            }
        }
        public Boolean isValid(Point p,snake s)
        {
            p = createPoint();
            for (int i = 0; i < s.count; i++)
            {
                partOfSnake seg = (partOfSnake)s.alist[i];
                if (p.Equals(seg.Orign))
                {
                    return false;
                }
            }
            return true;
        }
        public Point createPoint()
        {
            int x, y;
            long tick1 = DateTime.Now.Ticks;
            Random x1 = new Random((int)(tick1 & 0xffffffffL) | (int)(tick1 >> 20));
            x = x1.Next(30);
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            y = ran.Next(30);
            return  new Point(x*20, y*20);
        }
        public void drawMe(Graphics g)
        {
            Rectangle r = new Rectangle(position.X ,position .Y ,20,20);
            g.FillRectangle(Brushes.Red ,r);
        }

    }
}
