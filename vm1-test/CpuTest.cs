using vm1_lib;
using Xunit;

namespace vm1_test
{
    public class CpuTest
    {
        [Fact]
        public void TestDummy()
        {
            int expected = 8;
            int actual = Cpu.dummy(3, 5);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        public void TestDummyTheory(int a, int b, int expected)
        {
            int actual = Cpu.dummy(a, b);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestRunSimple()
        {
            int[] code = {
                Cpu.ICONST, 99, Cpu.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0);
            cpu.Run();

            Assert.Equal(3, cpu.ip);
            Assert.Equal(0, cpu.sp);
        }

        [Fact]
        public void TestAdd()
        {
            int[] code = {
                Cpu.ICONST, 5, Cpu.ICONST, 2, Cpu.IADD, Cpu.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(7, cpu.stack[0]);
        }

        [Fact]
        public void TestSub()
        {
            int[] code = {
                Cpu.ICONST, 5, Cpu.ICONST, 7, Cpu.ISUB, Cpu.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(-2, cpu.stack[0]);
        }

        [Fact]
        public void TestMul()
        {
            int[] code = {
                Cpu.ICONST, 5, Cpu.ICONST, 7, Cpu.IMUL, Cpu.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(35, cpu.stack[0]);
        }
    }
}
