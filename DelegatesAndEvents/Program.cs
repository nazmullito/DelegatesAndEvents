namespace DelegatesAndEvents
{
	class Program
	{
		static void Main(string[] args)
		{
			FileSearch fileSearch = new FileSearch();
			fileSearch.publisher = Subscriber;

			Console.WriteLine("File Search Started");
			Task.Run(() => fileSearch.Search("D:\\PersonalFiles"));
			
			Console.WriteLine("Continue executing main function....");
			Console.ReadLine();
		}

		static void Subscriber(string filename)
		{
			Console.WriteLine(filename);
		}
	}

	public class FileSearch
	{
		public delegate void searchMethod(string search);
		public searchMethod publisher = null;
		public void Search(string directory)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(directory);
			FileInfo[] fileInfos = directoryInfo.GetFiles();

			foreach (FileInfo fileInfo in fileInfos)
			{
				publisher(fileInfo.Name);
			}
		}
	}
}

//for .Net 6 and later version. Don't need static void Main function. Compiler or .net Run time generates it in background as an IL Code.

//FileSearch fileSearch = new FileSearch();
//fileSearch.publisher = Subscriber;

//Console.WriteLine("File Search Started");
//Task.Run(() => fileSearch.Search("D:\\PersonalFiles"));

//Console.WriteLine("Continue executing main function....");
//Console.ReadLine();

//static void Subscriber(string filename)
//{
//	Console.WriteLine(filename);
//}

//public class FileSearch
//{
//	public delegate void searchMethod(string search);
//	public searchMethod publisher = null;
//	public void Search(string directory)
//	{
//		DirectoryInfo directoryInfo = new DirectoryInfo(directory);
//		FileInfo[] fileInfos = directoryInfo.GetFiles();

//		foreach (FileInfo fileInfo in fileInfos)
//		{
//			publisher(fileInfo.Name);
//		}
//	}
//}