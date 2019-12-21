using System;
using System.IO;

namespace vm1_lib
{
    public class Cpu
    {
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
        public Cpu(int[] code, int ip, int dataSize, int stackSize, bool traceOutput = false)
        {
            this.code = code;
            this.ip = ip;
            this.sp = -1;
            globals = new int[dataSize];
            stack = new int[stackSize];
            this.traceOutput = traceOutput;
        }
        #endregion

        public void Run(TextWriter o)
        {
            int a, b, v, addr, offset, nargs;
            bool running = true;
            while (ip < code.Length && running)
            {
                int opcode = code[ip];
                ByteCode.Instruction instruction = ByteCode.Instructions[opcode];
                Trace("{0:d04}: {1}", ip, instruction.Name);
                if (instruction.NumOperands == 1)
                {
                    Trace("\t{0}", code[ip + 1]);
                }
                else if (instruction.NumOperands == 2)
                {
                    Trace("\t{0}", code[ip + 2]);
                }
                TraceLn("");
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
                        if (stack[sp--] == 1)
                        {
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
                        o.WriteLine(stack[sp--]);
                        break;
                    case ByteCode.POP:
                        sp--;
                        break;
                    case ByteCode.CALL:
                        addr = code[ip++];
                        nargs = code[ip++];
                        stack[++sp] = nargs;
                        stack[++sp] = fp;
                        stack[++sp] = ip;
                        fp = sp;
                        ip = addr;
                        break;
                    case ByteCode.RET:
                        v = stack[sp--];
                        sp = fp;
                        ip = stack[sp--];
                        fp = stack[sp--];
                        nargs = stack[sp--];
                        sp -= nargs; // pop all args
                        stack[++sp] = v;
                        break;
                    case ByteCode.HALT:
                        running = false;
                        break;
                    default:
                        throw new NotImplementedException(
                            string.Format("Instruction {0} not implemented.", opcode));
                }
                DumpStack();
                DumpData();
                TraceLn("");
            }
        }

        private void DumpStack()
        {
            Trace("\tStack: ");
            for (int i = 0; i < sp; i++)
            {
                Trace("{0:#,0} ", stack[i]);
            }
            TraceLn("");
        }

        private void DumpData()
        {
            int addr;
            for (addr = 0; addr < globals.Length; addr += 16)
            {
                Trace("\tData {0:X4}: ", addr);
                for (int i = 0; i < 16 && (addr + i) < globals.Length; i++)
                {
                    Trace("{0:X4} ", globals[addr + i]);
                }
                TraceLn("");
            }
        }

        private void Trace(string fmt, params object[] p)
        {
            if (traceOutput)
            {
                Console.Error.Write(fmt, p);
            }
        }

        private void TraceLn(string fmt, params object[] p)
        {
            if (traceOutput)
            {
                Console.Error.WriteLine(fmt, p);
            }
        }
    }
}
