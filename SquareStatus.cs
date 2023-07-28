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
        Empty,
        [Description("\u25CC")]
        Miss,
        [Description("\u2388")]
        Ship,
        [Description("\u2BCC")]
        Hit,
        [Description("\u2737")]
        Sink

    }

}
