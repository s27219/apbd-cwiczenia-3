using ContainerApp.Exceptions;
using ContainerApp.Interfaces;

namespace ContainerApp.Containers;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double OwnWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxCapacity { get; set; }

    protected Container(double height, double ownWeight, double depth, string serialNumber, double maxCapacity)
    {
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxCapacity = maxCapacity;
    }

    public abstract void Unload();

    public virtual void Load(double cargoWeight)
    {
        if (cargoWeight > MaxCapacity)
        {
            throw new OverfillException("Attempt to load more than allowed");
        }
        CargoWeight = cargoWeight;
    }
    
    public override string ToString()
    {
        return $"serial number: {SerialNumber}, cargo weight: {CargoWeight}, height: {Height}, own weight: {OwnWeight}, depth: {Depth}, max capacity: {MaxCapacity}";
    }
}