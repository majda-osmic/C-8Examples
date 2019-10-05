namespace CSharp_Examples
{
    interface IPersonName
    {
        string First { get; }
        string Last { get; }
        string FullName();
    }


    public class Parent : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string FullName() => $"{First} {Last}";
    }

    public class Child : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string FullName() => $"{First} {Last}";
    }

    public class Student : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string FullName() => $"{First} {Last}";
    }

    public class Employee : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string FullName() => $"{First} {Last}";
    }

    public class EducatedPerson : IPersonName
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string FullName() => $"{Title}, {First} {Last}";
    }

}
