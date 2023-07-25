using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    public enum SquareStatus
    {
        [Description("\u224B")]
        empty,
        [Description("\u25CC")]
        miss,
        [Description("\u2388")]
        ship,
        [Description("\u2BCC")]
        hit,
        [Description("\u2737")]
        sink

    }

}
