using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class EKG
   {
      public int EKGID { get; set; }
      public bool Availiable { get; set; }

      public EKG(int EKGid, bool availiable)
      {
         EKGID = EKGid;
         Availiable = availiable;
      }
   }
}
