namespace gamecenter.Client.Helpers
{
    public struct GenreSelectorModel
    {
        public GenreSelectorModel(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}