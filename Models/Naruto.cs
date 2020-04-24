namespace NarutoViewer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Naruto
    {
        [JsonProperty("meta", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Meta Meta { get; set; }

        [JsonProperty("classic", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public EpisodePayload Classic { get; set; }

        [JsonProperty("shippuden", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public EpisodePayload Shippuden { get; set; }

        [JsonProperty("boruto", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public EpisodePayload Boruto { get; set; }
    }

    public partial class EpisodePayload
    {
        [JsonProperty("episode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore), DefaultValue(1)]
        public int Episode { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("version", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore), DefaultValue("0.0")]
        public string Version { get; set; }
    }

    public partial class Naruto
    {
        public static Naruto FromJson(string json) => JsonConvert.DeserializeObject<Naruto>(json, NarutoViewer.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Naruto self) => JsonConvert.SerializeObject(self, NarutoViewer.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
