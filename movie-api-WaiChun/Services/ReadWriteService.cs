using System.Globalization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using movie_api_WaiChun.Model;

namespace movie_api_WaiChun.Services
{
    public class ReadWriteService
    {
		private const string MetadataPath = "CSV/metadata.csv";
		private const string StatsPath = "CSV/stats.csv";
		private readonly List<Metadata> _db;

		public ReadWriteService()
		{
			_db = new List<Metadata>();
		}

		private static StreamReader SetReaderPath(string path)
        {
			StreamReader reader = new StreamReader(path);
			return reader;
		}

		public List<Metadata> ReadMetadata()
        {
			
			List<Metadata> metadatas = new List<Metadata>();
			try
			{
				using (var csv = new CsvReader(SetReaderPath(MetadataPath), CultureInfo.InvariantCulture))
				{
					metadatas = csv.GetRecords<Metadata>().ToList();
					return metadatas;
				}
			}
			catch (Exception ex)
            {
				throw new Exception(ex.Message);
            }

		}

		public bool AddItem(Metadata metadata)
		{
			_db.Add(metadata);
			return true;
		}

		public List<Stats> ReadStats()
		{

			List<Stats> stats = new List<Stats>();
			try
			{
				using (var csv = new CsvReader(SetReaderPath(StatsPath), CultureInfo.InvariantCulture))
				{
					stats = csv.GetRecords<Stats>().ToList();
					return stats;
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
	}
}
