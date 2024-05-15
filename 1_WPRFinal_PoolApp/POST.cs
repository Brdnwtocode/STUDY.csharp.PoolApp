using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WPRFinal_PoolApp
{
    public class POST
    {
     public int PostID { get; set; }  
     public string TournamentID { get; set; }
     public int UserID { get; set; }
     public string UserName { get; set; }
           
     public string PostText { get; set; }     
     public Image image { get; set; }
     public int Upvotes { get; set; }
     public int Downvotes { get; set; }    
     public DateTime PostDate { get; set; }  
        
    public POST() { }



            
    }
}
