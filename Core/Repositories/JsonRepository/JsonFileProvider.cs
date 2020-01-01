using System.IO;

namespace JsonRepository
{
	internal class JsonFileProvider
	{
		public static string GetJson<T>()
		{
			var fileName = GetFileName<T>();
			CreateFileIdNotExists(fileName);
			return File.ReadAllText(fileName);
		}

		private static string GetFileName<T>()
		{
			return $"{typeof(T).Name}.json";
		}

		private static void CreateFileIdNotExists(string fileName)
		{
			if (!File.Exists($"{fileName}.json"))
				File.Create(fileName);
		}

		public static void SetJson<T>(string data)
		{
			var fileName = GetFileName<T>();
			CreateFileIdNotExists(fileName);
			File.WriteAllText(fileName, data);
		}
	}
}
