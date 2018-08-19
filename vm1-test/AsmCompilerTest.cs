using Antlr4.Runtime;
using System.IO;
using System.Text;
using vm1_lib;
using Xunit;
using Xunit.Abstractions;

namespace vm1_test
{
    public class AsmCompilerTest
    {
        private readonly ITestOutputHelper output;

        public AsmCompilerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestAsmCompiler()
        {
            AsmCompiler c = new AsmCompiler();
            MemoryStream mso = new MemoryStream();
            MemoryStream msi = MakeInput(new string[]{
                "// comment", // comment line should be skipped
                "iconst 42",  // 0x090000002A000000
                "print",      // 0x0E000000
                "iconst 3",   // 0x0900000003000000
                "iadd",       // 0x01000000
                "nop // comment can be here",        // 0x00000000
                "iconst 5",   // 0x0900000005000000
                "halt",       // 0x12000000
            });

            c.Run(new AntlrInputStream(msi), mso);
            mso.Flush();

            byte[] result = mso.ToArray();
            Assert.Equal(40, result.Length);
            Assert.Equal(0x09, result[0]);
            Assert.Equal(0x00, result[1]);
            Assert.Equal(0x00, result[2]);
            Assert.Equal(0x00, result[3]);
            Assert.Equal(0x2A, result[4]);
            Assert.Equal(0x00, result[5]);
            Assert.Equal(0x00, result[6]);
            Assert.Equal(0x00, result[7]);

            OutputBinaryStream(mso);
        }

        #region private methods
        private MemoryStream MakeInput(string[] codeLines)
        {
            MemoryStream msi = new MemoryStream();
            foreach (string codeLine in codeLines)
            {
                AddCodeLine(msi, codeLine);
            }
            msi.Flush();
            msi.Seek(0, 0);
            return msi;
        }

        private void AddCodeLine(MemoryStream m, string line)
        {
            m.Write(Encoding.UTF8.GetBytes(line + "\n"));
        }

        private void OutputBinaryStream(MemoryStream m)
        {
            StringBuilder sb = new StringBuilder();
            int ip = 0;

            output.WriteLine("Code Length: 0x{0:X4} = {0}", m.Length);

            m.Seek(0, 0);
            for (ip = 0; ip < m.Length; ip++)
            {
                sb.AppendFormat("{0:X2}", m.ReadByte());
                if (ip % 16 == 15)
                {
                    output.WriteLine("{0:0000}: {1}", ip / 16, sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(" ");
                }
            }
            if (sb.Length > 0)
            {
                output.WriteLine("{0:0000}: {1}", ip / 16, sb.ToString());
            }
        }
        #endregion
    }
}
