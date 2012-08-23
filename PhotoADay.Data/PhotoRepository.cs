using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoADay.Data
{
    public class PhotoRepository : PhotoADay.Data.IPhotoRepository
    {
        private PhotoContext _db;

        public PhotoRepository() : 
            this(new PhotoContext())
        {
        }

        public PhotoRepository(PhotoContext db)
        {
            this._db = db;
        }

        public Photo Get(int id)
        {
            return _db.Photos.SingleOrDefault(x => x.ID == id);
        }

        public IQueryable<Photo> GetAll()
        {
            return _db.Photos;
        }

        public Photo Add(Photo p)
        {
            this._db.Photos.Add(p);
            this._db.SaveChanges();
            return p;
        }

        public Photo Update(Photo p)
        {
            _db.Entry(p).State = System.Data.EntityState.Modified;
            _db.SaveChanges();
            return p;
        }

        public void Delete(int id)
        {
            var photo = Get(id);
            _db.Photos.Remove(photo);
            _db.SaveChanges();
        }
    }
}
