using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IMediaLibraryGateway
    {
        string MediaLibraryName { get; set; }

        string MediaLibrarySiteName { get; set; }

        int? MediaLibraryId { get; set; }

        Guid AddMediaLibraryFile(string filePath, string libraryFolderPath = null);

        MediaLibraryFile GetMediaLibrary(Guid fileGuid);

        //IEnumerable<MediaLibraryFile> GetMediaLibraryDtos(params Guid[] fileGuids);

        //IEnumerable<MediaLibraryFile> GetMediaLibraryDtos(params string[] extensions);
    }
}