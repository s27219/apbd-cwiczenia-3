using ContainerApp.Exceptions;
using ContainerApp.Interfaces;

namespace ContainerApp.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous { get; set; }
    protected LiquidContainer(double height, double ownWeight, double depth, string serialNumber, double maxCapacity, bool isHazardous) : base(height, ownWeight, depth, serialNumber, maxCapacity)
    {
        IsHazardous = isHazardous;
    }
    public override void Load(double cargoWeight)
    {
        double allowedCapacity = IsHazardous ? MaxCapacity * 0.5 : MaxCapacity * 0.9;
        if (cargoWeight > allowedCapacity)
        {
            NotifyHazard($"Hazardous load attempt. Allowed: {allowedCapacity}, Attempted: {cargoWeight}");
            throw new OverfillException("Attempt to load more than allowed for hazardous/non-hazardous materials.");
        }

        base.Load(cargoWeight);
    }
    public override void Unload()
    {
        CargoWeight = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}