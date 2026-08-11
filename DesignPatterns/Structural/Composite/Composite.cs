using System;
using System.Collections.Generic;

namespace Csharp_design_patterns_lab.DesignPatterns.Structural.Composite;

public interface IFileSystemItem
{
    string Name { get; }
    int GetSize();
    void Print(int depth = 0);
}

public class FileItem : IFileSystemItem
{
    public string Name { get; }
    private readonly int _size;

    public FileItem(string name, int size)
    {
        Name = name;
        _size = size;
    }

    public int GetSize() => _size;

    public void Print(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}- File: {Name} ({_size} KB)");
    }
}

public class DirectoryItem : IFileSystemItem
{
    public string Name { get; }
    private readonly List<IFileSystemItem> _children = new();

    public DirectoryItem(string name)
    {
        Name = name;
    }

    public void Add(IFileSystemItem item) => _children.Add(item);
    public void Remove(IFileSystemItem item) => _children.Remove(item);

    public int GetSize()
    {
        int total = 0;
        foreach (var child in _children)
        {
            total += child.GetSize();
        }
        return total;
    }

    public void Print(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}+ Directory: {Name} (Total: {GetSize()} KB)");
        foreach (var child in _children)
        {
            child.Print(depth + 1);
        }
    }
}

public static class CompositeDemo
{
    public static void Invoke()
    {
        Console.WriteLine("--- Composite Pattern ---");
        var root = new DirectoryItem("Root");
        var docs = new DirectoryItem("Documents");
        var pics = new DirectoryItem("Pictures");

        docs.Add(new FileItem("Resume.pdf", 120));
        docs.Add(new FileItem("Budget.xlsx", 250));

        pics.Add(new FileItem("Vacation.jpg", 1500));

        root.Add(docs);
        root.Add(pics);
        root.Add(new FileItem("Config.json", 10));

        root.Print();
        Console.WriteLine();
    }
}
