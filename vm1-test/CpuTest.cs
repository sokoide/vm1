using System;
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
            Console.Error.WriteLine("* TestRunSimple");
            int[] code = {
                ByteCode.ICONST, 99, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(3, cpu.ip);
            Assert.Equal(0, cpu.sp);
        }

        [Fact]
        public void TestAdd()
        {
            Console.Error.WriteLine("* TestAdd");
            int[] code = {
                ByteCode.ICONST, 5, ByteCode.ICONST, 2, ByteCode.IADD, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(7, cpu.stack[0]);
        }

        [Fact]
        public void TestSub()
        {
            Console.Error.WriteLine("* TestSub");
            int[] code = {
                ByteCode.ICONST, 5, ByteCode.ICONST, 7, ByteCode.ISUB, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(-2, cpu.stack[0]);
        }

        [Fact]
        public void TestMul()
        {
            Console.Error.WriteLine("* TestMul");
            int[] code = {
                ByteCode.ICONST, 5, ByteCode.ICONST, 7, ByteCode.IMUL, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(35, cpu.stack[0]);
        }
    }
}
