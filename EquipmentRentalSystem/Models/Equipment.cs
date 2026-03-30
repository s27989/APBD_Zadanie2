namespace EquipmentRentalSystem.Models;

public abstract class Equipment {
    public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8);
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public abstract string GetInfo();
}

public class Laptop : Equipment {
    public int Ram { get; set; }
    public string Cpu { get; set; }
    public override string GetInfo() => $"Laptop {Name} ({Ram}GB RAM)";
}

public class Projector : Equipment {
    public int Lumens { get; set; }
    public string Resolution { get; set; }
    public override string GetInfo() => $"Projector {Name} ({Lumens} lm)";
}

public class Camera : Equipment {
    public string SensorType { get; set; }
    public bool 4KSupport { get; set; }
    public override string GetInfo() => $"Camera {Name} (Sensor: {SensorType})";
}