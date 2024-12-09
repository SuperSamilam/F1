using InputHelperSpace;
using System.Text.Json;

namespace SaveSystemSpace
{

    public static class SaveSystem
    {
        public static string gamePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "F1Game");

        public static GameData NewSave()
        {
            Console.Clear();

            Console.WriteLine("Write the name you want for this savefile, if it already exists, it will be overwritten, if you leave it blank it will get a name automaticly");
            string name = Console.ReadLine() ?? "";
            if (name == "")
                name = Path.Combine(gamePath, "save" + Directory.GetFiles(gamePath).Length.ToString() + ".txt");
            else
                name = Path.Combine(gamePath, name + ".txt");

            GameData data = new GameData(name);
            WriteData(data);
            Thread.Sleep(200);
            Console.Clear();
            return data;
        }

        public static void WriteData(GameData data)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(gamePath, data.saveName)))
                {
                    var opt = new JsonSerializerOptions() { WriteIndented = true };
                    string strJson = JsonSerializer.Serialize<GameData>(data, opt);
                    writer.Write(strJson);
                }
                using (StreamWriter writer = new StreamWriter(Path.Combine(gamePath, "latestSave.txt")))
                {
                    var opt = new JsonSerializerOptions() { WriteIndented = true };
                    string strJson = JsonSerializer.Serialize<GameData>(data, opt);
                    writer.Write(strJson);
                }
            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
        }

        public static GameData? SelectAndLoadData()
        {
            while (true)
            {
                Console.Clear();
                string[] files = Directory.GetFiles(gamePath);
                Console.WriteLine("Write the number of the action you want to do");
                Console.WriteLine("1: Back");
                for (int i = 0; i < Directory.GetFiles(gamePath).Length; i++)
                {
                    Console.WriteLine((i + 2) + ": " + Path.GetFileName(files[i]));
                }

                string input = Console.ReadLine() ?? "";

                if (input == "1")
                    return null;

                int? result = InputHelper.ConvertStringToIntWithinRange(input, 2, files.Length + 2);
                if (result == null)
                    continue;

                //Got a valid number
                Console.Clear();
                return loadData(Path.GetFileName(files[(int)result - 2]));
            }
        }

        public static bool DoesFileExist(string name)
        {
            if (File.Exists(gamePath + "/" + name))
            {
                return true;
            }
            return false;
        }

        public static GameData loadData(string saveName)
        {
            GameData data = JsonSerializer.Deserialize<GameData>(File.ReadAllText(gamePath + "/" + saveName));
            return data;
        }
    }
}