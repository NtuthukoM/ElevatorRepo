using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp.Core.Interfaces
{
    public interface IElevatorService
    {
        void CallElevator(int floor, int numberPeopleWaiting);
    }
}
