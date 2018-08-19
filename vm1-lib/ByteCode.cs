using System;
namespace vm1_lib
{
    public class ByteCode
    {
        public const int NOP = 0;
        public const int IADD = 1;
        public const int ISUB = 2;
        public const int IMUL = 3;
        public const int ILT = 4;
        public const int IEQ = 5;
        public const int BR = 6;
        public const int BRT = 7;
        public const int BRF = 8;
        public const int ICONST = 9;
        public const int LOAD = 10;
        public const int GLOAD = 11;
        public const int STORE = 12;
        public const int GSTORE = 13;
        public const int PRINT = 14;
        public const int POP = 15;
        public const int CALL = 16;
        public const int RET = 17;
        public const int HALT = 18;

        #region inner class
        public class Instruction
        {
            String name;
            int numOperands = 0;

            public String Name
            {
                get { return name; }
            }

            public int NumOperands
            {
                get { return numOperands; }
            }

            public Instruction(String name, int numOperands = 0)
            {
                this.name = name;
                this.numOperands = numOperands;
            }
        }
        #endregion

        public static readonly Instruction[] Instructions = {
            new Instruction("nop"),
            new Instruction("iadd"),
            new Instruction("isub"),
            new Instruction("imul"),
            new Instruction("ilt"),
            new Instruction("ieq"),
            new Instruction("br", 1),
            new Instruction("brt", 1),
            new Instruction("brf", 1),
            new Instruction("iconst", 1),
            new Instruction("load", 1),
            new Instruction("gload", 1),
            new Instruction("store", 1),
            new Instruction("gstore", 1),
            new Instruction("print"),
            new Instruction("pop"),
            new Instruction("call", 2),
            new Instruction("ret"),
            new Instruction("halt"),
        };
    }
}
