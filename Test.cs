
using System.IO;

namespace wootapa.permtest
{
    public static class Test
    {
        public static bool CanList(this DirectoryInfo folder, out FileInfo[] files)
        {
            files = default;
            try
            {
                files = folder.GetFiles("*.*");
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public static bool CanRead(this FileInfo file)
        {
            try
            {
                using var stream = new StreamReader(file.FullName);
                stream.Read();
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        public static bool CanWrite(this FileInfo file)
        {
            try
            {
                using var stream = new StreamWriter(file.FullName);
                stream.Write("Works");
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}