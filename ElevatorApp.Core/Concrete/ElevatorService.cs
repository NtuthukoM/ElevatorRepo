using ElevatorApp.Core.Common;
using ElevatorApp.Core.Interfaces;
using ElevatorApp.Data.Entities;
using ElevatorApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApp.Core.Concrete
{
    public class ElevatorService : IElevatorService
    {        
        private List<Elevator> elevators;
        public int MaxFloor { get; set; }

        public ElevatorService(IDataGenerator dataGenerator)
        {
            elevators = dataGenerator.GetElevators();
        }

        //Find elevator to add destination to.
        void IElevatorService.CallElevator(Destination destination)
        {
            //find closest elevator:
            var elevator = elevators.FirstOrDefault(x => x.Motion == Motion.Waiting);   
            if(elevator == null)
            {
                throw new ApplicationException(Constants.NoElevatorsAvailable);
            }
            elevator.DestinationFloors.Add(destination);
            //set elevator status:
            if(elevator.CurrentFloor < destination.CurrentFloor)
            {
                elevator.Motion = Motion.GoingUp;
            }
            else if(elevator.CurrentFloor > destination.CurrentFloor)
            {
                elevator.Motion = Motion.GoingDown;
            }else if(elevator.CurrentFloor == destination.CurrentFloor)
            {
                PickUpPassangers(elevator);
            }
        }

        public void MoveElevators()
        {
            //State changes based on motion:
            foreach(var elevator in elevators)
            {
                MoveSingleElevator(elevator);

                PickUpPassangers(elevator);

                OffloadPassangers(elevator);

                SetMotionStatus(elevator);
            }
        }

        private void SetMotionStatus(Elevator elevator)
        {
            //wait:
            if (elevator.CurrentFloor == 0 && !elevator.DestinationFloors.Any())
            {
                elevator.Motion = Motion.Waiting;
            } else if (elevator.CurrentFloor != 0 && !elevator.DestinationFloors.Any())
            {
                elevator.Motion = Motion.GoingDown;
            }
            //
        }

        void OffloadPassangers(Elevator elevator)
        {
            if (elevator.DestinationFloors.Any(x => x.DestinationFloor == elevator.CurrentFloor))
            {
                var destination = elevator.DestinationFloors.First(x =>
                    x.DestinationFloor == elevator.CurrentFloor);
                elevator.DestinationFloors.Remove(destination);
                elevator.CurrentLoad -= destination.NumberOfPeople;
            }
        }

        void PickUpPassangers(Elevator elevator)
        {
            if (elevator.DestinationFloors.Any(x => x.CurrentFloor == elevator.CurrentFloor))
            {
                var destination = elevator.DestinationFloors.First(x =>
                    x.CurrentFloor == elevator.CurrentFloor);

                elevator.CurrentLoad += destination.NumberOfPeople;
                destination.CurrentFloor = -1; // people are in the elevator.
            }
        }

        private void MoveSingleElevator(Elevator elevator)
        {
            if (elevator.Motion == Motion.GoingUp && elevator.CurrentFloor < MaxFloor)
            {
                elevator.CurrentFloor++;
            }
            if (elevator.Motion == Motion.GoingDown && elevator.CurrentFloor > 0)
            {
                elevator.CurrentFloor--;
            }
        }
    }
}
