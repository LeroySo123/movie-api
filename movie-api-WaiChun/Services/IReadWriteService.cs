using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movie_api_WaiChun.Model;

namespace movie_api_WaiChun.Services
{
    public interface IReadWriteService
    {
        List<Metadata> ReadMetadata();
    }
}
