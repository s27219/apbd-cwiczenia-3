using ContainerApp.Exceptions;
using ContainerApp.Interfaces;

namespace ContainerApp.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    private bool IsHazardous { get; set; }

    public GasContainer(double height, double ownWeight, double depth, string serialNumber, double maxCapacity, double pressure, bool isHazardous) : base(height, ownWeight, depth, serialNumber, maxCapacity)
    {
        Pressure = pressure;
        IsHazardous = isHazardous;
    }
    
    public override void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCapacity)
        {
            NotifyHazard($"Hazardous load attempt. Allowed: {MaxCapacity}, Attempted: {cargoWeight}");
            throw new OverfillException("Attempt to load more than allowed for hazardous/non-hazardous materials.");
        }

        base.Load(cargoWeight);
    }
    
    public override void Unload()
    {
        CargoWeight *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}