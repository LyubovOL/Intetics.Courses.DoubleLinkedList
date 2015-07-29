namespace Entities
{
    public class Student : IPerson
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
		
		// new constructor
        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} : {2}", FirstName, LastName, Age);
        }
    }
}
