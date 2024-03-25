using ContainerApp.Containers;
using ContainerApp.Enums;


//PRZYKŁADOWE OBIEKTY I METODY
/*ContainerShip cs = new ContainerShip(100, 222, 333);
LiquidContainer l = new LiquidContainer(10, 1000, 3, "KON-L-1", 1000, true);
l.Load(900);
GasContainer g = new GasContainer(10, 100, 30, "KON-G-1", 10000, 2321, false);
g.Load(123);
g.Unload();
RefrigeratedContainer r = new RefrigeratedContainer(123, 323, 23, "KON-R-1", 231, PossibleProducts.Bananas);
r.Load(200);
cs.LoadContainer(l);
cs.LoadContainerList(new List<Container>{g, r});
cs.UnloadContainer("KON-R-1");
cs.ReplaceContainer("KON-L-1", r);
ContainerShip cs2 = new ContainerShip(200, 444, 666);
cs.TransferContainer("KON-G-1", cs2);*/

var containers = new List<Container>();
var ships = new List<ContainerShip>();
 while (true)
 {
        Console.WriteLine("Container Management System");
        Console.WriteLine("1. Add Ship");
        Console.WriteLine("2. Add Container");  //dla uproszczenia tylko LiquidContainer
        Console.WriteLine("3. Load Container onto Ship");
        Console.WriteLine("4. List Ships and Containers");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Write("Enter ship max speed: ");
                int maxSpeed = int.Parse(Console.ReadLine());
                Console.Write("Enter max container count: ");
                int maxContainerCount = int.Parse(Console.ReadLine());
                Console.Write("Enter max weight: ");
                Double maxWeight = Double.Parse(Console.ReadLine());
                var ship = new ContainerShip(maxSpeed, maxContainerCount, maxWeight);
                ships.Add(ship);
                Console.WriteLine("Ship added successfully.");
                break;
            case "2":
                Console.Write("Enter container number: ");
                string serialNumber = $"KON-L-{Console.ReadLine()}";
                Console.Write("Enter height (cm): ");
                int height = int.Parse(Console.ReadLine());
                Console.Write("Enter own weight (kg): ");
                int ownWeight = int.Parse(Console.ReadLine());
                Console.Write("Enter depth (cm): ");
                int depth = int.Parse(Console.ReadLine());
                Console.Write("Enter max load capacity (kg): ");
                int maxCapacity = int.Parse(Console.ReadLine());
                Console.Write("Is it hazardous? (yes/no): ");
                bool isHazardous = Console.ReadLine().Trim().ToLower() == "yes";
                var container = new LiquidContainer(height, ownWeight, depth, serialNumber, maxCapacity, isHazardous);
                containers.Add(container);
                Console.WriteLine("Container added successfully.");
                break;
            case "3":
                if (ships.Count == 0 || containers.Count == 0)
                {
                    Console.WriteLine("Please add at least one ship and one container first.");
                    break;
                }
                Console.WriteLine("Choose ship:");
                for (int i = 0; i < ships.Count; i++)
                {
                    Console.WriteLine($"[{i}] - {ships[i]}");
                }
                int shipNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose full container serial number:");
                foreach (Container c in containers)
                {
                    Console.WriteLine(c);
                }
                string containerSerialNumber = Console.ReadLine();
                Container cont = null;
                foreach (Container c in containers)
                {
                    if (c.SerialNumber.Equals(containerSerialNumber))
                    {
                        cont = c;
                    }
                }

                if (cont == null)
                {
                    Console.WriteLine("No such number");
                    break;
                }
                
                ships[shipNumber].LoadContainer(cont);
                break;
            case "4":
                Console.WriteLine("Ships:");
                foreach (var s in ships)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("Containers:");
                foreach (var c in containers)
                {
                    Console.WriteLine(c);
                }
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option, please try again.");
                break;
        }
 }