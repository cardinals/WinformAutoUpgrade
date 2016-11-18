using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassBLL
    {
        public static string GetStr()
        {
            return new ClassDAL().ToString();
        }
    }
}
