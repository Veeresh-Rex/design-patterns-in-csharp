namespace DocumentEditor.Elements;

public class TextElement : IDocumentElement
{
    private readonly string _text;

    public TextElement(string text)
    {
        _text = text;
    }

    public string Render()
    {
        return _text;
    }
}
