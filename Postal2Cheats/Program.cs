using Postal2Cheats;
using Swed32;
using System.Threading;

Console.WriteLine("Capturing the game process...");

Swed swed = new Swed("Postal2");
IntPtr moduleBase = swed.GetModuleBase("Postal2.exe");

Console.WriteLine("Loading addresses...");

IntPtr M16A2AmmoAddress = swed.ReadPointer(moduleBase, 0x0002BFA4, 0x14, 0x14, 0x98) + 0x2CC;

Console.WriteLine("Loading renderer...");

Renderer renderer = new Renderer();
Thread renderThread = new Thread(() => renderer.Start().Wait());
renderThread.Start();

while (true)
{
    if (renderer.M16A2Bool)
    {
        swed.WriteInt(M16A2AmmoAddress, 9999);
    }
}