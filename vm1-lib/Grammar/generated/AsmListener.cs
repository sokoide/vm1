//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Asm.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="AsmParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface IAsmListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="AsmParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProg([NotNull] AsmParser.ProgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="AsmParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProg([NotNull] AsmParser.ProgContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>nopStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNopStmt([NotNull] AsmParser.NopStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>nopStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNopStmt([NotNull] AsmParser.NopStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>iaddStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIaddStmt([NotNull] AsmParser.IaddStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>iaddStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIaddStmt([NotNull] AsmParser.IaddStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>isubStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIsubStmt([NotNull] AsmParser.IsubStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>isubStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIsubStmt([NotNull] AsmParser.IsubStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>imulStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImulStmt([NotNull] AsmParser.ImulStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>imulStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImulStmt([NotNull] AsmParser.ImulStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>iltStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIltStmt([NotNull] AsmParser.IltStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>iltStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIltStmt([NotNull] AsmParser.IltStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>ieqStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIeqStmt([NotNull] AsmParser.IeqStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>ieqStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIeqStmt([NotNull] AsmParser.IeqStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>brStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBrStmt([NotNull] AsmParser.BrStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>brStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBrStmt([NotNull] AsmParser.BrStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>brtStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBrtStmt([NotNull] AsmParser.BrtStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>brtStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBrtStmt([NotNull] AsmParser.BrtStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>brfStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBrfStmt([NotNull] AsmParser.BrfStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>brfStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBrfStmt([NotNull] AsmParser.BrfStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>iconstStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIconstStmt([NotNull] AsmParser.IconstStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>iconstStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIconstStmt([NotNull] AsmParser.IconstStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>loadStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLoadStmt([NotNull] AsmParser.LoadStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>loadStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLoadStmt([NotNull] AsmParser.LoadStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>gloadStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGloadStmt([NotNull] AsmParser.GloadStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>gloadStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGloadStmt([NotNull] AsmParser.GloadStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>storeStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStoreStmt([NotNull] AsmParser.StoreStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>storeStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStoreStmt([NotNull] AsmParser.StoreStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>gstoreStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGstoreStmt([NotNull] AsmParser.GstoreStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>gstoreStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGstoreStmt([NotNull] AsmParser.GstoreStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>printStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrintStmt([NotNull] AsmParser.PrintStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>printStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrintStmt([NotNull] AsmParser.PrintStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>popStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPopStmt([NotNull] AsmParser.PopStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>popStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPopStmt([NotNull] AsmParser.PopStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>callStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCallStmt([NotNull] AsmParser.CallStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>callStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCallStmt([NotNull] AsmParser.CallStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>retStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRetStmt([NotNull] AsmParser.RetStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>retStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRetStmt([NotNull] AsmParser.RetStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>haltStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHaltStmt([NotNull] AsmParser.HaltStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>haltStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHaltStmt([NotNull] AsmParser.HaltStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>labelStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabelStmt([NotNull] AsmParser.LabelStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>labelStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabelStmt([NotNull] AsmParser.LabelStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>blankStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlankStmt([NotNull] AsmParser.BlankStmtContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>blankStmt</c>
	/// labeled alternative in <see cref="AsmParser.stmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlankStmt([NotNull] AsmParser.BlankStmtContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>labelExpr</c>
	/// labeled alternative in <see cref="AsmParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabelExpr([NotNull] AsmParser.LabelExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>labelExpr</c>
	/// labeled alternative in <see cref="AsmParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabelExpr([NotNull] AsmParser.LabelExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>intExpr</c>
	/// labeled alternative in <see cref="AsmParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntExpr([NotNull] AsmParser.IntExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>intExpr</c>
	/// labeled alternative in <see cref="AsmParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntExpr([NotNull] AsmParser.IntExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>idExpr</c>
	/// labeled alternative in <see cref="AsmParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdExpr([NotNull] AsmParser.IdExprContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>idExpr</c>
	/// labeled alternative in <see cref="AsmParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdExpr([NotNull] AsmParser.IdExprContext context);
}
