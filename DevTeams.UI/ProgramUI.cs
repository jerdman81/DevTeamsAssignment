using DevTeams_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    "5.  Delete An Existing Developer\n");
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
                        ViewExistingDeveloper();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    default:
                        WriteLine("Invalid Selection");
                        WaitForKeypress();
                        break;
                }
                Clear();
            }
        }

        private void DeleteExistingDeveloper()
        {
            throw new NotImplementedException();
        }

        private void UpdateExistingDeveloper()
        {
            throw new NotImplementedException();
        }

        private void ViewExistingDeveloper()
        {
            throw new NotImplementedException();
        }

        private void AddDeveloper()
        {
            throw new NotImplementedException();
        }

        private void ViewAllExistingDevelopers()
        {
            throw new NotImplementedException();
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
