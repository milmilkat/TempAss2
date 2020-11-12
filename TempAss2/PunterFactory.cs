using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempAss2
{
    public static class PunterFactory
    {
        public static Punter CreatePunter(string name, PictureBox pic, int money)
        {
            if (name == "Milad")
            {
                return new Milad(name, pic, money);
            }
            else if (name == "Dipti")
            {
                return new Dipti(name, pic, money);
            }

            return null;
        }
    }
}
