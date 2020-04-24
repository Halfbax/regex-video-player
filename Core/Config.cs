using System.IO;

namespace NarutoViewer.Core
{
    class Config
    {
        public static Models.Naruto Load()
        {
            Models.Naruto naruto;

            if (File.Exists("./status.json"))
            {
                var json = File.ReadAllText("./status.json");
                if (!System.String.IsNullOrEmpty(json))
                {
                    naruto = Models.Naruto.FromJson(json);
                    System.Console.WriteLine(System.String.Format("Status with version {0} loaded.", naruto.Meta.Version));
                    return naruto;
                }
            }

            naruto = new Models.Naruto();
            naruto.Classic = new Models.EpisodePayload();
            naruto.Shippuden = new Models.EpisodePayload();
            naruto.Boruto = new Models.EpisodePayload();

            return naruto;
        }

        public static void Save(Models.Naruto config)
        {
            File.WriteAllText("./status.json", Models.Serialize.ToJson(config));
        }
    }
}
