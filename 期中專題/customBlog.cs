using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 期中專題
{
    public  class customBlog
    {
        public int BlogID { get; set; }
        public string BlogClass { get; set; }
        public int view { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Content { get; set; }
        public byte[] BlogImage { get; set; }
        public int EmployeeID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }
}
