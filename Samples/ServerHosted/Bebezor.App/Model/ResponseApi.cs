namespace Bebezor.App.Model
{
    public class ResponseApi<ApiContent>
        where ApiContent : class
    {
        public int code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public string etag { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public int offset { get; set; }
            public int limit { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public List<ApiContent> results { get; set; }
        }

    }
}
