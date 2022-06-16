using System.Threading;
using CsvHelper.Configuration.Attributes;

namespace MaterialManagement
{
    public class Material
    {
        static int nextId;

        public Material()
        {
            
        }

        public Material(string name, int count, int minimalCount, int toBeOrdered)
        {
            Name = name;
            Count = count;
            MinimalCount = minimalCount;
            ToBeOrdered = toBeOrdered;
            Id = Interlocked.Increment(ref nextId);
        }
        [Name("Id")]
        public int Id { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("Count")]
        public int Count { get; set; }
        [Name("MinimalCount")]
        public int MinimalCount { get; set; }
        [Name("ToBeOrdered")]
        public int ToBeOrdered { get; set; }
    }
}