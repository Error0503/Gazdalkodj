namespace Gazdalkodj
{
    public interface IData
    {
        void Create(string name);
        int Get(string name);
        void Set(string name, int value);

    }
}