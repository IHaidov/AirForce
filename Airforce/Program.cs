﻿using System.Configuration;

namespace Alesik.Haidov.Airforce
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string libraryName = ConfigurationManager.AppSettings["DAOLibraryName"];
            BLC.BLC blc = new BLC.BLC(libraryName);

            Console.WriteLine($"------ US Air Forces bases ------\n");


            foreach (var airforceBase in blc.GetAllAirforceBases())
            {
                Console.WriteLine($"Name: {airforceBase.Name}\nLocation: {airforceBase.Location}\n");
            }

            Console.WriteLine($"\n------ US Air Forces planes ------\n");

            foreach (var aircraft in blc.GetAllAircrafts())
            {
                Console.WriteLine($"Model: {aircraft.Model}\nType: {aircraft.Type}\nService hours: {aircraft.ServiceHours}\n");
            }
            Console.ReadLine();
        }
    }
}