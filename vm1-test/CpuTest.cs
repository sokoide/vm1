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
    }
}
