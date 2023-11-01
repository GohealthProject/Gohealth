using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 期中專題.Model
{
    public class BlogManage
    {
        List<Blog> _list = new List<Blog>();
        List<BlogCategory> _listC = new List<BlogCategory>();
        Blog currentBlog  =new Blog();
        public List<Blog> Allblogs { get { return _list; } }
        public List<BlogCategory> AllCat { get { return _listC; } }
        public Blog nowBlog { get { return currentBlog;  } }

        public int _position = 0;

        MedSysEntities ms =new MedSysEntities();
        public BlogManage()
        {
            LoadData();
        }

        public void LoadData()
        {
            var q = from n in ms.Blogs
                    select n;
            foreach(var item in q)
            {
                _list.Add(item);
            }
            var q2 = from n in ms.BlogCategories
                     select n;
            foreach(var item in q2)
            {
                _listC.Add(item);
            }
        }

        public void reBlog()
        {
            var q = from n in ms.Blogs
                    select n;
            foreach(var item in q)
            {
                _list.Add(item);
            }
        }

        public void blogIdByBlog(int id,ref int classid)
        {
            var q = (from n in _list
                    where n.BlogID == id
                    select n).FirstOrDefault();
            var q2 = from n in _list
                    where n.BlogID == id
                    select n.BlogCategory.BlogClassID;
            currentBlog = q;
        }
        public void blogIdByBlog(int id,ref MedSysEntities msd)
        {
            var q = (from n in msd.Blogs
                     where n.BlogID == id
                     select n).FirstOrDefault();
            currentBlog = q;
        }
    }
   
}
