using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialManagement.Models
{
    public class CsvReadWriter : ICsvReadWriter
    {
        public string Path { get; set; }

        public Task WriteAsync(string line)
        {
            using (var writer = new StreamWriter(Path, true))
            {
                if (!File.Exists(Path))
                {
                    ;
                    File.Create(Path);
                }

                writer.WriteLineAsync(line);

                return Task.CompletedTask;
            }
        }


        public async Task<List<string>> ReadAllAsync()
        {
            using (var reader = new StreamReader(Path))
            {
                var stringList = new List<string>();
                while (!reader.EndOfStream)
                {
                    stringList.Add(await reader.ReadLineAsync().ConfigureAwait(false));
                }

                return stringList;
            }
        }


        public Task WriteByIdAsync(string material, int lineToEdit)
        {
            return LineChangerAsync(material, Path, lineToEdit);
        }


        public Task WriteDeleteByIdAsync(int lineToDelete)
        {
            return LineRemoverAsync(Path, lineToDelete);
        }


        private static Task LineRemoverAsync(string fileName, int lineToDelete)
        {
            var arrLine = File.ReadAllLines(fileName);
            var arrLineEdited = arrLine.Where(line => line != arrLine[lineToDelete]);
            File.WriteAllLines(fileName, arrLineEdited);
            return Task.CompletedTask;
        }


        private static Task LineChangerAsync(string newText, string fileName, int lineToEdit)
        {
            var arrLine = File.ReadAllLines(fileName);
            arrLine[lineToEdit] = newText;
            File.WriteAllLines(fileName, arrLine);
            return Task.CompletedTask;
        }
    }

    public interface ICsvReadWriter
    {
        Task WriteAsync(string line);
        Task<List<string>> ReadAllAsync();

    }
}