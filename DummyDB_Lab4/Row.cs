namespace DummyDB_4;

public class Row
{
    public Dictionary<Column, object> Elements { get; set; }

    public Row()
    {
        Elements = new Dictionary<Column, object>();
    }
}