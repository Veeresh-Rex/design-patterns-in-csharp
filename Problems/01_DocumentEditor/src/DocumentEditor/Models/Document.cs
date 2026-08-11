using System;
using System.Collections.Generic;
using System.Text;
using DocumentEditor.Elements;

namespace DocumentEditor.Models;

public class Document
{
    private readonly List<IDocumentElement> _documentElements = new List<IDocumentElement>();
    public Guid Id { get; } = Guid.NewGuid();

    public void AddElement(IDocumentElement element)
    {
        _documentElements.Add(element);
    }

    public string RenderDocument()
    {
        StringBuilder doc = new StringBuilder();

        foreach (IDocumentElement element in _documentElements)
        {
            doc.Append(element.Render());
        }

        return doc.ToString();
    }
}
