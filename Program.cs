using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            logic a=new logic();
            a.setDriver();
            a.dmEnroll("dsmain.ssdevrd.com","wp","a","a");
        }
    }
}
