using DevTeams_POCOs;
using System.Collections.Generic;

namespace DevTeams_Repository
{
    // This is our database of Teams


    /*Managers need to bea able to add and remove members to/from a team by their unique identifier
     They should be able to see a list of existing developers to choose from and add to existing teams.
    Manager will create a team, then add developers individually from the Developer Directory to that team*/
    public class DeveloperTeamRepository
    {
        private readonly List<DevTeam> _devTeamContext = new List<DevTeam>();

        private DeveloperRepository _developerRepository;  // This brings in the Developer Repository wihtout changing it.  If you instantiate a new it will overwrite existing.

        private int _count;

        public DeveloperTeamRepository(DeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }
        //Create
        public bool AddDevTeam(DevTeam devTeam)
        {
            if (devTeam == null)
            {
                return false;
            }
            else
            {
                _count++;
                devTeam.Id = _count;
                _devTeamContext.Add(devTeam);
                return true;
            }
        }

        //Read
        public List<DevTeam> GetAllTeams()
        {
            return _devTeamContext;
        }

        // Add helper method to get just one team by ID

        public DevTeam GetDevTeamById(int id)
        {
            foreach (DevTeam devTeam in _devTeamContext)
            {
                if (devTeam.Id == id)
                {
                    return devTeam;
                }
            }
            //if it gets here and hasn't found anything...
            return null;
        }

        //Update
        public bool UpdateExistingDevTeam(int originalID, DevTeam newdata)
        {
            //find the old content...
            DevTeam oldDevTeam = GetDevTeamById(originalID); //Use helper method to pull single team by ID

            if (oldDevTeam != null)
            {
                oldDevTeam.Id = newdata.Id;
                oldDevTeam.TeamName = newdata.TeamName;
                oldDevTeam.Developers = newdata.Developers;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Update  -  Add a single developer to an existing team

        public bool AddDeveloperToExistingTeam(int teamID, int developerID)                 //Return type - do we need it to report back in any way
        {
            DevTeam devTeam = GetDevTeamById(teamID);                                      // Call a specificteam
            Developer devToAdd = _developerRepository.GetDeveloperbyID(developerID);       // Call a specific Developer
            foreach (var dev in devTeam.Developers)
            {
                if (dev.FullName == devToAdd.FullName)
                {
                    return false;
                }
            }
            devTeam.Developers.Add(devToAdd);                                             //  Add specific Developer to Team   
            return true;
        }

        //Update  -  Remove a single developer to an existing team

        public void RemoveDeveloperFromExistingTeam(int teamID, int developerID)           // Return type - do we need it to report back in any way (void, bool, string, etc)
        {
            DevTeam devTeam = GetDevTeamById(teamID);                                      // Call a specificteam
            Developer devToRemove = _developerRepository.GetDeveloperbyID(developerID);       // Call a specific Developer
            devTeam.Developers.Remove(devToRemove);                                             //  Add specific Developer to Team
        }


        // Update -- Add multiple developers to an existing team at once


    }




}