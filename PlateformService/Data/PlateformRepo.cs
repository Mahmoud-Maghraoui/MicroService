using PlateformService.Models;

namespace PlateformService.Data
{
    public class PlateformRepo : IPlateformRepo
    {
        private readonly AppDbContext _dbContext;

        public PlateformRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreatePlateform(Plateform plateform)
        {
            if (plateform != null)
                _dbContext.Plateforms.Add(plateform);
        }

        public void DeletePlateform(Plateform plateform)
        {
            if (plateform != null)
                _dbContext.Plateforms.Remove(plateform);
        }

        public Plateform GetPlateformById(int id)
        {
            return _dbContext.Plateforms.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Plateform> GetPlatforms()
        {
            return _dbContext.Plateforms;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
