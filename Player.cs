using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Battleship
{
    internal class Player
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public List<Ship> Fleet { get; set; }
        public bool IsAlive { get; set; } = true;


        public int Number { get; set; }




    }


}
