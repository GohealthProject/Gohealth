using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 期中專題.Model
{
    public class CustomBlogManager
    {
        List<customBlog> _cbList = new List<customBlog>();
        List<customBlog> _carCbList = new List<customBlog>();
        int _position = 1;
        MedSysEntities ms = new MedSysEntities();
        public int nowPage { get { return _position; } }
        public List<customBlog> AllcustomerBlog { get { return _cbList; } }
        public customBlog currentCustomerBlog { get { return _carCbList[_position]; } }
        public List<customBlog> CatcustomerBlog { get { return _carCbList; } }
        
        
        public CustomBlogManager() {
            LoadData();
        }

        private void LoadData()
        {
            var q = ms.Blogs.Select(n => new { n.Title, n.BlogImage, n.Content, n.BlogCategory.BlogCategory1, n.EmployeeID, n.BlogID, n.CreatedAt, n.Employee.EmployeeName, n.Views });
            foreach (var n in q)
            {
                customBlog cb = new customBlog();
                cb.title = n.Title;
                cb.BlogImage = n.BlogImage;
                cb.Content = n.Content;
                cb.BlogID = n.BlogID;
                cb.EmployeeID = n.EmployeeID;
                cb.CreatedAt = n.CreatedAt;
                cb.BlogClass = n.BlogCategory1;
                cb.author = n.EmployeeName;
                cb.view = n.Views;
                _cbList.Add(cb);
            }
        }
        public void CatByCustomerBlog(string x)
        {
            _carCbList.Clear();
            _position = 0;
            var q = from n in _cbList
                    where n.BlogClass == x
                    select n;

            foreach(var n in q)
            {
                _carCbList.Add(n);
            }
        }
        public void NextBlog()
        {
            
            if(_position == _carCbList.Count-1)
            {
                _position = 0;
            }
            else
            {
                _position++;
            }

        }
        public void PreviousBlog()
        {
            if (_position <= 0)
            {
                _position = 0;
            }
            else
            {
                _position--;
            }
        }
        public void LastBlog()
        {
            _position = _carCbList.Count-1 ;
        }
        public void FirstBlog()
        {
            _position = 0;
        }

        public void CatByCustomerBlog()
        {
            if(_carCbList.Count > 0)
            {
                _carCbList.Clear();
            }
            _position = 0;
            var q = from n in _cbList
                    select n;

            foreach (var n in q)
            {
                _carCbList.Add(n);
            }
        }
    }
}
