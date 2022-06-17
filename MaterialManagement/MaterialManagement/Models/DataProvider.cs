using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialManagement.Models
{
    public class DataProvider : IDataProvider
    {
        private readonly ICsvReadWriter _csvReadWriter;

        public DataProvider()
        {
            _csvReadWriter = new CsvReadWriter();
        }

        public List<Material> GetMaterials()
        {
            var allLines = _csvReadWriter.ReadAllAsync().Result;
            return allLines;
        }

        public Task AddMaterial(Material material)
        {
            string line = String.Join(',', material.Id, material.Name, material.Count, material.MinimalCount,
                material.ToBeOrdered);
            return _csvReadWriter.WriteAsync(material);
        }

        public Task EditMaterial(Material material)
        {
            string line = String.Join(',', material.Id, material.Name, material.Count, material.MinimalCount,
                material.ToBeOrdered);
            return _csvReadWriter.WriteByIdAsync(material);
        }

        public Task DeleteMaterial(int id)
        {
            return _csvReadWriter.DeleteByIdAsync(id);
        }
    }
}