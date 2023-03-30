namespace ElevatorApp.Data.Entities
{
    public class Elevator
    {
        public int ElevatorID { get; set; }
        public int MaxLoad { get; set; } = 10; // number of people default value set
        public int CurrentLoad { get; set; }// number of people
        public int CurrentFloor { get; set; }
        public List<Destination> DestinationFloors { get; set; } = new List<Destination>();
        public Motion Motion { get; set; }

    }
}