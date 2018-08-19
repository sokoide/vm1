using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.IO;

namespace vm1_lib.Grammar
{
    class AsmListener : AsmBaseListener
    {
        private AsmParser parser;
        internal Stream w;
        internal Dictionary<string, int> labeltable; // label -> ip
        internal Dictionary<string, List<int>> deferedLabelTable; // label -> ip
        internal int ip;

        public AsmListener(AsmParser parser, Stream w)
        {
            this.parser = parser;
            this.w = w;
        }

        public override void EnterProg(AsmParser.ProgContext context)
        {
            Util.WriteLine("* EnterProg");
            Init();
        }
        public override void ExitProg(AsmParser.ProgContext context)
        {
            Util.WriteLine("* ExitProg");
        }

        public override void ExitNopStmt([NotNull] AsmParser.NopStmtContext context)
        {
            Util.WriteLine("* ExitNopStmt");
            WriteInt32Code(ByteCode.NOP);
        }

        public override void ExitIaddStmt([NotNull] AsmParser.IaddStmtContext context)
        {
            Util.WriteLine("* ExitIaddStmt");
            WriteInt32Code(ByteCode.IADD);
        }

        public override void ExitIsubStmt([NotNull] AsmParser.IsubStmtContext context)
        {
            Util.WriteLine("* ExitIsubStmt");
            WriteInt32Code(ByteCode.ISUB);
        }

        public override void ExitImulStmt([NotNull] AsmParser.ImulStmtContext context)
        {
            Util.WriteLine("* ExitImulStmt");
            WriteInt32Code(ByteCode.IMUL);
        }

        public override void ExitIltStmt([NotNull] AsmParser.IltStmtContext context)
        {
            Util.WriteLine("* ExitIltStmt");
            WriteInt32Code(ByteCode.ILT);
        }

        public override void ExitIeqStmt([NotNull] AsmParser.IeqStmtContext context)
        {
            Util.WriteLine("* ExitIeqStmt");
            WriteInt32Code(ByteCode.IEQ);
        }

