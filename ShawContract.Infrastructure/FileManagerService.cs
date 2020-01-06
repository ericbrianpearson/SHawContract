using ShawContract.Application.Contracts.Infrastructure;
using System;
using System.IO;
using System.Web;

namespace ShawContract.Infrastructure
{
    public class FileManagerService : IFileManagerService
    {
        public string EnsureUploadDirectory(string directoryPath)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new ArgumentException("Directory path was not specified.", nameof(directoryPath));
            }

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }

        public string GetFilePath(string directoryPath, string fileName)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                throw new ArgumentException("Directory path was not specified.", nameof(directoryPath));
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new InvalidOperationException("Cannot upload file without file name.");
            }

            return Path.Combine(directoryPath, fileName);
        }

        public string GetNonCollidingFilePath(string directoryPath, string fileName, string fileExtension, int currentSuffix = 0)
        {
            string newFileName = GetSuffixedFileName(fileName, fileExtension, currentSuffix);
            var filePath = GetFilePath(directoryPath, $"{newFileName}.{fileExtension}");

            return File.Exists(filePath)
                ? GetNonCollidingFilePath(directoryPath, fileName, fileExtension, currentSuffix + 1)
                : filePath;
        }

        public string GetSuffixedFileName(string fileName, string fileExtension, int currentSuffix)
        {
            return currentSuffix == 0 ? fileName : $"{fileName} ({currentSuffix})";
        }

        public Tuple<string, string> GetNameAndExtension(string completeFileName)
        {
            if (string.IsNullOrEmpty(completeFileName))
            {
                throw new ArgumentException("File name is null or an empty string.", nameof(completeFileName));
            }

            var separator = '.';
            var segments = completeFileName.Split(separator);

            if (segments?.Length > 1)
            {
                var subtractedLength = segments.Length - 1;
                string[] segmentsExceptLast = new string[subtractedLength];
                Array.Copy(segments, segmentsExceptLast, subtractedLength);
                var name = segmentsExceptLast.Length == 1 ? segmentsExceptLast[0] : string.Join(separator.ToString(), segmentsExceptLast);

                return new Tuple<string, string>(name, segments[subtractedLength]);//(name, segments[subtractedLength]);
            }
            else
            {
                return new Tuple<string, string>(completeFileName, null);
            }
        }

        public string MapServerPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}