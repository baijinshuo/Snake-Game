using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 贪食蛇
{
    public class partOfSnake                  
    {
        private int number;
        public int Number                    
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        private Point orign;

        public Point Orign                   
        {
            get
            {
                return orign;
            }
            set
            {
                orign = value;
            }
        }
    }
}
