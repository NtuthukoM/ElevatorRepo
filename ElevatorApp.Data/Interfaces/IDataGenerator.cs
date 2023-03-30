using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorApp.Data.Entities;

namespace ElevatorApp.Data.Interfaces
{
    public interface IDataGenerator
    {
        List<Elevator> GetElevators();
    }
}
