using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace MaterialManagement
{
    public class Material : INotifyPropertyChanged
    {
        static int nextId;
        private int _count;

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

        [Name("Id")] public int Id { get; set; }
        [Name("Name")] public string Name { get; set; }

        [Name("Count")]
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                Task.Run(() => OnPropertyChanged(nameof(Count)));
            }
        }
        [Name("MinimalCount")]
        public int MinimalCount { get; set; }
        [Name("ToBeOrdered")]
        public int ToBeOrdered 
        {   get=>toBeOrdered;
            set { toBeOrdered = value;
                OnPropertyChanged(nameof(ToBeOrdered));} 
        }

        private int toBeOrdered { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}