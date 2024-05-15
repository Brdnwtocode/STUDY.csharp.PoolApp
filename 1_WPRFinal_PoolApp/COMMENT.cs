using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class COMMENT
    {
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public int ReplyCommentID { get; set; }
        public int UID { get; set; }
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        public COMMENT() { }


    }
}
