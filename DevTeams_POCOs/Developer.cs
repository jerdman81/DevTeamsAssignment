namespace DevTeams_POCOs
{
    // Plain Old C# Object

    /*
     Developers have names and ID numbers;
     we need to be able to identify one developer without mistaking them for another.
     We also need to know whether or not they have access to the online learning tool: Pluralsight.
     */

    public class Developer
    {

        public Developer() { }

        public Developer(int id, string firstName, string lastName, bool hasPluralsight)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            HasPluralsight = hasPluralsight;
        }

        // unique identifier
        public int Id { get; set; }  //Property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public bool HasPluralsight { get; set; }
    }

}