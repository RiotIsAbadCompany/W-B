using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class RegionNumber
    {
        
  private int x { get; set; }
        private int y { get; set; }
        public RegionNumber(int i, int j)
        {
            this.x = i;
            this.y = j;
           
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }

       

    }
}
