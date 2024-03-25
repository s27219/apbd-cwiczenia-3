using ContainerApp.Enums;

namespace ContainerApp.Containers;

public class RefrigeratedContainer : Container
{
    public PossibleProducts ProductType { get; set; }
    public double Temperature { get; set; }

    public RefrigeratedContainer(double height, double ownWeight, double depth, string serialNumber, double maxCapacity, PossibleProducts productType) : base(height, ownWeight, depth, serialNumber, maxCapacity)
    {
        ProductType = productType;
        Temperature = (double)ProductType;
    }

    public override void Unload()
    {
        CargoWeight = 0;
    }

    public override string ToString()
    {
        return base.ToString() + $", product type: {ProductType.ToString()}, temperature: {Temperature}";
    }
}