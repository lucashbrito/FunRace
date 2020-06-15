namespace FunRace.Infrastructure.Template
{
    public class RootObjectConfigTemplate
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
        public RootObjectConfigTemplate RootObjectConfigModel{ get; set; }
    }

    public class ArrivalTime
    {
        public int startIndex { get; set; }
        public int length { get; set; }
    }

    public class PilotName
    {
        public int startIndex { get; set; }
        public int length { get; set; }
    }

    public class PilotId
    {
        public int startIndex { get; set; }
        public int length { get; set; }
    }

    public class Laps
    {
        public int startIndex { get; set; }
        public int length { get; set; }
    }

    public class CircuitTime
    {
        public int startIndex { get; set; }
        public int length { get; set; }
    }

    public class AverageLap
    {
        public int startIndex { get; set; }
        public int length { get; set; }
    }
}
