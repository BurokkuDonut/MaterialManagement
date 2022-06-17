using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaterialManagement.Models
{
    public interface IDataProvider
    {
        List<Material> GetMaterials();
        Task AddMaterial(Material material);
        Task EditMaterial(Material material);
        Task DeleteMaterial(int id);
    }
}