using ShawContract.Application.Models;
using System;
using System.Web;

namespace ShawContract.Application.Contracts.Services
{
    public interface IMediaLibraryFileService
    {
        string MediaLibraryName { get; set; }
        string MediaLibrarySiteName { get; set; }

        MediaLibraryFile GetMediaLibrary(Guid fileGuid);

        Guid AddMediaLibraryFile(HttpPostedFileWrapper file, string libraryName, string librarySiteName, string libraryFolderPath = null);

        Guid AddMediaLibraryFile(HttpPostedFileWrapper file, int mediaLibraryId, string libraryFolderPath = null);
    }
}