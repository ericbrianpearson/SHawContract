using CMS.AmazonStorage;
using CMS.DataEngine;
using CMS.Helpers;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Providers.Kentico
{
    public class MediaLibraryFileGateway : IMediaLibraryGateway
    {
        private int? _mediaLibraryId;

        public int? MediaLibraryId
        {
            get => _mediaLibraryId == null && !string.IsNullOrEmpty(MediaLibraryName) && !string.IsNullOrEmpty(MediaLibrarySiteName)
                ? MediaLibraryInfoProvider
                    .GetMediaLibraryInfo(MediaLibraryName, MediaLibrarySiteName)?
                    .LibraryID
                : _mediaLibraryId;

            set
            {
                if (value != null)
                {
                    _mediaLibraryId = value.Value;
                }
            }
        }

        public string MediaLibraryName { get; set; }

        public string MediaLibrarySiteName { get; set; }

        public MediaLibraryFileGateway(ISiteContextService siteContextService)
        {
            MediaLibrarySiteName = siteContextService.SiteName;
            MediaLibraryName = "LocalMediaLib"; //TODO: Have to choose medialib;
        }

        public Guid AddMediaLibraryFile(string filePath, string libraryFolderPath = null)
        {
            var mediaLibraryInfo = MediaLibraryInfoProvider.GetMediaLibraryInfo(MediaLibraryName, MediaLibrarySiteName)
               ?? MediaLibraryInfoProvider.GetMediaLibraryInfo(MediaLibraryId.Value);

            if (mediaLibraryInfo == null)
            {
                throw new Exception($"The {MediaLibraryName} library was not found on the {MediaLibrarySiteName} site.");
            }

            MediaFileInfo mediaFile = !string.IsNullOrEmpty(libraryFolderPath)
                ? new MediaFileInfo(filePath, mediaLibraryInfo.LibraryID, libraryFolderPath)
                : new MediaFileInfo(filePath, mediaLibraryInfo.LibraryID);

            var fileInfo = CMS.IO.FileInfo.New(filePath);
            mediaFile.FileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
            mediaFile.FileExtension = fileInfo.Extension;
            mediaFile.FileMimeType = MimeTypeHelper.GetMimetype(fileInfo.Extension);

            mediaFile.FileSiteID = SiteContext.CurrentSiteID;

            mediaFile.FileLibraryID = mediaLibraryInfo.LibraryID;
            mediaFile.FileSize = fileInfo.Length;
            MediaFileInfoProvider.SetMediaFileInfo(mediaFile);

            return mediaFile.FileGUID;
        }

        public MediaLibraryFile GetMediaLibrary(Guid fileGuid) //possible asynchronous calling getmediafileinfo
        {
            var mediaFileInfo = MediaFileInfoProvider.GetMediaFileInfo(fileGuid, MediaLibrarySiteName);

            return mediaFileInfo != null ? Selector(mediaFileInfo) : null;
        }

        public IEnumerable<MediaLibraryFile> GetMediaLibraryDtos(params Guid[] fileGuids) =>
            GetBaseQuery((baseQuery) =>
                baseQuery.WhereIn("FileGUID", fileGuids));

        protected IEnumerable<MediaLibraryFile> GetBaseQuery(Func<ObjectQuery<MediaFileInfo>, ObjectQuery<MediaFileInfo>> filter)
        {
            var baseQuery = MediaFileInfoProvider.GetMediaFiles()
                .WhereEquals("FileLibraryID", MediaLibraryId);

            return filter(baseQuery).Select(file => Selector(file));
        }

        protected MediaLibraryFile Selector(MediaFileInfo mediaFileInfo) => //todo: use automapper
            new MediaLibraryFile()
            {
                Guid = mediaFileInfo.FileGUID,
                Title = mediaFileInfo.FileTitle,
                Extension = mediaFileInfo.FileExtension,
                DirectUrl = MediaLibraryHelper.GetDirectUrl(mediaFileInfo),
                PermanentUrl = MediaLibraryHelper.GetPermanentUrl(mediaFileInfo),
                Width = mediaFileInfo.FileImageWidth,
                Height = mediaFileInfo.FileImageHeight
            };
    }
}