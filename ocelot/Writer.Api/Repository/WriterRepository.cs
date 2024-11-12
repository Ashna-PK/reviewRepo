
namespace Writer.Api.Repository
{
    public class WriterRepository : List<Models.Writer>,
IWriterRepository
    {
        public Models.Writer? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.Writer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Models.Writer Insert(Models.Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
