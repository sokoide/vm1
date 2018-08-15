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
        internal int[] globals;
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
            globals = new int[dataSize];
            stack = new int[kStackSize];
            this.traceOutput = traceOutput;
        }
        #endregion

        public void Run()
        {
            int a, b, v, addr, offset;
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
                        b = stack[sp--];
                        a = stack[sp--];
                        stack[++sp] = (a < b) ? 1 : 0;
                        break;
                    case ByteCode.IEQ:
                        b = stack[sp--];
                        a = stack[sp--];
                        stack[++sp] = (a == b) ? 1 : 0;
                        break;
                    case ByteCode.BR:
                        ip = code[ip++];
                        break;
                    case ByteCode.BRT:
                        addr = code[ip++];
                        if (stack[sp--]==1){
                            ip = addr;
                        }
                        break;
                    case ByteCode.BRF:
                        addr = code[ip++];
                        if (stack[sp--] == 0)
                        {
                            ip = addr;
                        }
                        break;
                    case ByteCode.ICONST:
                        v = code[ip++];
                        stack[++sp] = v;
                        break;
                    case ByteCode.LOAD:
                        offset = code[ip++];
                        stack[++sp] = stack[fp + offset];
                        break;
                    case ByteCode.GLOAD:
                        addr = code[ip++];
                        stack[++sp] = globals[addr];
                        break;
                    case ByteCode.STORE:
                        offset = code[ip++];
                        stack[fp + offset] = stack[sp--];
                        break;
                    case ByteCode.GSTORE:
                        addr = code[ip++];
                        globals[addr] = stack[sp--];
                        break;
                    case ByteCode.PRINT:
                        Console.WriteLine(stack[sp--]);
                        break;
                    case ByteCode.POP:
                        sp--;
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
    }
}
