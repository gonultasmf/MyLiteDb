namespace MyLiteDb;

public static class HotReloadHandler
{
    public static event Action<Type[]?>? UpdateApplicationEvent;
    internal static void ClearCache(Type[]? types) { }
    internal static void UpdateApplication(Type[]? types)
    {
        UpdateApplicationEvent?.Invoke(types);
    }
}
