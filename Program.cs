using StudentClubApp;
using System;
using System.Collections.Generic;

namespace StudentClubApp
{
    //StudentClub Class
    public class StudentClub
    {
        private double budget;
        public ClubRole president { get; set; }
        public ClubRole vicePresident { get; set; }
        public ClubRole generalSecretary { get; set; }
        public ClubRole financeSecretary { get; set; }
        private List<Society> societies;

        //Constructor
        public StudentClub()
        {
            societies = new List<Society>();
        }

        //Function to initialize
        public void InitializeSocieties()
        {
            societies.Add(new FundedSociety("Techbit", "Mehmood", 600));
            societies.Add(new FundedSociety("Literary", "Naveena", 500));
            societies.Add(new FundedSociety("Sports", "Ali", 500));
            societies.Add(new NonFundedSociety("Media", "Moiz"));
        }

        //Function to register
        public void RegisterSociety()
        {
            Console.Write("Enter society name: ");
            string name = Console.ReadLine();
            Console.Write("Enter contact person: ");
            string contact = Console.ReadLine();
            societies.Add(new NonFundedSociety(name, contact));
            Console.WriteLine("Society registered successfully.");
        }

        //Function to dspense funds
        public void DispenseFunds()
        {
            foreach (var society in societies)
            {
                if (society is FundedSociety fundedSociety)
                {
                    Console.WriteLine($"{fundedSociety.Name} has received ${fundedSociety.FundingAmount}.");
                }
            }
        }

        //Function to register events
        public void RegisterEvent()
        {
            Console.Write("Enter society name: ");
            string name = Console.ReadLine();
            Society society = societies.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (society != null)
            {
                Console.Write("Enter event name: ");
                string eventName = Console.ReadLine();
                society.AddActivity(eventName);
                Console.WriteLine("Event registered successfully.");
            }
            else
            {
                Console.WriteLine("Society not found.");
            }
        }

        //Function to Display Societies
        public void DisplaySocieties()
        {
            foreach (var society in societies)
            {
                Console.WriteLine($"Society: {society.Name}, Contact: {society.Contact}, Funding: {(society is FundedSociety ? ((FundedSociety)society).FundingAmount.ToString() : "None")}");
            }
        }

        //Function to display events
        public void DisplayEvents()
        {
            Console.Write("Enter society name: ");
            string name = Console.ReadLine();
            Society society = societies.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (society != null)
            {
                society.ListEvents();
            }
            else
            {
                Console.WriteLine("Society not found.");
            }
        }
    }

    //Society class
    public class Society
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        private List<string> activities;

        //Constructor
        public Society(string name, string contact)
        {
            Name = name;
            Contact = contact;
            activities = new List<string>();
        }

        //Function to add activities
        public void AddActivity(string activity)
        {
            activities.Add(activity);
        }

        //Function to list events
        public void ListEvents()
        {
            Console.WriteLine($"Events for {Name}:");
            foreach (var activity in activities)
            {
                Console.WriteLine(activity);
            }
        }
    }

    //Funded society inherits from Society class
    public class FundedSociety : Society
    {
        public double FundingAmount { get; set; }

        public FundedSociety(string name, string contact, double fundingAmount) : base(name, contact)
        {
            FundingAmount = fundingAmount;
        }
    }

    //non funded society inherits from society class
    public class NonFundedSociety : Society
    {
        public NonFundedSociety(string name, string contact) : base(name, contact) { }
    }

    //club role class
    public class ClubRole
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string ContactInfo { get; set; }
    }
}

//Main class
class Program
{
    static void Main(string[] args)
    {
        StudentClub studentClub = new StudentClub();
        studentClub.InitializeSocieties();
        int choice;

        do
        {
            Console.WriteLine("1. Register a new society");
            Console.WriteLine("2. Allocate funding to societies");
            Console.WriteLine("3. Register an event for a society");
            Console.WriteLine("4. Display Society Funding Information");
            Console.WriteLine("5. Display events for society");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            //Switch case

            switch (choice)
            {
                case 1:
                    studentClub.RegisterSociety();
                    break;
                case 2:
                    studentClub.DispenseFunds();
                    break;
                case 3:
                    studentClub.RegisterEvent();
                    break;
                case 4:
                    studentClub.DisplaySocieties();
                    break;
                case 5:
                    studentClub.DisplayEvents();
                    break;
            }
        } while (choice != 6);
    }
}
