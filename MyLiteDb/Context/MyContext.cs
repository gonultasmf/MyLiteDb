namespace MyLiteDb.Context;

public class MyContext
{
    private static LiteDatabase _db;

    public LiteDatabase GetLiteDB()
    {
        var path = FileSystem.AppDataDirectory;
        var fullPath = Path.Combine(path, "MyLiteDb.db");
        _db = new LiteDatabase(fullPath);

        return _db;
    }

    public void DbDispose() => _db.Dispose();
}
