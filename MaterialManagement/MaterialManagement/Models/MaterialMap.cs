using CsvHelper.Configuration;

namespace MaterialManagement.Models
{
    public sealed class MaterialMap : ClassMap<Material>
    {
        public MaterialMap()
        {
            Map(m => m.Id).Index(0).Name("Id");
            Map(m => m.Name).Index(1).Name("Name");
            Map(m => m.Count).Index(2).Name("Count");
            Map(m => m.MinimalCount).Index(3).Name("MinimalCount");
            Map(m => m.ToBeOrdered).Index(4).Name("ToBeOrdered");
        }
    }
}