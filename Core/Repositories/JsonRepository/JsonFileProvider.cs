using System.IO;

namespace JsonRepository
{
	internal class JsonFileProvider
	{
		private const string BasePath = "D:\\jsons\\";

		public JsonFileProvider()
		{
			if (!Directory.Exists(BasePath))
				Directory.CreateDirectory(BasePath);
		}
		public static string GetJson<T>()
		{
			var fileName = GetFileName<T>();
			CreateFileIdNotExists(fileName);
			return File.ReadAllText(fileName);
		}

		private static string GetFileName<T>()
		{
			return Path.Combine(BasePath, $"{typeof(T).Name}.json");
		}

		private static void CreateFileIdNotExists(string fileName)
		{
			if (!Directory.Exists(BasePath))
				Directory.CreateDirectory(BasePath);
			if (!File.Exists($"{fileName}.json"))
				File.WriteAllText(fileName, "");
		}

		public static void SetJson<T>(string data)
		{
			var fileName = GetFileName<T>();
			CreateFileIdNotExists(fileName);
			File.WriteAllText(fileName, data);
		}
	}
}
