// See https://aka.ms/new-console-template for more information

using ContainerApp.Containers;
using ContainerApp.Enums;
using Microsoft.Win32.SafeHandles;

/*GasContainer c = new GasContainer(10, 100, 30, "tlkxd", 10000, 2321, true);
Console.WriteLine(c);*/

ContainerShip cs = new ContainerShip(100, 223, 132);
LiquidContainer l = new LiquidContainer(10, 1000, 3, "dawda", 1000, true);
GasContainer g = new GasContainer(10, 100, 30, "tlkxd", 10000, 2321, true);
RefrigeratedContainer r = new RefrigeratedContainer(123, 323, 23, "dwaw2", 231, PossibleProducts.Bananas);
r.Load(100);
//r.Unload();
Console.WriteLine(cs);
Console.WriteLine(g + "\n" + l + "\n" + r);
cs.LoadContainer(l);
cs.LoadContainerList(new List<Container>{g, r});
Console.WriteLine(cs);
