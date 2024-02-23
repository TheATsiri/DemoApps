using System.Runtime;

namespace InterfaceDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IComputerController> controllers = new List<IComputerController>();

            Keyboard keyboard = new Keyboard();
            GameController gameController = new GameController();
            BatteryPoweredKeyboard batteryPoweredKeyboard = new BatteryPoweredKeyboard();

            BatteryPoweredGameController batteryPoweredGameController = new BatteryPoweredGameController();

            controllers.Add(gameController);
            controllers.Add(keyboard);
            controllers.Add(batteryPoweredGameController);

            foreach (IComputerController controller in controllers)
            {
                if (controller is GameController gc)
                {

                }
                if (controller is IBatteryPowered powered)
                {
                    powered.BatteryLevel = 10;
                    controller.KeyPressed();
                }

            }

            using (GameController gc = new GameController())
            {
                gc.Connect();
            }


            List<IBatteryPowered> batteryPowereds = [batteryPoweredGameController, batteryPoweredKeyboard];

            foreach (var item in batteryPowereds)
            {

            }

            Console.ReadLine();
        }
    }
}
