using System;
using DocumentEditor.Interfaces;
using DocumentEditor.Models;
using DocumentEditor.Repositories;
using DocumentEditor.Services;

Console.WriteLine("=== 01_DocumentEditor System Demo ===");

IDocumentRepository documentRepository = new DocumentRepository();
IBlobStorageRepository blobStorageRepository = new AzureBlob();
Document document = new Document();

DocumentEditorService documentEditor = new DocumentEditorService("12345", blobStorageRepository, documentRepository, document);

documentEditor.AddTextElement("My ");
documentEditor.AddTextElement("name is ");
documentEditor.AddTextElement("Veeresh maurya ");
documentEditor.AddImageElement(Array.Empty<byte>(), "MyImage");

documentEditor.SaveDocument();

Console.WriteLine("\nRendered Document:");
Console.WriteLine(documentEditor.Render());
