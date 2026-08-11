using System;
using System.Collections.Generic;

namespace Csharp_design_patterns_lab.DesignPatterns.Behavioral.Memento;

public class TextMemento
{
    public string Content { get; }
    public DateTime SavedAt { get; }

    public TextMemento(string content)
    {
        Content = content;
        SavedAt = DateTime.Now;
    }
}

public class TextEditor
{
    public string Content { get; set; } = string.Empty;

    public TextMemento Save() => new TextMemento(Content);

    public void Restore(TextMemento memento)
    {
        Content = memento.Content;
    }
}

public class History
{
    private readonly Stack<TextMemento> _history = new();

    public void Push(TextMemento memento) => _history.Push(memento);

    public TextMemento? Pop() => _history.Count > 0 ? _history.Pop() : null;
}

public static class MementoDemo
{
    public static void Invoke()
    {
        Console.WriteLine("--- Memento Pattern ---");
        var editor = new TextEditor();
        var history = new History();

        editor.Content = "Version 1.0";
        history.Push(editor.Save());

        editor.Content = "Version 2.0";
        history.Push(editor.Save());

        editor.Content = "Version 3.0 (Broken)";
        Console.WriteLine($"Current Content: {editor.Content}");

        var previous = history.Pop();
        if (previous != null)
        {
            editor.Restore(previous);
            Console.WriteLine($"Restored Content: {editor.Content}");
        }

        Console.WriteLine();
    }
}
