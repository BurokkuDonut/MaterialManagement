using System.Collections.Generic;

namespace MaterialManagement
{
    public class Material
    {
        public Material(string name, int count, int minimalCount, int toBeOrdered)
        {
            Name = name;
            Count = count;
            MinimalCount = minimalCount;
            ToBeOrdered = toBeOrdered;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int MinimalCount { get; set; }
        public int ToBeOrdered { get; set; }
    }

    public class Shoppinglist
    {
        public List<Material> Materialshoppinglist { get; set; }
    }
}