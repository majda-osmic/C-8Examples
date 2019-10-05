using System;

#nullable disable


namespace CSharp8_Examples
{
    #region Hide for a TA-DA effect

    interface IPersonName
    {
        string First { get; }
        string Last { get; }
        string FullName() => $"{First} {Last}";
    }


    public class Parent : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Child : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Student : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class Employee : IPersonName
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class EducatedPerson : IPersonName
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string FullName() => $"{Title}, {First} {Last}";
    }

    #endregion
}
