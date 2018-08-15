using System;
using vm1_lib;
using Xunit;

namespace vm1_test
{
    public class CpuTest
    {
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

        // IADD
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

        // ISUB
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

        // IMUL
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

        // ILT
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(1, 1, 0)]
        [InlineData(5, 3, 0)]
        [InlineData(-2, -1, 1)]
        public void TestConditionLT(int a, int b, int expected)
        {
            Console.Error.WriteLine("* TestCondition {0},{1} ILT -> {2}", a, b, expected);
            int[] code = {
                ByteCode.ICONST, a, ByteCode.ICONST, b, ByteCode.ILT, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(expected, cpu.stack[0]);
        }

        // IEQ
        [Theory]
        [InlineData(1, 2, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(5, 3, 0)]
        [InlineData(-2, -2, 1)]
        public void TestConditionEQ(int a, int b, int expected)
        {
            Console.Error.WriteLine("* TestCondition {0},{1} IEQ -> {2}", a, b, expected);
            int[] code = {
                ByteCode.ICONST, a, ByteCode.ICONST, b, ByteCode.IEQ, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(6, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(expected, cpu.stack[0]);
        }

    }
}
