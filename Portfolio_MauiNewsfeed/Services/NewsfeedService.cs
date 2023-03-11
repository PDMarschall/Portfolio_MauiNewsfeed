using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Portfolio_MauiNewsfeed.Services
{
    public class NewsfeedService
    {
        public SyndicationFeed LoadFeed(string xmlFeedUrl)
        {
            XmlReader reader = XmlReader.Create(xmlFeedUrl);
            return SyndicationFeed.Load(reader);
        }
        public void InitializeNullEntries(SyndicationFeed feed)
        {
            foreach (SyndicationItem item in feed.Items)
            {
                item.Title ??= new TextSyndicationContent("");
                item.Summary ??= new TextSyndicationContent("");                
            }
        }

        public SyndicationFeed ApplyFilter(SyndicationFeed feed, List<string> whitelist, List<string> blacklist)
        {
            SyndicationFeed filteredFeed = new SyndicationFeed();
            if (whitelist.Any() || blacklist.Any())
            {
                filteredFeed = feed;
                filteredFeed.Items = feed.Items.Where(x =>
                    (!whitelist.Any()
                    ||
                    whitelist.Any(searchTerm => x.Title.Text.ToLower().Contains(searchTerm.ToLower())))
                    &&
                    (!blacklist.Any()
                    ||
                    blacklist.Any(searchTerm => !x.Title.Text.ToLower().Contains(searchTerm.ToLower()))));
            }
            return filteredFeed;
        }
    }


}
