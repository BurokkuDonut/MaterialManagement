using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using MaterialManagement.ViewModels;

namespace MaterialManagement.Models
{
    public class CsvReadWriter : ICsvReadWriter
    {
        public string MaterialPath { get; set; } = Path.Combine(Environment.CurrentDirectory, "Data.csv");

        public Task WriteAsync(Material line)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var stream = File.Open(MaterialPath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecord(line);
                csv.NextRecord();
            }

            return Task.CompletedTask;
        }

        public Task<List<Material>> ReadAllAsync()
        {
            CreateFileIfNotExisting();

            List<Material> materials;
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            using (var reader = new StreamReader(MaterialPath))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Context.RegisterClassMap<MaterialMap>();
                    materials = csv.GetRecords<Material>().ToList();
                }
            }

            return Task.FromResult(materials);
        }

        private void CreateFileIfNotExisting(bool exectue = false)
        {
            if (File.Exists(MaterialPath) && !exectue) return;
            using (var stream = File.Open(MaterialPath, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csv.WriteHeader<Material>();
                        csv.NextRecord();
                    }
                }
            }
        }


        public Task WriteByIdAsync(Material material)
        {
            return LineChangerAsync(material);
        }


        public Task WriteDeleteByIdAsync(int lineToDelete)
        {
            return LineRemoverAsync(MaterialPath, lineToDelete);
        }


        private static Task LineRemoverAsync(string fileName, int lineToDelete)
        {
            var arrLine = File.ReadAllLines(fileName);
            var arrLineEdited = arrLine.Where(line => line != arrLine[lineToDelete]);
            File.WriteAllLines(fileName, arrLineEdited);
            return Task.CompletedTask;
        }


        private Task LineChangerAsync(Material newText)
        {
            var mats = ReadAllAsync().Result;
            mats.First(m => m.Id == newText.Id).Count = newText.Count;
            mats.First(m => m.Id == newText.Id).Name = newText.Name;
            mats.First(m => m.Id == newText.Id).MinimalCount = newText.MinimalCount;

            CreateFileIfNotExisting(true);

            foreach (var material in mats)
            {
                WriteAsync(material);
            }

            return Task.CompletedTask;
        }
    }

    public interface ICsvReadWriter
    {
        Task WriteAsync(Material line);
        Task<List<Material>> ReadAllAsync();
    }
}