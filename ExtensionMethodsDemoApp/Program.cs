using System.Data.SqlTypes;

namespace ExtensionMethodsDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            "Hello Antonios".PrintToConsole();

            HotelRoomModel roomModel = new HotelRoomModel();

            roomModel.TurnOnAirCondition().SetTemperature(21).CloseWindowShades();

            roomModel.TurnOffAirCondition().OpenWindowShades();

            Console.ReadLine();
        }
    }
    public static class ExtensionSamples
    {
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }

        public static HotelRoomModel TurnOnAirCondition(this HotelRoomModel room)
        {
            room.IsAirConditionRunning = true;

            return room;
        }
        public static HotelRoomModel TurnOffAirCondition(this HotelRoomModel room)
        {
            room.IsAirConditionRunning = false;

            return room;
        }

        public static HotelRoomModel SetTemperature(this HotelRoomModel room, int temperature)
        {
            room.Temperature = temperature;
            return room;
        }
        public static HotelRoomModel OpenWindowShades(this HotelRoomModel room)
        {
            room.AreWindowsShadesOpen = true;

            return room;
        }

        public static HotelRoomModel CloseWindowShades(this HotelRoomModel room)
        {
            room.AreWindowsShadesOpen = false;

            return room;
        }
    }

    public class HotelRoomModel
    {
        public int Temperature { get; set; }
        public bool IsAirConditionRunning { get; set; }
        public bool AreWindowsShadesOpen { get; set; }
    }
}
