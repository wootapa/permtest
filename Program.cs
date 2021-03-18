using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using wootapa.permtest;

bool canList = false;
bool canRead = false;
bool canWrite = false;

try
{
    var di = new DirectoryInfo("/data");

    if (!di.Exists)
    {
        Console.WriteLine($"{di.FullName} does not exist");
        throw new DirectoryNotFoundException(di.FullName);
    }

    canList = di.CanList(out var files);
    canRead = files.FirstOrDefault().CanRead();
    canWrite = new FileInfo(Path.Combine(di.FullName, DateTime.Now.Ticks.ToString())).CanWrite();
}
catch (Exception) { }
finally
{
    Console.WriteLine("List  : " + canList);
    Console.WriteLine("Read  : " + canRead);
    Console.WriteLine("Write : " + canWrite);

    Environment.Exit(canList && canRead && canWrite ? 0 : 1);
}