﻿using DevTeams_POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Repository
{
    // This is our database of Teams

    /*Managers need to bea able to add and remove members to/from a team by their unique identifier
     They should be able to see a list of existing developers to choose from and add to existing teams.
    Manager will create a team, then add developers individually from the Developer Directory to that team*/
    public class DeveloperTeamRepository
    {
        private readonly List<DevTeam> _devTeamContext = new List<DevTeam>();
        private int _count;

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
            DevTeam oldDevTeam = GetDevTeamById(originalID); //What is the problem here? Need to use helper method to fix.

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

        //Delete
        public bool DeleteExistingTeam(DevTeam existingDevTeam)
        {
            bool deleteDevTeam = _devTeamContext.Remove(existingDevTeam);
            return deleteDevTeam;
        }

    }




}