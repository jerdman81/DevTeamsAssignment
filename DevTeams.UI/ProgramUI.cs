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
                    "2. View all existing Developers\n" +
                    "3. View an Existing Developer\n" +
                    "4. Update An Existing Developer\n" +
                    "5. Delete An Existing Developer\n");
                    /*"6. View Developers Who Need Pluralsight License");*/

                // Add 5 or more DevTeam Methods
                // Add Challenge Methods

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        ViewAllExistingDevelopers();
                        break;
                    case "3":
                        ViewExistingDevelopersByID();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                   /* case "6":
                        ViewDevelopersNeedingPluralsight();
                        break;*/
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

        private void ViewExistingDevelopersByID()
        {
            Clear();
            Console.WriteLine("Which Developer ID Would You Like To View? ");
            string developerID = ReadLine();
            int developerIDInt = Convert.ToInt32(developerID);
            Developer devToFind = _devRepo.GetDeveloperbyID(developerIDInt);
            ViewExistingDeveloperDetails(devToFind);
            WaitForKeypress();
        }
        private void UpdateExistingDeveloper()
        {
            throw new NotImplementedException();
        }
        private void DeleteExistingDeveloper()
        {
            throw new NotImplementedException();
        }
        private void ViewDevelopersNeedingPluralsight()
        {
            Clear();
            Console.WriteLine("These Developers need a Pluralsight license: ");
            List<Developer> developerList = _devRepo.GetDeveloperThatNeedsLicense();
            
            WaitForKeypress();
        }


        private void WaitForKeypress()
        {
            ReadKey();
        }

        private void Seed()
        {

        }
    }
}
