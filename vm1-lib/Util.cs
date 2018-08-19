namespace vm1_lib
{
    class Util
    {
        public static void WriteLine(string line)
        {
#if DEBUG
            System.Console.WriteLine(line);
#endif
        }

        public static void WriteLine(string format, params object[] objs)
        {
#if DEBUG
            System.Console.WriteLine(format, objs);
#endif
        }
        public static void Write(string line)
        {
#if DEBUG
            System.Console.Write(line);
#endif
        }

        public static void Write(string format, params object[] objs)
        {
#if DEBUG
            System.Console.Write(format, objs);
#endif
        }
    }
}
