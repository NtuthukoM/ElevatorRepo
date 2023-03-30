using ElevatorApp.Data.Entities;
using ElevatorApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp.Data.Concrete
{
    public class DataGenerator : IDataGenerator
    {
        public List<Elevator> GetElevators()
        {
            return new List<Elevator>()
            {
                new Elevator
                {                 
                }
            };
        }
    }
}
