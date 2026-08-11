using System;
using System.Collections.Generic;
using DocumentEditor.Interfaces;
using DocumentEditor.Models;

namespace DocumentEditor.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly Dictionary<string, Document> _db = new Dictionary<string, Document>();

    public Document? GetDocument(string id)
    {
        _db.TryGetValue(id, out var document);
        return document;
    }

    public void Save(string id, Document document)
    {
        _db[id] = document;
        Console.WriteLine("Saved in DB");
    }
}
