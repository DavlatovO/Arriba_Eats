using System;

namespace Arriba_Eats
{
    public static class ClientMenus
    {
    public static void ClientMenu(Client client)
    {
        while (true)
        {

        

            const int DISPLAY_INDEX = 1;
            const int ADDITEM_INDEX = 2;
            const int CURRENTORDER_INDEX = 3;
            const int STARTCOOKING_INDEX = 4;
            const int FINISHCOOKING_INDEX = 5;
            const int HANDLEDELIVERERS_INDEX = 6;
            const int LOGOUT_INDEX = 7;
            const int NUMBER_OPTIONS = 7;



            Console.WriteLine($"Welcome back, {client.Name}!");
            Console.WriteLine($"Please make a choice from the menu below:");
            Console.WriteLine($"1: Display your user information");
            Console.WriteLine($"2: Add items to restaurant menu");
            Console.WriteLine($"3: See current orders");
            Console.WriteLine($"4: Start cooking order");
            Console.WriteLine($"5: Finish cooking order");
            Console.WriteLine($"6: Handle deliverers who have arrived");
            Console.WriteLine($"7: Log out");

            int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Please enter a valid number.");
                        continue;
                    }
            if ((choice > 0) && (choice <= NUMBER_OPTIONS))
            {
                switch (choice)
                {
                    case DISPLAY_INDEX:
                        Console.WriteLine(client.Details());
                        break;
                    case ADDITEM_INDEX:
                        break;
                    case CURRENTORDER_INDEX:
                        break;
                    case STARTCOOKING_INDEX:
                        break;
                    case FINISHCOOKING_INDEX:
                        break;
                    case HANDLEDELIVERERS_INDEX:
                        break;
                    case LOGOUT_INDEX:
                        client.Logout();
                        return;
                    default:
                            Console.WriteLine("Error - Invalid employee type.");
                            break;             
                }
            }
            else
            {
                Console.WriteLine("Error - Invalid employee type.");
            }

              Console.WriteLine("===========================");

        }
    }

    }
    

}