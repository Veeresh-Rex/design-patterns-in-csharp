using System;
using DocumentEditor.Models;
using DocumentEditor.Repositories;
using DocumentEditor.Services;
using Xunit;

namespace DocumentEditor.Tests;

public class DocumentEditorTests
{
    [Fact]
    public void Render_ShouldCombineTextAndImageElements()
    {
        var docRepo = new DocumentRepository();
        var blobRepo = new AzureBlob();
        var doc = new Document();
        var editor = new DocumentEditorService("DOC-1", blobRepo, docRepo, doc);

        editor.AddTextElement("Hello ");
        editor.AddImageElement(Array.Empty<byte>(), "photo");

        var rendered = editor.Render();

        Assert.Equal("Hello [Image: photo.png]", rendered);
    }

    [Fact]
    public void SaveDocument_ShouldStoreDocumentInRepository()
    {
        var docRepo = new DocumentRepository();
        var blobRepo = new AzureBlob();
        var doc = new Document();
        var editor = new DocumentEditorService("DOC-1", blobRepo, docRepo, doc);

        editor.AddTextElement("Content");
        editor.SaveDocument();

        var retrieved = editor.LoadDocument("DOC-1");

        Assert.NotNull(retrieved);
        Assert.Equal("Content", retrieved.RenderDocument());
    }
}
