using Antlr4.Runtime.Misc;
using System;
using System.IO;

namespace vm1_lib.Grammar
{
    class AsmListener : AsmBaseListener
    {
        private AsmParser parser;
        internal Stream w;

        public AsmListener(AsmParser parser, Stream w)
        {
            this.parser = parser;
            this.w = w;
        }

        public override void EnterProg(AsmParser.ProgContext context)
        {
            Util.WriteLine("* EnterProg");
        }
        public override void ExitProg(AsmParser.ProgContext context)
        {
            Util.WriteLine("* ExitProg");
        }

        public override void ExitNopStmt([NotNull] AsmParser.NopStmtContext context)
        {
            Util.WriteLine("* ExitNopStmt");
            WriteInt32(ByteCode.NOP);
        }

        public override void ExitIaddStmt([NotNull] AsmParser.IaddStmtContext context)
        {
            Util.WriteLine("* ExitIaddStmt");
            WriteInt32(ByteCode.IADD);
        }

        public override void ExitIsubStmt([NotNull] AsmParser.IsubStmtContext context)
        {
            Util.WriteLine("* ExitIsubStmt");
            WriteInt32(ByteCode.ISUB);
        }

        public override void ExitImulStmt([NotNull] AsmParser.ImulStmtContext context)
        {
            Util.WriteLine("* ExitImulStmt");
            WriteInt32(ByteCode.IMUL);
        }

        public override void ExitIltStmt([NotNull] AsmParser.IltStmtContext context)
        {
            Util.WriteLine("* ExitIltStmt");
            WriteInt32(ByteCode.ILT);
        }

        public override void ExitIeqStmt([NotNull] AsmParser.IeqStmtContext context)
        {
            Util.WriteLine("* ExitIeqStmt");
            WriteInt32(ByteCode.IEQ);
        }

        public override void ExitBrStmt([NotNull] AsmParser.BrStmtContext context)
        {
            Util.WriteLine("* ExitBrStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.BR);
            WriteInt32(int.Parse(context.expr().GetText()));
        }

        public override void ExitBrtStmt([NotNull] AsmParser.BrtStmtContext context)
        {
            Util.WriteLine("* ExitBrtStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.BRT);
            WriteInt32(int.Parse(context.expr().GetText()));
        }


        public override void ExitBrfStmt([NotNull] AsmParser.BrfStmtContext context)
        {
            Util.WriteLine("* ExitBrfStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.BRF);
            WriteInt32(int.Parse(context.expr().GetText()));
        }

        public override void ExitIconstStmt([NotNull] AsmParser.IconstStmtContext context)
        {
            Util.WriteLine("* ExitIconstStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.ICONST);
            WriteInt32(int.Parse(context.expr().GetText()));
        }

        public override void ExitLoadStmt([NotNull] AsmParser.LoadStmtContext context)
        {
            Util.WriteLine("* ExitLoadStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.LOAD);
            WriteInt32(int.Parse(context.expr().GetText()));
        }

        public override void ExitGloadStmt([NotNull] AsmParser.GloadStmtContext context)
        {
            Util.WriteLine("* ExitGloadStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.GLOAD);
            WriteInt32(int.Parse(context.expr().GetText()));
        }

        public override void ExitStoreStmt([NotNull] AsmParser.StoreStmtContext context)
        {
            Util.WriteLine("* ExitStoreStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.STORE);
            WriteInt32(int.Parse(context.expr().GetText()));
        }

        public override void ExitGstoreStmt([NotNull] AsmParser.GstoreStmtContext context)
        {
            Util.WriteLine("* ExitGstoreStmt: {0}, {1}, {2}",
                            context.expr().GetText(),
                            context.expr().GetType(),
                            context.expr().getAltNumber()
                );
            WriteInt32(ByteCode.GSTORE);
            WriteInt32(int.Parse(context.expr().GetText()));
        }

        public override void ExitPrintStmt([NotNull] AsmParser.PrintStmtContext context)
        {
            Util.WriteLine("* ExitPrintStmt");
            WriteInt32(ByteCode.PRINT);
        }

        public override void ExitPopStmt([NotNull] AsmParser.PopStmtContext context)
        {
            Util.WriteLine("* ExitPopStmt");
            WriteInt32(ByteCode.POP);
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
            WriteInt32(ByteCode.CALL);
            WriteInt32(int.Parse(context.expr(0).GetText()));
            WriteInt32(int.Parse(context.expr(1).GetText()));
        }

        public override void ExitRetStmt([NotNull] AsmParser.RetStmtContext context)
        {
            Util.WriteLine("* ExitRetStmt");
            WriteInt32(ByteCode.RET);
        }

        public override void ExitHaltStmt([NotNull] AsmParser.HaltStmtContext context)
        {
            Util.WriteLine("* ExitHaltStmt");
            WriteInt32(ByteCode.HALT);
        }

        public override void ExitIntExpr([NotNull] AsmParser.IntExprContext context)
        {
            Util.WriteLine("* ExitIntExpr: {0}", context.INT());
        }

        #region internal methods
        internal void WriteInt32(int i32)
        {
            byte[] bytes = BitConverter.GetBytes(i32);
            w.Write(bytes, 0, bytes.Length);
        }
        #endregion
    }
}
