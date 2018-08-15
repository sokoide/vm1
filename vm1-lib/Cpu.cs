using System;

namespace vm1_lib
{
    public class Cpu
    {
        #region inner class
        public class Instruction
        {
            String name;
            int numOperands = 0;

            public String Name
            {
                get { return Name; }
            }

            public int NumOperands
            {
                get { return NumOperands; }
            }

            public Instruction(String name, int numOperands = 0)
            {
                this.name = name;
                this.numOperands = numOperands;
            }
        }
        #endregion

        // consts
        public const int kStackSize = 128;

        // registers
        public int ip;
        public int sp = -1;
        int fp;

        // memory
        int[] data;
        int[] code;
        public int[] stack;

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

        public static Instruction[] Instructions = {
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
            new Instruction("print", 1),
            new Instruction("pop", 1),
            new Instruction("call", 2),
            new Instruction("ret"),
            new Instruction("halt", 1),
        };

        #region ctor
        public Cpu(int[] code, int ip, int dataSize)
        {
            this.code = code;
            this.ip = ip;
            data = new int[dataSize];
            stack = new int[kStackSize];
        }
        #endregion

        public void Run(){
            int a, b, v;
            while (ip < code.Length)
            {
                int opcode = code[ip];
                ip++;
                switch (opcode)
                {
                    case IADD:
                        a = stack[sp--];
                        b = stack[sp--];
                        v = b + a;
                        stack[++sp] = v;
                        break;
                    case ISUB:
                        a = stack[sp--];
                        b = stack[sp--];
                        v = b - a;
                        stack[++sp] = v;
                        break;
                    case IMUL:
                        a = stack[sp--];
                        b = stack[sp--];
                        v = b * a;
                        stack[++sp] = v;
                        break;
                    case ILT:
                        break;
                    case IEQ:
                        break;
                    case BR:
                        break;
                    case BRT:
                        break;
                    case BRF:
                        break;
                    case ICONST:
                        v = code[ip++];
                        stack[++sp] = v;
                        break;
                    case LOAD:
                        break;
                    case GLOAD:
                        break;
                    case STORE:
                        break;
                    case PRINT:
                        break;
                    case POP:
                        break;
                    case CALL:
                        break;
                    case RET:
                        break;
                    case HALT:
                        return;
                }
            }
        }

        public static int dummy(int a, int b)
        {
            return a + b;
        }

    }
}
