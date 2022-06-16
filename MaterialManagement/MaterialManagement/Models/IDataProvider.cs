using System.Collections.Generic;

namespace MaterialManagement.Models
{
    public interface IDataProvider
    {
        List<Material> GetMaterials();
        void AddMaterial(Material material);
        void EditMaterial(Material material);
    }
}