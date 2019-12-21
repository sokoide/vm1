using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using vm1_lib;

namespace vm1_console
{
    class Program
    {
        class Options
        {
            public string sourcePath;
            public int dataSize = 0;
            public int stackSize = 128;
            public bool trace = false;
            public bool shouldShowHelp = false;
        }

        static void Main(string[] args)
        {
            Options o = new Options();

            var options = new OptionSet {
                { "s|sourcePath=", "assembly source file path.", a => o.sourcePath = a },
                { "g|globalDataSize=", "global data size in byte.", a => o.dataSize = int.Parse(a) },
                { "c|stackSize=", "stack size in count of elements (1=4bytes).", a => o.stackSize = int.Parse(a) },
                { "t|trace", "trace output.", a => o.trace = a != null },
                { "h|help", "show this message and exit", h => o.shouldShowHelp = h != null },
            };

            List<string> extra;
            try
            {
                // parse the command line
                extra = options.Parse(args);
                if (o.shouldShowHelp
                    || string.IsNullOrEmpty(o.sourcePath))
                {
                    showUsage(options);
                    return;
                }
            }
            catch (OptionException e)
            {
                Console.Write("Exception: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }

            Console.WriteLine("* vm1-console started");
            int[] code = null;

            using (FileStream fs = new FileStream(o.sourcePath, FileMode.Open))
            {
                code = new int[fs.Length / 4];

                using (BinaryReader binaryStream = new BinaryReader(fs))
                {
                    for (var i = 0; i < code.Length; i++)
                    {
                        code[i] = binaryStream.ReadInt32();
                    }
                }
            }

            Cpu c = new Cpu(code, 0, o.dataSize, o.stackSize, o.trace);
            c.Run(Console.Out);

            Console.WriteLine("* vm1-console completed");
        }

        static void showUsage(OptionSet p)
        {
            Console.WriteLine("showUsage");
            p.WriteOptionDescriptions(Console.Error);
        }
    }
}
