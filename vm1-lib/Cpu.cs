using System;

namespace vm1_lib
{
    public class Cpu
    {


        // consts
        public const int kStackSize = 128;

        // registers
        internal int ip;
        internal int sp;
        internal int fp;

        // memory
        internal int[] data;
        internal int[] code;
        internal int[] stack;

        // other variables
        internal bool traceOutput;

        #region ctor
        public Cpu(int[] code, int ip, int dataSize, bool traceOutput = false)
        {
            this.code = code;
            this.ip = ip;
            this.sp = -1;
            data = new int[dataSize];
            stack = new int[kStackSize];
            this.traceOutput = traceOutput;
        }
        #endregion

        public void Run()
        {
            int a, b, v;
            bool running = true;
            while (ip < code.Length && running)
            {
                int opcode = code[ip];
                ByteCode.Instruction instruction = ByteCode.Instructions[opcode];
                trace("{0:d04}: {1}", ip, instruction.Name);
                if (instruction.NumOperands == 1)
                {
                    trace("\t{0}", code[ip + 1]);
                }
                else if (instruction.NumOperands == 2)
                {
                    trace("\t{0}", code[ip + 2]);
                }
                traceln("");

                ip++;

                switch (opcode)
                {
                    case ByteCode.IADD:
                        a = stack[sp--];
                        b = stack[sp--];
                        v = b + a;
                        stack[++sp] = v;
                        break;
                    case ByteCode.ISUB:
                        a = stack[sp--];
                        b = stack[sp--];
                        v = b - a;
                        stack[++sp] = v;
                        break;
                    case ByteCode.IMUL:
                        a = stack[sp--];
                        b = stack[sp--];
                        v = b * a;
                        stack[++sp] = v;
                        break;
                    case ByteCode.ILT:
                        break;
                    case ByteCode.IEQ:
                        break;
                    case ByteCode.BR:
                        break;
                    case ByteCode.BRT:
                        break;
                    case ByteCode.BRF:
                        break;
                    case ByteCode.ICONST:
                        v = code[ip++];
                        stack[++sp] = v;
                        break;
                    case ByteCode.LOAD:
                        break;
                    case ByteCode.GLOAD:
                        break;
                    case ByteCode.STORE:
                        break;
                    case ByteCode.PRINT:
                        break;
                    case ByteCode.POP:
                        break;
                    case ByteCode.CALL:
                        break;
                    case ByteCode.RET:
                        break;
                    case ByteCode.HALT:
                        running = false;
                        break;
                }
                dump();
            }
        }

        private void dump()
        {
        }

        private void trace(string fmt, params object[] p)
        {
            if (traceOutput)
            {
                Console.Error.Write(fmt, p);
            }
        }

        private void traceln(string fmt, params object[] p)
        {
            if (traceOutput)
            {
                Console.Error.WriteLine(fmt, p);
            }
        }

        public static int dummy(int a, int b)
        {
            return a + b;
        }

    }
}
