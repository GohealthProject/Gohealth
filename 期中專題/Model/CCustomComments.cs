using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 期中專題.Model
{
    internal class CCustomComments
    {
        //var comments = from c in ms.Comments
        //               where c.BlogID == CurrentBlogID
        //               orderby c.CommentID
        //               select new { c.CommentID, c.ParentCommentID, c.MemberID, mNickName = c.Member.memberNickname, c.Content, c.EmployeeID, c.Employee.EmployeeName, c.CreatedAt, JobTitle = c.Employee.EmployeeClass.Class };
        internal int CommentID { get; set; }
        internal int ParentCommentID{get;set;}

        internal int MemberID { get; set; }
        internal string MemberNickname { get; set; }
        internal string Content { get; set;}
        internal int EmployeeID { get; set; }
        internal string EmployeeName { get; set; }
        internal DateTime CreatedAt { get; set; }
        internal string JobTitle { get; set; }
    }
}
