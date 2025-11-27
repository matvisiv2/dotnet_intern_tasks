namespace dotnetInternTasks;

class Book(string title, string author, short year)
{
    protected string title = title;
    protected string author = author;
    protected short year = year;

    public string GetInfo()
    {
        return $"title: {title}\nauthor: {author}\nyear: {year}";
    }
}