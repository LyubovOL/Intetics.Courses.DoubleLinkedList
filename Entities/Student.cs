namespace Entities
{
    public class Student : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

	    public Student(string firstName, string lastName)
	    {
		    FirstName = firstName;
		    LastName = lastName;
		    Age = 20;
	    }

        public override string ToString()
        {
            return string.Format("{0} {1} : {2}", FirstName, LastName, Age);
        }
    }
}
