using System.Collections.Generic;

namespace MaterialManagement.Models
{
    public class DataProvider : IDataProvider
    {
        public List<Material> GetMaterials()
        {
            return new List<Material>()
            {
                new Material("Chips", 1, 3, 2),
                new Material("Popcorn", 1, 4, 3)
            };
        }
    }
}