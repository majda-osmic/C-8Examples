
namespace Shared
{
    public class City
    {
        public string Name { get; set; }
        public int ZipCode { get; set; }

        //available starting C#7
        public void Deconstruct(out string name, out int zipCode) => (name, zipCode) = (Name, ZipCode);
    }
}
