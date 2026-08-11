using System;
using DocumentEditor.Interfaces;

namespace DocumentEditor.Repositories;

public class AzureBlob : IBlobStorageRepository
{
    public string Save(byte[] bytes, string filename)
    {
        Console.WriteLine("Image uploaded to blob");
        return $"{filename}.png";
    }
}
