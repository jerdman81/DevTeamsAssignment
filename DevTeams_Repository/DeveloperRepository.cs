using DevTeams_POCOs;
using System.Collections.Generic;

namespace DevTeams_Repository
{
    // This is our database of Developers

    public class DeveloperRepository
    {
        private readonly List<Developer> _developerContext = new List<Developer>();
        private int _count;

        //Create  -- A Developer
        public bool AddHumanToDeveloper(Developer developer)
        {
            if (developer == null)
            {
                return false;
            }
            else
            {
                _count++;
                developer.Id = _count;
                _developerContext.Add(developer);
                return true;
            }
        }


        //Read -- Return list of developers or developer

        public List<Developer> GetAllDevelopers()
        {
            return _developerContext;
        }

        //Read --  Add Helper Method so I can pull one developer, not the whole list
        public Developer GetDeveloperbyID(int id)
        {
            foreach (Developer developer in _developerContext)
            {
                if (developer.Id == id)
                {
                    return developer;
                }
            }
            //if it gets here and hasn't found anything...
            return null;
        }

        //Update -- Update a developer record

        public bool UpdateExistingDeveloper(int originalID, Developer newdata)
        {
            //find the old content...
            Developer oldDeveloper = GetDeveloperbyID(originalID); //What is the problem here?  -  Use helper method instead

            if (oldDeveloper != null)
            {
                oldDeveloper.Id = newdata.Id;
                oldDeveloper.FirstName = newdata.FirstName;
                oldDeveloper.LastName = newdata.LastName;
                oldDeveloper.HasPluralsight = newdata.HasPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete  -- remove a developer

        public bool DeleteExistingDeveloper(Developer exitsingDeveloper)
        {
            bool deleteDeveloper = _developerContext.Remove(exitsingDeveloper);
            return deleteDeveloper;
        }



        // Create list of all developers that need Pluralsight license
        // Read

        public List<Developer> GetDeveloperThatNeedsLicense()
        {
            List<Developer> devsThatNeedLicense = new List<Developer>();
            foreach (Developer developer in _developerContext)
            {
                if (developer.HasPluralsight == false)
                {
                    devsThatNeedLicense.Add(developer);
                }
            }
            return devsThatNeedLicense;

            //  return _developerContext.Where(m => !m.HasPluralsight).ToList();   <-Alternative

        }



    }

}