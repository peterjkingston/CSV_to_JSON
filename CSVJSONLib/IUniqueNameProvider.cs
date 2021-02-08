namespace CSVJSONLib
{
    public interface IUniqueNameProvider
    {
        string GetUniqueName(string[] names, string preferredName);
        string GetUniqueName(string[] names);
    }
}