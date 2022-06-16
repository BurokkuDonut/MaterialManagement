using System;
using System.Collections.Generic;
using System.Linq;

namespace MaterialManagement.Models
{
    public class DataProvider : IDataProvider
    {
        private readonly CsvReadWriter _csvReadWriter;

        public DataProvider()
        {
            _csvReadWriter = new CsvReadWriter();
        }

        public List<Material> GetMaterials()
        {
            var allLines = _csvReadWriter.ReadAllAsync().Result;
            return allLines;
        }

        public void AddMaterial(Material material)
        {
            string line = String.Join(',', material.Id, material.Name, material.Count, material.MinimalCount,
                material.ToBeOrdered);
            _csvReadWriter.WriteAsync(material);
        }

        public void EditMaterial(Material material)
        {
            string line = String.Join(',', material.Id, material.Name, material.Count, material.MinimalCount,
                material.ToBeOrdered);
            _csvReadWriter.WriteByIdAsync(material);
        }
    }
}