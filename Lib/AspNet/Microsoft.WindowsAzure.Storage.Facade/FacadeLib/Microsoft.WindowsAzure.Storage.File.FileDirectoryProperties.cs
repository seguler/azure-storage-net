using System;
namespace Microsoft.WindowsAzure.Storage.File
{
public sealed class FileDirectoryProperties
{
    public string ETag
    {
        get; internal set;
    }

    public DateTimeOffset? LastModified
    {
        get; internal set;
    }

    public bool IsServerEncrypted
    {
        get; internal set;
    }
}

}