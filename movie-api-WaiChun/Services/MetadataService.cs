using System.Collections.Generic;
using System.Linq;
using movie_api_WaiChun.Model;

namespace movie_api_WaiChun.Services
{
    public class MetadataService
    {
        private readonly ReadWriteService _readWriteService;

        public MetadataService(ReadWriteService readWriteService)
        {
            _readWriteService = readWriteService;
        }

        public List<Metadata> GetMetadataById(int movieId)
        {
            List<Metadata> metadatas = _readWriteService.ReadMetadata();
            metadatas = metadatas.Where(x => x.MovieId == movieId)
                .GroupBy(x => x.Language)
                .Select(x => x.OrderByDescending(x => x.Id).FirstOrDefault())
                .OrderBy(x => x.Language)
                .ToList();

            
            return metadatas;
        }

        public bool PostItem(Metadata itemdata)
        {
            return _readWriteService.AddItem(itemdata);
        }

    }
}
