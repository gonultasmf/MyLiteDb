using System.Linq.Expressions;

namespace MyLiteDb.Repositories;

public interface IGenericRepo<TModel> where TModel : BaseModel
{
    // QUERY
    List<TModel> GetAll();
    List<TModel> GetAll(Expression<Func<TModel, bool>> expression);

    TModel Get(int id);
    TModel Get(Expression<Func<TModel, bool>> expression);

    int Count();
    int Count(Expression<Func<TModel, bool>> expression);

    // COMMAND
    bool Add(TModel model);
    bool Update(TModel model);
    bool Delete(int id);
    bool Delete(Expression<Func<TModel, bool>> expression);

    string UploadFile(string fileName, byte[] data);
    byte[] DownloadFile(string fileId);

    ILiteCollection<TModel> Table { get; }
    ILiteStorage<string> Storage { get; }

    void Save();
}
