namespace Bebezor.App.Model.Characters
{ 
    public class Series
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public Item[] items { get; set; }
        public int returned { get; set; }
    }

}
