using System.Collections.Generic;
using System.Linq;
using NzbDrone.Core.Datastore;
using NzbDrone.Core.Messaging.Events;

namespace NzbDrone.Core.Download.History
{
    public interface IDownloadHistoryRepository : IBasicRepository<DownloadHistory>
    {
        List<DownloadHistory> FindByDownloadId(string downloadId);
        void DeleteByArtistIds(List<int> artistIds);
    }

    public class DownloadHistoryRepository : BasicRepository<DownloadHistory>, IDownloadHistoryRepository
    {
        public DownloadHistoryRepository(IMainDatabase database, IEventAggregator eventAggregator)
            : base(database, eventAggregator)
        {
        }

        public List<DownloadHistory> FindByDownloadId(string downloadId)
        {
            return Query(x => x.DownloadId == downloadId).OrderByDescending(h => h.Date).ToList();
        }

        public void DeleteByArtistIds(List<int> artistIds)
        {
            Delete(r => artistIds.Contains(r.ArtistId));
        }
    }
}
