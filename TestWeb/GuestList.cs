using Newtonsoft.Json;

namespace TestWeb
{
    public static class GuestList
    {
        private static List<string> _names;
        static GuestList()
        {
            //"guests.json"
            if (File.Exists("guests.json"))
            {
                string json = File.ReadAllText("guests.json");

                //deserialize turns json into an object (or a list of objects)
                _names = JsonConvert.DeserializeObject<List<string>>(json);
            }
            if (_names == null)
            {
                _names = new List<string>();
            }
        }

        public static IEnumerable<string> Names => _names;

        public static void AddName(string n)
        {
            if (n != null && n != "")
            {
                _names.Add(n);

                //add to external database (or json)
                //serialize turns an object (or a list of objects) into json
                File.WriteAllText("guests.json", JsonConvert.SerializeObject(Names));
            }
        }
    }
}
