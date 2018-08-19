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
        public void TestAsmCompilerBasic()
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

            OutputBinaryStream(mso);

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
        }

        [Fact]
        public void TestAsmCompilerLabalBranch()
        {
            AsmCompiler c = new AsmCompiler();
            MemoryStream mso = new MemoryStream();
            MemoryStream msi = MakeInput(new string[]{
                "br LABEL1:",   // addr 0: code: 6, 7
                "halt",         // addr 2: code: 18
                "brt LABEL2:",  // addr 3, code: 7, 8
                "brf LABEL3:",  // addr 5, code: 8, 8
                "LABEL1:",      // (only label)
                "halt",         // addr 7: code 18
                "LABEL2:",      // (only label)
                "LABEL3:",      // (only label)
                "halt",         // addr 8: code 18
            });

            c.Run(new AntlrInputStream(msi), mso);
            mso.Flush();

            OutputBinaryStream(mso);

            byte[] result = mso.ToArray();
            Assert.Equal(36, result.Length);
            Assert.Equal(0x06, result[0]);  // br LABEL1:
            Assert.Equal(0x00, result[1]);
            Assert.Equal(0x00, result[2]);
            Assert.Equal(0x00, result[3]);
            Assert.Equal(0x07, result[4]);
            Assert.Equal(0x00, result[5]);
            Assert.Equal(0x00, result[6]);
            Assert.Equal(0x00, result[7]);
            Assert.Equal(0x12, result[8]);  // halt
            Assert.Equal(0x00, result[9]);
            Assert.Equal(0x00, result[10]);
            Assert.Equal(0x00, result[11]);
            Assert.Equal(0x07, result[12]); // brt LABEL2:
            Assert.Equal(0x00, result[13]);
            Assert.Equal(0x00, result[14]);
            Assert.Equal(0x00, result[15]);
            Assert.Equal(0x08, result[16]);
            Assert.Equal(0x00, result[17]);
            Assert.Equal(0x00, result[18]);
            Assert.Equal(0x00, result[19]);
            Assert.Equal(0x08, result[20]); // brf LABEL3:
            Assert.Equal(0x00, result[21]);
            Assert.Equal(0x00, result[22]);
            Assert.Equal(0x00, result[23]);
            Assert.Equal(0x08, result[24]);
            Assert.Equal(0x00, result[25]);
            Assert.Equal(0x00, result[26]);
            Assert.Equal(0x00, result[27]);
            Assert.Equal(0x12, result[28]); // halt
            Assert.Equal(0x00, result[29]);
            Assert.Equal(0x00, result[30]);
            Assert.Equal(0x00, result[31]);
            Assert.Equal(0x12, result[32]); // halt
            Assert.Equal(0x00, result[33]);
            Assert.Equal(0x00, result[34]);
            Assert.Equal(0x00, result[35]);
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
            msi.Seek(0, SeekOrigin.Begin);
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

            m.Seek(0, SeekOrigin.Begin);
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
