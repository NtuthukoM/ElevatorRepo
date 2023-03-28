namespace ElevatorApp.Data
{
    public class Elevator
    {
        public int ElevatorID { get; set; }
        public int MaxLoad { get; set; }// number of people
        public int CurrentLoad { get; set; }// number of people
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; } = -1;
        public Motion Motion { get; set; }

    }
}