        public override void ExitBrStmt([NotNull] AsmParser.BrStmtContext context)
        {
            Util.WriteLine("* ExitBrStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );

            WriteInt32Code(ByteCode.BR);
            Type t = context.expr().GetType();
            HandleAddressLabel(t, context.expr().GetText());
        }

        public override void ExitBrtStmt([NotNull] AsmParser.BrtStmtContext context)
        {
            Util.WriteLine("* ExitBrtStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32Code(ByteCode.BRT);
            Type t = context.expr().GetType();
            HandleAddressLabel(t, context.expr().GetText());
        }


        public override void ExitBrfStmt([NotNull] AsmParser.BrfStmtContext context)
        {
            Util.WriteLine("* ExitBrfStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32Code(ByteCode.BRF);
            Type t = context.expr().GetType();
            HandleAddressLabel(t, context.expr().GetText());
        }

        public override void ExitIconstStmt([NotNull] AsmParser.IconstStmtContext context)
        {
            Util.WriteLine("* ExitIconstStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32Code(ByteCode.ICONST);
            WriteInt32Code(int.Parse(context.expr().GetText()));
        }

        public override void ExitLoadStmt([NotNull] AsmParser.LoadStmtContext context)
        {
            Util.WriteLine("* ExitLoadStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32Code(ByteCode.LOAD);
            WriteInt32Code(int.Parse(context.expr().GetText()));
        }

        public override void ExitGloadStmt([NotNull] AsmParser.GloadStmtContext context)
        {
            Util.WriteLine("* ExitGloadStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32Code(ByteCode.GLOAD);
            WriteInt32Code(int.Parse(context.expr().GetText()));
        }

        public override void ExitStoreStmt([NotNull] AsmParser.StoreStmtContext context)
        {
            Util.WriteLine("* ExitStoreStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32Code(ByteCode.STORE);
            WriteInt32Code(int.Parse(context.expr().GetText()));
        }

        public override void ExitGstoreStmt([NotNull] AsmParser.GstoreStmtContext context)
        {
            Util.WriteLine("* ExitGstoreStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32Code(ByteCode.GSTORE);
            WriteInt32Code(int.Parse(context.expr().GetText()));
        }

        public override void ExitPrintStmt([NotNull] AsmParser.PrintStmtContext context)
        {
            Util.WriteLine("* ExitPrintStmt");
            WriteInt32Code(ByteCode.PRINT);
        }

        public override void ExitPopStmt([NotNull] AsmParser.PopStmtContext context)
        {
            Util.WriteLine("* ExitPopStmt");
            WriteInt32Code(ByteCode.POP);
        }

        public override void ExitCallStmt([NotNull] AsmParser.CallStmtContext context)
        {
            Util.WriteLine("* ExitCallStmt 1st arg: {0}, {1}, {2}",
                            context.expr(0).GetText(),
                            context.expr(0).GetType(),
                            context.expr(0).getAltNumber()
                );
            Util.WriteLine("* ExitCallStmt 2nd arg: {0}, {1}, {2}",
                            context.expr(1).GetText(),
                            context.expr(1).GetType(),
                            context.expr(1).getAltNumber()
                );
            WriteInt32Code(ByteCode.CALL);
            WriteInt32Code(int.Parse(context.expr(0).GetText()));
            WriteInt32Code(int.Parse(context.expr(1).GetText()));
        }

        public override void ExitRetStmt([NotNull] AsmParser.RetStmtContext context)
        {
            Util.WriteLine("* ExitRetStmt");
            WriteInt32Code(ByteCode.RET);
        }

        public override void ExitHaltStmt([NotNull] AsmParser.HaltStmtContext context)
        {
            Util.WriteLine("* ExitHaltStmt");
            WriteInt32Code(ByteCode.HALT);
        }

        public override void ExitLabelStmt([NotNull] AsmParser.LabelStmtContext context)
        {
            Util.WriteLine("* ExitLabelStmt: {0}", context.LABEL());

            string label = context.LABEL().GetText();
            int labelAddr = ip;
            labeltable[label] = labelAddr;
            if (deferedLabelTable.ContainsKey(label))
            {
                foreach (int targetAddr in deferedLabelTable[label])
                {
                    UpdateInt32Code(targetAddr, labelAddr);
                }
                deferedLabelTable.Remove(label);
            }
        }

        public override void ExitIntExpr([NotNull] AsmParser.IntExprContext context)
        {
            Util.WriteLine("* ExitIntExpr: {0}", context.INT());
        }

        public override void ExitIdExpr([NotNull] AsmParser.IdExprContext context)
        {
            Util.WriteLine("* ExitIdExpr: {0}", context.ID());
        }

        public override void ExitLabelExpr([NotNull] AsmParser.LabelExprContext context)
        {
            Util.WriteLine("* ExitLabelExpr: {0}", context.LABEL());
        }

        #region internal methods
        internal void Init()
        {
            ip = 0;
            labeltable = new Dictionary<string, int>();
            deferedLabelTable = new Dictionary<string, List<int>>();
        }

        internal void HandleAddressLabel(Type t, string operand)
        {
            if (t == typeof(AsmParser.IntExprContext))
            {
                WriteInt32Code(int.Parse(operand));
            }
            else if (t == typeof(AsmParser.LabelExprContext))
            {
                int addr = ResolveLabel(operand);
                WriteInt32Code(addr);
            }
        }

        internal int ResolveLabel(string label)
        {
            int addr = -1;

            if (labeltable.ContainsKey(label))
            {
                addr = labeltable[label];
            } else
            {
                if (!deferedLabelTable.ContainsKey(label))
                {
                    deferedLabelTable[label] = new List<int>();
                }
                deferedLabelTable[label].Add(ip);
            }
            // return dummy address -1 if it's not in labeltable
            return addr;
        }

        internal void WriteInt32Code(int i32code)
        {
            byte[] bytes = BitConverter.GetBytes(i32code);
            w.Write(bytes, 0, bytes.Length);
            ip++;
        }

        internal void UpdateInt32Code(int targetAddr, int i32code)
        {
            long position = w.Position; // store the current position
            int ip = targetAddr * sizeof(int);
            w.Seek(ip, SeekOrigin.Begin);
            byte[] bytes = BitConverter.GetBytes(i32code);
            w.Write(bytes, 0, bytes.Length);
            w.Seek(position, SeekOrigin.Begin); // revert
        }
        #endregion
    }
}
