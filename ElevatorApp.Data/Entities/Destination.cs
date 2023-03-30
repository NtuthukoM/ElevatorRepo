using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp.Data.Entities
{
    public class Destination
    {
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
