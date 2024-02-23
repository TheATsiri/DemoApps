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

    public interface IComputerController : IDisposable
    {
        void Connect();
        void KeyPressed();
    }
    public interface IBatteryPowered
    {
        int BatteryLevel { get; set; }
    }

    public class Keyboard : IComputerController
    {
        public void Connect()
        {

        }

        public void KeyPressed()
        {

        }

        public void Dispose()
        {

        }

        public string? ConnectionType { get; set; }
    }

    public class GameController : IComputerController, IDisposable
    {
        public void Connect()
        {

        }

        public void Dispose()
        {
            //do whatever shutdown tasks needed
        }

        public void KeyPressed()
        {

        }
    }
    public class BatteryPoweredKeyboard : Keyboard, IBatteryPowered
    {
        public int BatteryLevel { get; set; }
    }

    public class BatteryPoweredGameController : GameController, IBatteryPowered
    {
        public int BatteryLevel { get; set; }
    }
}
