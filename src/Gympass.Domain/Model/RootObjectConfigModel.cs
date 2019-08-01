namespace Gympass.Domain.Model
{
    
    public class RootObjectConfigModel
    {
        public ArrivalTime ArrivalTime { get; set; }
        public PilotName PilotName { get; set; }
        public PilotId PilotId { get; set; }
        public Laps Laps { get; set; }
        public CircuitTime CircuitTime { get; set; }
        public AverageLap AverageLap { get; set; }
    }

    public class RootObject
    {
        public RootObjectConfigModel RootObjectConfigModel{ get; set; }
    }

    public class ArrivalTime
    {
        public string startIndex { get; set; }
        public string length { get; set; }
    }

    public class PilotName
    {
        public string startIndex { get; set; }
        public string length { get; set; }
    }

    public class PilotId
    {
        public string startIndex { get; set; }
        public string length { get; set; }
    }

    public class Laps
    {
        public string startIndex { get; set; }
        public string length { get; set; }
    }

    public class CircuitTime
    {
        public string startIndex { get; set; }
        public string length { get; set; }
    }

    public class AverageLap
    {
        public string startIndex { get; set; }
        public string length { get; set; }
    }
}
