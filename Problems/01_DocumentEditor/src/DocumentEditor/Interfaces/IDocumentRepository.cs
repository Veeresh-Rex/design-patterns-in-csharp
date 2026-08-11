using DocumentEditor.Models;

namespace DocumentEditor.Interfaces;

public interface IDocumentRepository
{
    void Save(string id, Document document);
    Document? GetDocument(string id);
}
