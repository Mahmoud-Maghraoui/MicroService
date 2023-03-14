using PlateformService.Models;

namespace PlateformService.Data
{
    public interface IPlateformRepo
    {
        public void SaveChanges();
        public IEnumerable<Plateform> GetPlatforms();
        public Plateform GetPlateformById(int id);
        public void DeletePlateform(Plateform plateform);
        public void CreatePlateform(Plateform plateform);
    }
}
