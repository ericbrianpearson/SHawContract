using System;

namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface IFileManagerService
    {
        string EnsureUploadDirectory(string directoryPath);

        string GetFilePath(string directoryPath, string fileName);

        string GetSuffixedFileName(string fileName, string fileExtension, int currentSuffix);

        string GetNonCollidingFilePath(string directoryPath, string fileName, string fileExtension, int currentSuffix = 0);

        Tuple<string, string> GetNameAndExtension(string completeFileName);

        string MapServerPath(string path);
    }
}