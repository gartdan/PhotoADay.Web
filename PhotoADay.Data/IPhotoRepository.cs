using System;
namespace PhotoADay.Data
{
    public interface IPhotoRepository
    {
        Photo Add(Photo p);
        void Delete(int id);
        Photo Get(int id);
        System.Linq.IQueryable<Photo> GetAll();
        Photo Update(Photo p);
    }
}
