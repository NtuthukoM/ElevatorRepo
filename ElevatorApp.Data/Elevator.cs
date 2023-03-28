namespace ElevatorApp.Data
{
    public class Elevator
    {
        public int ElevatorID { get; set; }
        public double MaxLoad { get; set; }
        public double CurrentLoad { get; set; }
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; } = -1;
        public Motion Motion { get; set; }

    }
}