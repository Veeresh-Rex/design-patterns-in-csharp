namespace DocumentEditor.Elements;

public class ImageElement : IDocumentElement
{
    private readonly string _blobUrl;

    public ImageElement(string blobUrl)
    {
        _blobUrl = blobUrl;
    }

    public string Render()
    {
        return $"[Image: {_blobUrl}]";
    }
}
