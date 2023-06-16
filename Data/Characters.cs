using System.Text.Json.Serialization;

namespace MarvelApi.Data
{
    public class ResponseData
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHTML { get; set; }
        public string Etag { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public string Offset { get; set; }
        public string Limit { get; set; }
        public string Total { get; set; }
        public string Count { get; set; }
        public List<MarvelApiResponse> Results { get; set; }
    }
    public class MarvelApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public Comics Comics { get; set; }
        public Series Series { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
        public List<Url> Urls { get; set; }
    }

    public class Thumbnail
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value + ".jpg"; }
        }
        public string Extension { get; set; }
    }

    public class Comics
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Series
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Stories
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Events
    {
        public int Available { get; set; }
        public string CollectionURI { get; set; }
        public List<Item> Items { get; set; }
        public int Returned { get; set; }
    }

    public class Item
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Url
    {
        public string Type { get; set; }
        public string url { get; set; }
    }
}
