using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 期中專題.Model
{
    internal class CCommentsManager
    {
        MedSysEntities ms = new MedSysEntities();

       internal List<CCustomComments> all { get { return allList; } }
        List<CCustomComments> allList = new List<CCustomComments>();
        public List<CCustomComments> currentBlog { get; set; }
        List<CCustomComments> curretList = new List<CCustomComments>();
        public CCommentsManager() 
        {
             loadAllComments();
        }
        void loadAllComments()
        {
            List<CCustomComments> temp = new List<CCustomComments>();
            var comments = ms.Comments.Select(n => new CCustomComments
            {
                CommentID = n.CommentID,
                ParentCommentID = (int)n.ParentCommentID,
                MemberID = (int)n.MemberID,
                MemberNickname = n.Member.memberNickname,
                Content = n.Content,
                EmployeeID = (int)n.EmployeeID,
                EmployeeName = n.Employee.EmployeeName,
                CreatedAt = n.CreatedAt,
                JobTitle = n.Employee.EmployeeClass.Class,
            });
            foreach (var comment in comments)
            {
                allList.Add(comment);
            }
        }
         public void check(int x )
        {
            
        }

    }
}
