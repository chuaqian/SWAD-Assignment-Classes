using System;
using SWADAssgClasses;
class ShiYing
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Accident Details:");
        Console.WriteLine("Type '0' to exit at any point.");

        DateTime currentTime = DateTime.Now;
        DateTime accidentDate;
        while (true)
        {
            Console.Write("Accident Date (yyyy-MM-dd HH:mm): ");
            string dateInput = Console.ReadLine();
            if (dateInput == "0")
            {
                Console.WriteLine("Exiting...");
                return;
            }
            if (!DateTime.TryParseExact(dateInput, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out accidentDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-MM-dd HH:mm.");
                continue;
            }

            TimeSpan timeDifference = currentTime - accidentDate;
            if (timeDifference.TotalHours > 48)
            {
                Console.WriteLine("Accident date must be within 48 hours of the current time.");
            }
            else if (timeDifference.TotalHours < 0)
            {
                Console.WriteLine("Accident date cannot be in the future.");
            }
            else
            {
                break;
            }
        }

        Console.Write("Description: ");
        string description = Console.ReadLine();
        if (description == "0")
        {
            Console.WriteLine("Exiting...");
            return;
        }

        bool status = false;
        while (true)
        {
            Console.Write("Status (resolved/unresolved): ");
            string statusInput = Console.ReadLine().ToLower();
            if (statusInput == "0")
            {
                Console.WriteLine("Exiting...");
                return;
            }
            if (statusInput == "resolved")
            {
                status = true;
                break;
            }
            else if (statusInput == "unresolved")
            {
                status = false;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'resolved' or 'unresolved'.");
            }
        }

        Console.Write("Resolving Details: ");
        string resolvingDetails = Console.ReadLine();
        if (resolvingDetails == "0")
        {
            Console.WriteLine("Exiting...");
            return;
        }

        Accident accident = new Accident(accidentDate, description, status, resolvingDetails);

        Console.WriteLine();
        Console.WriteLine("Accident Report Submitted Successfully!");
        Console.WriteLine($"Accident ID: {accident.AccidentId}");
        Console.WriteLine($"Accident Date: {accident.AccidentDate}");
        Console.WriteLine($"Description: {accident.Description}");
        Console.WriteLine($"Status: {(accident.Status ? "Resolved" : "Unresolved")}");
        Console.WriteLine($"Resolving Details: {accident.ResolvingDetails}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
}
