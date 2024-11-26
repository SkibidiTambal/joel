namespace BlazorAppDataBinding2
{
    public class Person
    {
        private string firstName;
        
        private string lastName;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
