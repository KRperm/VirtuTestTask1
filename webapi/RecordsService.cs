using webapi.Models;

namespace webapi
{
    public interface IRecordsService
    {
        IEnumerable<Record> GetAll();
        Record Get(Guid id);
        void Create(Record record);
        void Update(Record recordWithNewValues);
        void Delete(Record recordToDelete);
    }

    public class RecordsService : IRecordsService
    {
        public DataContext DataContext { get; }

        public RecordsService(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IEnumerable<Record> GetAll()
        {
            return DataContext.Records.ToArray();
        }

        public Record Get(Guid id)
        {
            return DataContext.Records.SingleOrDefault(x => x.Id == id);
        }

        public void Create(Record record)
        {
            DataContext.Records.Add(record);
            DataContext.SaveChanges();
        }

        public void Update(Record recordWithNewValues)
        {
            DataContext.Records.Update(recordWithNewValues);
            DataContext.SaveChanges();
        }

        public void Delete(Record recordToDelete)
        {
            DataContext.Records.Remove(recordToDelete);
            DataContext.SaveChanges();
        }
    }
}
