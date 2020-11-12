using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempAss2
{
    public class Milad : Punter
    {
        public Milad(string name, PictureBox car, int money)
        {
            Name = name;
            Car = car;
            Money = money;
        }
    }
}
