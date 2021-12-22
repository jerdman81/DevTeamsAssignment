using DevTeams_POCOs;
using DevTeams_Repository;
using System;
using System.Collections.Generic;
using static System.Console; // Makes it so you don't have to say Console. before ReadLine or WriteLine

namespace DevTeams.UI
{
    public class ProgramUI
    {
        // need to add links to be able to use the existing repositories
        private readonly DeveloperRepository _devRepo;
        private readonly DeveloperTeamRepository _devTeamRepo;

        // make an empty constructor
        public ProgramUI()
        {
            _devRepo = new DeveloperRepository();
            _devTeamRepo = new DeveloperTeamRepository(_devRepo);
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }



        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Dev Teams\n" +
                    "1. Add a Developer\n" +
                    "2. Add a DevTeam\n" +
                    "3. View Existing Developers\n" +
                    "4. View Existing DevTeams\n" +
                    "5. Add A Developer to a DevTeam\n" +
                    "6. Remove A Developer from a DevTeam\n" +
                    "7. View List of Developers needing Pluralsight License");

                // Add 5 or more DevTeam Methods
                // Add Challenge Methods

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        AddDevTeam();
                        break;
                    case "3":
                        ViewAllExistingDevelopers();
                        break;
                    case "4":
                        ViewAllExistingDevTeams();
                        break;
                    case "5":
                        AddDeveloperToTeam();
                        break;
                    case "6":
                        RemoveDeveloperFromTeam();
                        break;
                    case "7":
                        ViewDevelopersNeedingPluralsight();
                        break;
                    default:
                        WriteLine("Invalid Selection");
                        WaitForKeypress();
                        break;
                }
                Clear();
            }
        }
        private void AddDeveloper()
        {
            Clear();
            Developer developer = new Developer();
            WriteLine("Please Enter First Name: ");
            string firstName = ReadLine();
            developer.FirstName = firstName;

            WriteLine("Please Enter Last Name: ");
            string lastName = ReadLine();
            developer.LastName = lastName;

            WriteLine("Does this Developer Have a Pluralsight license? (true/false) ");
            string yesOrNo = ReadLine();
            string yesOrNoLower = yesOrNo.ToLower();
            bool hasPluralsight = bool.Parse(yesOrNoLower);
                        
            developer.HasPluralsight = hasPluralsight;

            _devRepo.AddHumanToDeveloper(developer);
        }
        private void ViewAllExistingDevelopers()
        {
            Clear();
            Console.WriteLine("All Existing Developers: \n");
            List<Developer> developerList = _devRepo.GetAllDevelopers();
            foreach (Developer developer in developerList)
            {
                ViewExistingDeveloperDetails (developer);
            }
            WaitForKeypress();
        }
        private void ViewExistingDeveloperDetails (Developer developer)
        {
            Console.WriteLine(
                $"Developer ID: {developer.Id} \n" +
                $"Developer Name: {developer.FullName} \n" +
                $"Has Pluralsight License: {developer.HasPluralsight} \n" +
                $"========================================================= \n");

        }

        private void AddDevTeam()
        {
            Clear();
            DevTeam team = new DevTeam();
            WriteLine("Please Enter The Team Name: ");
            string teamName = ReadLine();
            team.TeamName = teamName;
            _devTeamRepo.AddDevTeam(team);
        }

        private void ViewAllExistingDevTeams()
        {
            Clear();
            Console.WriteLine("All Existing DevTeams: \n");
            List<DevTeam> devTeamList = _devTeamRepo.GetAllTeams();
            foreach (DevTeam devTeam in devTeamList)
            {
                ViewExistingDevTeamDetails (devTeam);
            }
            WaitForKeypress();
        }

        private void ViewExistingDevTeamDetails(DevTeam devTeam)
        {
            Console.WriteLine(
                $"DevTeam ID: {devTeam.Id} \n" +
                $"DevTeam Name: {devTeam.TeamName} \n" +
                $"Developers: ");
            foreach (var dev in devTeam.Developers)
            {
                Console.WriteLine(dev.FullName);
            }
            Console.WriteLine("\n" +
                "***************************************");

        }

        private void AddDeveloperToTeam()
        {
            Console.Clear();
            Console.WriteLine("Which Team Would You Like to Add Developers To? (input ID):");
            string devTeamNumber = ReadLine();
            int devTeamNumberInt = Convert.ToInt32(devTeamNumber);
            Console.WriteLine("Which Developer would you like to add to this DevTeam? (input ID):");
            string developer = ReadLine();
            int developerInt = Convert.ToInt32(developer);
            _devTeamRepo.AddDeveloperToExistingTeam(devTeamNumberInt, developerInt);

        }

        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            Console.WriteLine("Which Team Would You Like to Remove Developers From? (input ID):");
            string devTeamNumber = ReadLine();
            int devTeamNumberInt = Convert.ToInt32(devTeamNumber);
            Console.WriteLine("Which Developer would you like to remove from this DevTeam? (input ID):");
            string developer = ReadLine();
            int developerInt = Convert.ToInt32(developer);
            _devTeamRepo.RemoveDeveloperFromExistingTeam(devTeamNumberInt, developerInt);
        }

        private void ViewDevelopersNeedingPluralsight()
        {
            throw new NotImplementedException();
        }

        private void WaitForKeypress()
        {
            ReadKey();
        }

        private void Seed()
        {
            //Seed both Developers & DevTeams

            Developer dev1 = new Developer();
            dev1.FirstName = "Jeffrey";
            dev1.LastName = "Lebowski";
            dev1.HasPluralsight = true;
            _devRepo.AddHumanToDeveloper(dev1);

            Developer dev2 = new Developer();
            dev2.FirstName = "Walter";
            dev2.LastName = "Sobchak";
            dev2.HasPluralsight = false;
            _devRepo.AddHumanToDeveloper(dev2);

            Developer dev3 = new Developer();
            dev3.FirstName = "Donny";
            dev3.LastName = "Kerabatsos";
            dev3.HasPluralsight = false;
            _devRepo.AddHumanToDeveloper(dev3);

            Developer dev4 = new Developer();
            dev4.FirstName = "Uli";
            dev4.LastName = "Kunkel";
            dev4.HasPluralsight = false;
            _devRepo.AddHumanToDeveloper(dev4);

            DevTeam team1 = new DevTeam();
            team1.TeamName = "Urban Achievers";
            team1.Developers = new List<Developer>() { dev1, dev2, dev3};
            _devTeamRepo.AddDevTeam(team1);

            DevTeam team2 = new DevTeam();
            team2.TeamName = "The Dude";
            team2.Developers = new List<Developer>() { };
            _devTeamRepo.AddDevTeam(team2);

            DevTeam team3 = new DevTeam();
            team3.TeamName = "The Nihilists";
            team3.Developers = new List<Developer>() { dev4 };
            _devTeamRepo.AddDevTeam(team3);
            
            
        }
    }
}
