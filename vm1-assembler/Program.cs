using Antlr4.Runtime;
using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using vm1_lib;

namespace vm1_assembler
{
    class Program
    {
        class Options
        {
            public string sourcePath;
            public string outputPath;
            public bool shouldShowHelp = false;
        }

        static void Main(string[] args)
        {
            Options o = new Options();

            var options = new OptionSet {
                { "s|sourcePath=", "assembly source file path.", a => o.sourcePath = a },
                { "o|outputPath=", "bytecoude output file path.", a => o.outputPath = a },
                { "h|help", "show this message and exit", h => o.shouldShowHelp = h != null },
            };

            List<string> extra;
            try
            {
                // parse the command line
                extra = options.Parse(args);
                if (o.shouldShowHelp
                    || string.IsNullOrEmpty(o.sourcePath)
                    || string.IsNullOrEmpty(o.outputPath))
                {
                    showUsage(options);
                    return;
                }
            }
            catch (OptionException e)
            {
                Console.Write("Exception: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `vm1-assembler --help' for more information.");
                return;
            }

            Console.WriteLine("* assembling...");
            using (StreamReader sr = new StreamReader(o.sourcePath))
            using (FileStream fs = new FileStream(o.outputPath, FileMode.Create))
            {
                AsmCompiler c = new AsmCompiler();
                c.Run(new AntlrInputStream(sr), fs);
                fs.Flush();
            }
            Console.WriteLine("* done!");
        }

        static void showUsage(OptionSet p)
        {
            Console.WriteLine("showUsage");
            p.WriteOptionDescriptions(Console.Error);
        }
    }
}
