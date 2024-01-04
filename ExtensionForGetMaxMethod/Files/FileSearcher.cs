namespace ExtensionForGetMaxMethod.Files;
internal class FileSearcher
{
    public bool CancelRequested { get; private set; }
    public event EventHandler<FileFoundArgs>? FileFound;
    public void Search(string directory, string searchPattern)
    {
        foreach (var file in Directory.EnumerateFiles(directory, searchPattern))
        {
            FileFoundArgs args = RaiseFileFound(file);
            if (args.CancelRequested)
            {
                break;
            }
        }
    }
    private FileFoundArgs RaiseFileFound(string file)
    {
        var args = new FileFoundArgs(file);
        FileFound?.Invoke(this, new FileFoundArgs(file));
        return args;
    }
    protected virtual void OnFileFound(object? sender, FileFoundArgs eventArgs)
    {
       FileFound?.Invoke(this, eventArgs);
    }
}