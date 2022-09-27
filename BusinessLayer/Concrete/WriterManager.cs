using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void Delete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetByID(id);
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterByID(int id)
        {
            return _writerDal.GetListAll(x => x.WriterID == id);
        }

        public void Update(Writer t)
        {
            _writerDal.Update(t);
        }

    }
}
