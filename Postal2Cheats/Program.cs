using Postal2Cheats;
using Swed32;
using System.Threading;

Console.WriteLine("Capturing the game process...");

Swed swed = new Swed("Postal2");
IntPtr moduleBase = swed.GetModuleBase("Postal2.exe");
IntPtr engineBase = swed.GetModuleBase("Engine.dll");

Console.WriteLine("Loading addresses...");

IntPtr M16A2AmmoAddress = swed.ReadPointer(moduleBase, 0x0002BFA4, 0x14, 0x14, 0x98) + 0x2CC;
IntPtr YAxisAddress = swed.ReadPointer(engineBase, 0x0063C680, 0x80, 0x30, 0x40C) + 0xE8;

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