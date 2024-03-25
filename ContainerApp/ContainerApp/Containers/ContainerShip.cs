namespace ContainerApp.Containers;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    public int MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxLoadWeight { get; set; }   //w tonach

    public ContainerShip(int maxSpeed, int maxContainerCount, double maxLoadWeight)
    {
        MaxSpeed = maxSpeed;
        MaxLoadWeight = maxLoadWeight;
        MaxContainerCount = maxContainerCount;
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        double shipWeight = 0;
        foreach (Container shipContainer in Containers)
        {
            shipWeight = shipContainer.OwnWeight + shipContainer.CargoWeight;
        }
        if ((Containers.Count < MaxContainerCount) && (MaxLoadWeight * 1000 >= shipWeight + container.CargoWeight + container.OwnWeight))
        {
            Containers.Add(container);
        }
        else
        {
            Console.WriteLine("Ship is full, cannot load container");
        }
    }
    
    public void LoadContainerList(List<Container> containerList)
    {
        double shipWeight = 0;
        foreach (Container shipContainer in Containers)
        {
            shipWeight = shipContainer.OwnWeight + shipContainer.CargoWeight;
        }

        double containerListWeight = 0;
        foreach (Container listContainer in containerList)
        {
            containerListWeight = listContainer.OwnWeight + listContainer.CargoWeight;
        }
        if ((containerList.Count + Containers.Count > MaxContainerCount) && (MaxLoadWeight * 1000 < shipWeight + containerListWeight))
        {
            Console.WriteLine("Ship does not have enough space for container list");
        }
        else
        {
            foreach (var container in containerList)
            {
                Containers.Add(container);
            }
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        Container container = null;
        foreach (Container c in Containers)
        {
            if (c.SerialNumber.Equals(serialNumber))
            {
                container = c;
            }
        }

        if (container == null)
        {
            Console.WriteLine("No such container");
        }
        else
        {
            foreach (Container c in Containers)
            {
                if (c.SerialNumber.Equals(serialNumber))
                {
                    Containers.Remove(c);
                }
            }
        }
    }
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        UnloadContainer(serialNumber);
        LoadContainer(newContainer);
    }
    
    public void TransferContainer(string serialNumber, ContainerShip targetShip)
    {
        Container container = null;
        foreach (Container c in Containers)
        {
            if (c.SerialNumber.Equals(serialNumber))
            {
                container = c;
            }
        }

        if (container == null)
        {
            Console.WriteLine("No such container");
        }
        else
        {
            Containers.Remove(container);
            targetShip.LoadContainer(container);
        }
    }

    public override string ToString()
    {
        if (Containers.Count != 0)
        {
            string allContainers = "\n";
            foreach (Container c in Containers)
            {
                allContainers += c + "\n";
            }
            return $"max speed: {MaxSpeed}, max container count: {MaxContainerCount}, max load weight: {MaxLoadWeight}, containers:{allContainers}";
        }
        return $"max speed: {MaxSpeed}, max container count: {MaxContainerCount}, max load weight: {MaxLoadWeight}";
    }
}