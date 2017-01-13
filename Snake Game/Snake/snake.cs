using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace 贪食蛇
{
    public class snake                  
    {
        public ArrayList alist;                
        public ArrayList plist;
        public Point headpoint;         
        private int way = 4;            
        public  int count;
        public int Way
        {
            get
            {
                return way;
            }
            set
            {
                way = value;
            }
        }


        public snake(int count)                 
        {
            this.count = count;
            partOfSnake apart;
            Point apoint = new Point(20, 20);   
            alist = new ArrayList(count);       
            for (int i = 1; i <= count; i++)
            {
                apoint.X = apoint.X + 20;
                apart = new partOfSnake();
                apart.Number = i;
                apart.Orign = apoint;
                alist.Add(apart);               
                if (i == count)
                    headpoint = apoint;          
            }

        }

        public ArrayList copy()
        {
            plist = new ArrayList(count );
            for (int i = 0; i < count ; i++)
            {
                plist.Add(alist[i]);
            }
            return plist;
        }

        public void extendsnake()               
        {
            partOfSnake seg = new partOfSnake();
            seg.Number = alist.Count + 1;
            Point p;
            if (way == 1)
                p = new Point(headpoint.X, headpoint.Y - 20); 
            else if (way == 3)
                p = new Point(headpoint.X, headpoint.Y + 20);
            else if (way == 2)
                p = new Point(headpoint.X - 20, headpoint.Y);
            else
                p = new Point(headpoint.X + 20, headpoint.Y);
            seg.Orign = p;
            alist.Add(seg);           
            headpoint = seg.Orign;    
        }

        public void contractsnake()   
        {
            alist.Remove(alist[0]);   
        }

        public bool deadsnake()      
        {
            if (headpoint.X <= 0&&way==2|| headpoint.Y <=0 &&way==1|| headpoint.X >= 580&&way==4|| headpoint.Y >= 580&&way==3)
                return true;     

            for (int i = 0; i < alist.Count-1 ; i++)
            {
                partOfSnake seg = (partOfSnake)alist[i]; 
                if (seg.Orign == headpoint)    
                    return true;
            }
            return false;
        }
        public object Clone()
        {
            return new snake(this.count ) as object; 
        }

    }
}
