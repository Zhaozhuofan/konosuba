using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konosuba.Models
{
    public class Character(string iconURl, string portrait)
    {
        public string IconURL { get; set; } = iconURl;
        public string PortraitURL { get; set; } = portrait;
    }
}
