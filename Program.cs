using System.IO;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;


if (!Directory.Exists("./test"))
{
    Directory.CreateDirectory("./test");
}
if (!File.Exists("./test/txt.txt"))
{
    File.Create("./test/txt.txt");
}
if (!File.Exists("./test/txt2.txt"))
{
    File.Create("./test/txt2.txt");
}

if (!File.Exists("./test/bin.bin"))
{
    File.Create("./test/bin.bin");
}
DirectoryInfo newDirectory = new DirectoryInfo("./test");
FileInfo[] files = newDirectory.GetFiles("*.txt.txt");

Console.WriteLine($"Ім'я теки: {newDirectory.Name}");
Console.WriteLine($"Повний шлях до теки: {newDirectory.FullName}");
Console.WriteLine("Дата створення теки: "+ Directory.GetLastWriteTime("./test"));
Console.WriteLine("---------------------------------------------------------------");

string bintes = "./test/bin.bin";
int intBin = 214436;

string fileTxt = "./test/txt.txt";
string textTxt = "aaaaaag";

string fileTxt2 = "./test/txt2.txt";
string textTxt2 = "aaaaaa";


using (FileStream fstream = new FileStream(fileTxt, FileMode.OpenOrCreate))
{
    
    byte[] buffer = Encoding.Default.GetBytes(textTxt);    
    await fstream.WriteAsync(buffer, 0, buffer.Length);
    
}
using (FileStream fstream = File.OpenRead(fileTxt))
{
    
    byte[] buffer = new byte[fstream.Length];
    
    await fstream.ReadAsync(buffer, 0, buffer.Length);
    
    string textFromFile = Encoding.Default.GetString(buffer);
    Console.WriteLine($"Текст в файлі: {textFromFile}");
    FileInfo fileInfo = new FileInfo(fileTxt);
    Console.WriteLine("Ім'я файлу: " + fileInfo.Name);
    Console.WriteLine("Повний шлях до файлу: " + fileInfo.FullName);
    Console.WriteLine("Дата створення файлу: " + File.GetLastWriteTime(fileTxt));
    Console.WriteLine("---------------------------------------------------------------");


}

using (FileStream fstream = new FileStream(fileTxt2, FileMode.OpenOrCreate))
{

    byte[] buffer = Encoding.Default.GetBytes(textTxt2);
    await fstream.WriteAsync(buffer, 0, buffer.Length);

}
using (FileStream fstream = File.OpenRead(fileTxt2))
{

    byte[] buffer = new byte[fstream.Length];

    await fstream.ReadAsync(buffer, 0, buffer.Length);

    string textFromFile = Encoding.Default.GetString(buffer);
    Console.WriteLine($"Текст в файлі: {textFromFile}");
    FileInfo fileInfo = new FileInfo(fileTxt2);
    Console.WriteLine("Ім'я файлу: " + fileInfo.Name);
    Console.WriteLine("Повний шлях до файлу: " + fileInfo.FullName);
    Console.WriteLine("Дата створення файлу: " + File.GetLastWriteTime(fileTxt2));
    Console.WriteLine("---------------------------------------------------------------");

}


using (FileStream srteam = new FileStream(bintes, FileMode.Create))
{
    using (BinaryWriter write = new BinaryWriter(srteam))
    {
        string s = "jii";
        int a = 12;
        double b = 4.7;
        write.Write(s);
        write.Write(a);
        write.Write(b);
    }
}
using (FileStream srteam = new FileStream(bintes, FileMode.Open))
{
    using (BinaryReader reader = new BinaryReader(srteam))
    {
        Console.WriteLine(reader.ReadString());
        Console.WriteLine(reader.ReadInt32());
        Console.WriteLine(reader.ReadDouble());
        FileInfo fileInfo = new FileInfo(bintes);
        Console.WriteLine("Ім'я файлу: " + fileInfo.Name);
        Console.WriteLine("Повний шлях до файлу: " + fileInfo.FullName);
        Console.WriteLine("Дата створення файлу: " + File.GetLastWriteTime(bintes));
        Console.WriteLine("---------------------------------------------------------------");

    }
}
Directory.Delete("./test", true);


