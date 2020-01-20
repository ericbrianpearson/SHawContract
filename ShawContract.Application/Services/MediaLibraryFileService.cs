using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using System;
using System.Web;

namespace ShawContract.Application.Services
{
    public class MediaLibraryFileService : IMediaLibraryFileService
    {
        public IMediaLibraryGateway MediaLibraryFileGateway { get; set; }

        public IFileManagerService FileManagerService { get; set; }

        public string MediaLibraryName
        {
            get
            {
                return MediaLibraryFileGateway.MediaLibraryName;
            }

            set
            {
                if (value != null)
                {
                    MediaLibraryFileGateway.MediaLibraryName = value;
                }
            }
        }

        public string MediaLibrarySiteName
        {
            get
            {
                return MediaLibraryFileGateway.MediaLibrarySiteName;
            }
            set
            {
                if (value != null)
                {
                    MediaLibraryFileGateway.MediaLibrarySiteName = value;
                }
            }
        }

        protected string UploadPath => FileManagerService.MapServerPath($"~\\App_Data\\ImageUploaderEditor");

        public MediaLibraryFileService(IMediaLibraryGateway mediaLibraryGateway, IFileManagerService fileManagerService)
        {
            MediaLibraryFileGateway = mediaLibraryGateway;
            FileManagerService = fileManagerService;
        }

        public MediaLibraryFile GetMediaLibrary(Guid fileGuid)
        {
            return MediaLibraryFileGateway.GetMediaLibrary(fileGuid);
        }

        public Guid AddMediaLibraryFile(HttpPostedFileWrapper file, string libraryName, string librarySiteName, string libraryFolderPath = null)
        {
            if (string.IsNullOrEmpty(libraryName))
            {
                throw new ArgumentException("Media library name is not specified.", nameof(libraryName));
            }

            if (string.IsNullOrEmpty(librarySiteName))
            {
                throw new ArgumentException("Media library site name is not specified.", nameof(librarySiteName));
            }

            return AddMediaLibraryFileInternal(file, UploadPath, libraryFolderPath);
        }

        public Guid AddMediaLibraryFile(HttpPostedFileWrapper file, int mediaLibraryId, string libraryFolderPath = null)
        {
            throw new NotImplementedException();
        }

        protected Guid AddMediaLibraryFileInternal(HttpPostedFileWrapper file, string uploadDirectory, string libraryFolderPath = null)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            var directory = FileManagerService.EnsureUploadDirectory(uploadDirectory);
            var tuple = FileManagerService.GetNameAndExtension(file.FileName);
            var uploadFilePath = FileManagerService.GetNonCollidingFilePath(directory, tuple.Item1, tuple.Item2);
            file.SaveAs(uploadFilePath);

            return MediaLibraryFileGateway.AddMediaLibraryFile(uploadFilePath, libraryFolderPath);
        }
    }
}