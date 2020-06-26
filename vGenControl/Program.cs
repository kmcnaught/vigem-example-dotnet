using System;
using System.Runtime.InteropServices;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;
using Nefarius.ViGEm.Client.Targets.Xbox360;

namespace vGenControl
{
    class Program
    {
        private static ViGEmClient client;
        private static IXbox360Controller controller;

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            try
            {
                client = new ViGEmClient();
                controller = client.CreateXbox360Controller();
                controller.Connect();
                Console.WriteLine("Virtual Xbox360 gamepad connected.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not connect to ViGEmClient\n");
                Console.WriteLine(e);
                Console.WriteLine("\nNote that you need to install ViGemBus for this app to work\n");
                Console.Read();
                return;
            }

            int i = 0;
            while (true) 
            {

                // We'll cycle through 8 different stick states
                i++;
                i %= 80;
                int state = i / 10;
                
                short amount = Int16.MaxValue / 2;

                if (i == 0)
                    controller.SetButtonState(Xbox360Button.A, true);
                else
                    controller.SetButtonState(Xbox360Button.A, false);

                if (state == 0)
                    controller.SetAxisValue(Xbox360Axis.LeftThumbX, amount);
                else if (state ==  1)
                    controller.SetAxisValue(Xbox360Axis.LeftThumbX, (short)(-amount));
                else
                    controller.SetAxisValue(Xbox360Axis.LeftThumbX, 0);

                if (state == 2)
                    controller.SetAxisValue(Xbox360Axis.LeftThumbY, amount);
                else if (state == 3)
                    controller.SetAxisValue(Xbox360Axis.LeftThumbY, (short)(-amount));
                else
                    controller.SetAxisValue(Xbox360Axis.LeftThumbY, 0);

                if (state == 4)
                    controller.SetAxisValue(Xbox360Axis.RightThumbX, amount);
                else if (state == 5)
                    controller.SetAxisValue(Xbox360Axis.RightThumbX, (short)(-amount));
                else
                    controller.SetAxisValue(Xbox360Axis.RightThumbX, 0);

                if (state == 6)
                    controller.SetAxisValue(Xbox360Axis.RightThumbY, amount);
                else if (state == 7)
                    controller.SetAxisValue(Xbox360Axis.RightThumbY, (short)(-amount));
                else
                    controller.SetAxisValue(Xbox360Axis.RightThumbY, 0);
                

                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
