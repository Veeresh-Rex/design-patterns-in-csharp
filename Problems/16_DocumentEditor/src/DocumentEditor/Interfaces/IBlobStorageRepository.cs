namespace DocumentEditor.Interfaces;

public interface IBlobStorageRepository
{
    string Save(byte[] bytes, string filename);
}
