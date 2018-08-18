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

        // GSTORE
        [Fact]
        public void TestGstore()
        {
            Console.Error.WriteLine("* TestGstore");
            int[] code = {
                ByteCode.ICONST, 42, ByteCode.GSTORE, 2, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 10, true);
            cpu.Run();

            Assert.Equal(5, cpu.ip);
            Assert.Equal(-1, cpu.sp);
            Assert.Equal(0, cpu.globals[0]);
            Assert.Equal(0, cpu.globals[1]);
            Assert.Equal(42, cpu.globals[2]);
        }

        // GLOAD
        [Fact]
        public void TestGload()
        {
            Console.Error.WriteLine("* TestGload");
            int[] code = {
                ByteCode.GLOAD, 1, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 10, true);
            cpu.globals[1] = 42;
            cpu.Run();

            Assert.Equal(3, cpu.ip);
            Assert.Equal(0, cpu.sp);
            Assert.Equal(42, cpu.stack[0]);
        }

        // STORE
        [Fact]
        public void TestStore()
        {
            Console.Error.WriteLine("* TestStore");
            int[] code = {
                ByteCode.ICONST, 100, ByteCode.ICONST, 101, ByteCode.STORE, 1, ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 0, 10, true);
            cpu.fp = 0;
            cpu.stack[0] = 1; // arg1
            cpu.stack[1] = 1; // nargs
            cpu.stack[2] = 0; // previous fp
            cpu.stack[3] = 1; // return address
            cpu.sp = 3;
            cpu.fp = cpu.sp;
            cpu.Run();

            Assert.Equal(7, cpu.ip);
            Assert.Equal(4, cpu.sp);
            Assert.Equal(3, cpu.fp);
            Assert.Equal(101, cpu.stack[4]); // 100 is overwritten to 101 by STORE
        }

        // BR
        [Fact]
        public void TestBranch()
        {
            Console.Error.WriteLine("* TestBranch");
            int[] code = {
                ByteCode.BR, 3, // 0
                ByteCode.HALT,  // 2
                ByteCode.ICONST, 42, // 3
                ByteCode.HALT, // 5
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();
            Assert.Equal(42, cpu.stack[0]);
            Assert.Equal(6, cpu.ip);
        }

        // BRF
        [Fact]
        public void TestBranchFalse1()
        {
            Console.Error.WriteLine("* TestBranchFalse1");
            int[] code = {
                ByteCode.ICONST, 0, // 0
                ByteCode.BRF, 5, // 2
                ByteCode.HALT,  // 4
                ByteCode.ICONST, 42, // 5
                ByteCode.HALT, // 7
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();
            Assert.Equal(42, cpu.stack[0]);
            Assert.Equal(8, cpu.ip);
            Assert.Equal(0, cpu.sp);
        }

        [Fact]
        public void TestBranchFalse2()
        {
            Console.Error.WriteLine("* TestBranchFalse2");
            int[] code = {
                ByteCode.ICONST, 1, // 0
                ByteCode.BRF, 5, // 2
                ByteCode.HALT,  // 4
                ByteCode.ICONST, 42, // 5
                ByteCode.HALT, // 7
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();
            Assert.Equal(1, cpu.stack[0]);
            Assert.Equal(5, cpu.ip);
            Assert.Equal(-1, cpu.sp);
        }

        // BRT
        [Fact]
        public void TestBranchTrue1()
        {
            Console.Error.WriteLine("* TestBranchTrue1");
            int[] code = {
                ByteCode.ICONST, 0, // 0
                ByteCode.BRT, 5, // 2
                ByteCode.HALT,  // 4
                ByteCode.ICONST, 42, // 5
                ByteCode.HALT, // 7
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();
            Assert.Equal(0, cpu.stack[0]);
            Assert.Equal(5, cpu.ip);
            Assert.Equal(-1, cpu.sp);
        }

        [Fact]
        public void TestBranchTrue2()
        {
            Console.Error.WriteLine("* TestBranchTrue2");
            int[] code = {
                ByteCode.ICONST, 1, // 0
                ByteCode.BRT, 5, // 2
                ByteCode.HALT,  // 4
                ByteCode.ICONST, 42, // 5
                ByteCode.HALT, // 7
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(42, cpu.stack[0]);
            Assert.Equal(8, cpu.ip);
            Assert.Equal(0, cpu.sp);
        }

        // POP
        [Fact]
        public void TestPop()
        {
            Console.Error.WriteLine("* TestPop");
            int[] code = {
                ByteCode.ICONST, 1, // 0 sp->0
                ByteCode.ICONST, 2, // 2 sp->1
                ByteCode.ICONST, 3, // 4 sp->2
                ByteCode.POP, // 6 sp->1
                ByteCode.HALT, // 7
            };
            Cpu cpu = new Cpu(code, 0, 0, true);
            cpu.Run();

            Assert.Equal(8, cpu.ip);
            Assert.Equal(1, cpu.sp);
        }

        // CALL/RET/LOAD/ILT/BRF
        [Fact]
        public void TestFunction()
        {
            Console.Error.WriteLine("* TestFunction");
            int[] code = {
                // FACT(n) funciton
                // if N<2 return 1
                ByteCode.LOAD, -3, // 0
                ByteCode.ICONST, 2, // 2
                ByteCode.ILT, // 4
                ByteCode.BRF, 10, // 5
                ByteCode.ICONST, 1, // 7
                ByteCode.RET, // 9
                // return N * FACT(N-1)
                ByteCode.LOAD, -3, // 10
                ByteCode.LOAD, -3, // 12
                ByteCode.ICONST, 1, // 14
                ByteCode.ISUB, // 16
                ByteCode.CALL, 0, 1, // 17
                ByteCode.IMUL, // 20
                ByteCode.RET, // 21
                // print FACT(6)
                ByteCode.ICONST, 6, // 22 ... main (entry)
                ByteCode.CALL, 0, 1, // 14
                ByteCode.PRINT, // 27
                ByteCode.HALT,
            };
            Cpu cpu = new Cpu(code, 22, 0, true);
            cpu.Run();
            // FACT(6) = 6 * 5 * 4 * 3 * 2 * 1 = 720
            Assert.Equal(720, cpu.stack[0]);
        }
    }
}
