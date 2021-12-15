using DevTeams_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    // This is our database of Developers

    public class DeveloperRepository
    {
        private readonly List<Developer> _developerContext = new List<Developer>();


        //Create  -- A Developer
        public bool AddHumanToDeveloper(Developer developer)
        {
            int startingCount = _developerContext.Count;
            _developerContext.Add(developer);

            bool wasAdded = (_developerContext.Count > startingCount) ? true : false;
            return wasAdded;
        }  // Will work but will allow Developers with same ID (match dev tem repository code)


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
    }

}