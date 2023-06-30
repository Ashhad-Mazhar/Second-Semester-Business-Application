using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System.BL
{
    class Review
    {
        private string remarks;
        private int stars;
        public Review ()
        {
            this.stars = 0;
            this.remarks = "Null";
        }
        public Review(string remarks, int stars)
        {
            this.stars = stars;
            this.remarks = remarks;
        }
        public string GetRemarks()
        {
            return remarks;
        }
        public void SetRemarks(string remarks)
        {
            this.remarks = remarks;
        }
        public int GetStars()
        {
            return stars;
        }
        public bool SetStars(int stars)
        {
            if (stars >= 1 && stars <= 5)
            {
                this.stars = stars;
                return true;
            }
            return false;
        }
        public string toString()
        {
            string result = "Review[remarks=" + remarks + ",stars=" + stars + "]";
            return result;
        }
    }
}
