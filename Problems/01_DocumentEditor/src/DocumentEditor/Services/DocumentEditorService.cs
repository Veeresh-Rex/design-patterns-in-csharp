using DocumentEditor.Elements;
using DocumentEditor.Interfaces;
using DocumentEditor.Models;

namespace DocumentEditor.Services;

public class DocumentEditorService
{
    private readonly IBlobStorageRepository _blobStorageRepository;
    private readonly IDocumentRepository _documentRepository;
    private readonly Document _document;
    private readonly string _id;

    public DocumentEditorService(string id, IBlobStorageRepository blobStorageRepository, IDocumentRepository documentRepository, Document document)
    {
        _id = id;
        _blobStorageRepository = blobStorageRepository;
        _documentRepository = documentRepository;
        _document = document;
    }

    public void AddTextElement(string text)
    {
        _document.AddElement(new TextElement(text));
    }

    public void AddImageElement(byte[] image, string fileName)
    {
        var blobUrl = _blobStorageRepository.Save(image, fileName);
        _document.AddElement(new ImageElement(blobUrl));
    }

    public void SaveDocument()
    {
        _documentRepository.Save(_id, _document);
    }

    public string Render()
    {
        return _document.RenderDocument();
    }

    public Document? LoadDocument(string id)
    {
        return _documentRepository.GetDocument(id);
    }
}
