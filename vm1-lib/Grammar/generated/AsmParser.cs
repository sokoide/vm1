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

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class AsmParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		COMMENT=1, NOP=2, IADD=3, ISUB=4, IMUL=5, ILT=6, IEQ=7, BR=8, BRT=9, BRF=10, 
		ICONST=11, LOAD=12, GLOAD=13, STORE=14, GSTORE=15, PRINT=16, POP=17, CALL=18, 
		RET=19, HALT=20, ID=21, INT=22, NEWLINE=23, WS=24;
	public const int
		RULE_prog = 0, RULE_stmt = 1, RULE_expr = 2;
	public static readonly string[] ruleNames = {
		"prog", "stmt", "expr"
	};

	private static readonly string[] _LiteralNames = {
		null, null, "'nop'", "'iadd'", "'isub'", "'mul'", "'ilt'", "'ieq'", "'br'", 
		"'brt'", "'brf'", "'iconst'", "'load'", "'gload'", "'store'", "'gstore'", 
		"'print'", "'pop'", "'call'", "'ret'", "'halt'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "COMMENT", "NOP", "IADD", "ISUB", "IMUL", "ILT", "IEQ", "BR", "BRT", 
		"BRF", "ICONST", "LOAD", "GLOAD", "STORE", "GSTORE", "PRINT", "POP", "CALL", 
		"RET", "HALT", "ID", "INT", "NEWLINE", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Asm.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static AsmParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public AsmParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public AsmParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class ProgContext : ParserRuleContext {
		public StmtContext[] stmt() {
			return GetRuleContexts<StmtContext>();
		}
		public StmtContext stmt(int i) {
			return GetRuleContext<StmtContext>(i);
		}
		public ProgContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_prog; } }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterProg(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitProg(this);
		}
	}

	[RuleVersion(0)]
	public ProgContext prog() {
		ProgContext _localctx = new ProgContext(Context, State);
		EnterRule(_localctx, 0, RULE_prog);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 7;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			do {
				{
				{
				State = 6; stmt();
				}
				}
				State = 9;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NOP) | (1L << IADD) | (1L << ISUB) | (1L << IMUL) | (1L << ILT) | (1L << IEQ) | (1L << BR) | (1L << BRT) | (1L << BRF) | (1L << ICONST) | (1L << LOAD) | (1L << GLOAD) | (1L << STORE) | (1L << GSTORE) | (1L << PRINT) | (1L << POP) | (1L << CALL) | (1L << RET) | (1L << HALT) | (1L << NEWLINE))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StmtContext : ParserRuleContext {
		public StmtContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_stmt; } }
	 
		public StmtContext() { }
		public virtual void CopyFrom(StmtContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ImulStmtContext : StmtContext {
		public ITerminalNode IMUL() { return GetToken(AsmParser.IMUL, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public ImulStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterImulStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitImulStmt(this);
		}
	}
	public partial class RetStmtContext : StmtContext {
		public ITerminalNode RET() { return GetToken(AsmParser.RET, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public RetStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterRetStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitRetStmt(this);
		}
	}
	public partial class IsubStmtContext : StmtContext {
		public ITerminalNode ISUB() { return GetToken(AsmParser.ISUB, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public IsubStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterIsubStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitIsubStmt(this);
		}
	}
	public partial class IaddStmtContext : StmtContext {
		public ITerminalNode IADD() { return GetToken(AsmParser.IADD, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public IaddStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterIaddStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitIaddStmt(this);
		}
	}
	public partial class HaltStmtContext : StmtContext {
		public ITerminalNode HALT() { return GetToken(AsmParser.HALT, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public HaltStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterHaltStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitHaltStmt(this);
		}
	}
	public partial class GstoreStmtContext : StmtContext {
		public ITerminalNode GSTORE() { return GetToken(AsmParser.GSTORE, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public GstoreStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterGstoreStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitGstoreStmt(this);
		}
	}
	public partial class PopStmtContext : StmtContext {
		public ITerminalNode POP() { return GetToken(AsmParser.POP, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public PopStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterPopStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitPopStmt(this);
		}
	}
	public partial class IconstStmtContext : StmtContext {
		public ITerminalNode ICONST() { return GetToken(AsmParser.ICONST, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public IconstStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterIconstStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitIconstStmt(this);
		}
	}
	public partial class LoadStmtContext : StmtContext {
		public ITerminalNode LOAD() { return GetToken(AsmParser.LOAD, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public LoadStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterLoadStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitLoadStmt(this);
		}
	}
	public partial class BrStmtContext : StmtContext {
		public ITerminalNode BR() { return GetToken(AsmParser.BR, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public BrStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterBrStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitBrStmt(this);
		}
	}
	public partial class StoreStmtContext : StmtContext {
		public ITerminalNode STORE() { return GetToken(AsmParser.STORE, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public StoreStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterStoreStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitStoreStmt(this);
		}
	}
	public partial class BrfStmtContext : StmtContext {
		public ITerminalNode BRF() { return GetToken(AsmParser.BRF, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public BrfStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterBrfStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitBrfStmt(this);
		}
	}
	public partial class PrintStmtContext : StmtContext {
		public ITerminalNode PRINT() { return GetToken(AsmParser.PRINT, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public PrintStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterPrintStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitPrintStmt(this);
		}
	}
	public partial class BlankStmtContext : StmtContext {
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public BlankStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterBlankStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitBlankStmt(this);
		}
	}
	public partial class CallStmtContext : StmtContext {
		public ITerminalNode CALL() { return GetToken(AsmParser.CALL, 0); }
		public ExprContext[] expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public CallStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterCallStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitCallStmt(this);
		}
	}
	public partial class BrtStmtContext : StmtContext {
		public ITerminalNode BRT() { return GetToken(AsmParser.BRT, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public BrtStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterBrtStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitBrtStmt(this);
		}
	}
	public partial class IltStmtContext : StmtContext {
		public ITerminalNode ILT() { return GetToken(AsmParser.ILT, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public IltStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterIltStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitIltStmt(this);
		}
	}
	public partial class IeqStmtContext : StmtContext {
		public ITerminalNode IEQ() { return GetToken(AsmParser.IEQ, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public IeqStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterIeqStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitIeqStmt(this);
		}
	}
	public partial class NopStmtContext : StmtContext {
		public ITerminalNode NOP() { return GetToken(AsmParser.NOP, 0); }
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public NopStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterNopStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitNopStmt(this);
		}
	}
	public partial class GloadStmtContext : StmtContext {
		public ITerminalNode GLOAD() { return GetToken(AsmParser.GLOAD, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode NEWLINE() { return GetToken(AsmParser.NEWLINE, 0); }
		public GloadStmtContext(StmtContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterGloadStmt(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitGloadStmt(this);
		}
	}

	[RuleVersion(0)]
	public StmtContext stmt() {
		StmtContext _localctx = new StmtContext(Context, State);
		EnterRule(_localctx, 2, RULE_stmt);
		try {
			State = 69;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case NOP:
				_localctx = new NopStmtContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 11; Match(NOP);
				State = 12; Match(NEWLINE);
				}
				break;
			case IADD:
				_localctx = new IaddStmtContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 13; Match(IADD);
				State = 14; Match(NEWLINE);
				}
				break;
			case ISUB:
				_localctx = new IsubStmtContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 15; Match(ISUB);
				State = 16; Match(NEWLINE);
				}
				break;
			case IMUL:
				_localctx = new ImulStmtContext(_localctx);
				EnterOuterAlt(_localctx, 4);
				{
				State = 17; Match(IMUL);
				State = 18; Match(NEWLINE);
				}
				break;
			case ILT:
				_localctx = new IltStmtContext(_localctx);
				EnterOuterAlt(_localctx, 5);
				{
				State = 19; Match(ILT);
				State = 20; Match(NEWLINE);
				}
				break;
			case IEQ:
				_localctx = new IeqStmtContext(_localctx);
				EnterOuterAlt(_localctx, 6);
				{
				State = 21; Match(IEQ);
				State = 22; Match(NEWLINE);
				}
				break;
			case BR:
				_localctx = new BrStmtContext(_localctx);
				EnterOuterAlt(_localctx, 7);
				{
				State = 23; Match(BR);
				State = 24; expr();
				State = 25; Match(NEWLINE);
				}
				break;
			case BRT:
				_localctx = new BrtStmtContext(_localctx);
				EnterOuterAlt(_localctx, 8);
				{
				State = 27; Match(BRT);
				State = 28; expr();
				State = 29; Match(NEWLINE);
				}
				break;
			case BRF:
				_localctx = new BrfStmtContext(_localctx);
				EnterOuterAlt(_localctx, 9);
				{
				State = 31; Match(BRF);
				State = 32; expr();
				State = 33; Match(NEWLINE);
				}
				break;
			case ICONST:
				_localctx = new IconstStmtContext(_localctx);
				EnterOuterAlt(_localctx, 10);
				{
				State = 35; Match(ICONST);
				State = 36; expr();
				State = 37; Match(NEWLINE);
				}
				break;
			case LOAD:
				_localctx = new LoadStmtContext(_localctx);
				EnterOuterAlt(_localctx, 11);
				{
				State = 39; Match(LOAD);
				State = 40; expr();
				State = 41; Match(NEWLINE);
				}
				break;
			case GLOAD:
				_localctx = new GloadStmtContext(_localctx);
				EnterOuterAlt(_localctx, 12);
				{
				State = 43; Match(GLOAD);
				State = 44; expr();
				State = 45; Match(NEWLINE);
				}
				break;
			case STORE:
				_localctx = new StoreStmtContext(_localctx);
				EnterOuterAlt(_localctx, 13);
				{
				State = 47; Match(STORE);
				State = 48; expr();
				State = 49; Match(NEWLINE);
				}
				break;
			case GSTORE:
				_localctx = new GstoreStmtContext(_localctx);
				EnterOuterAlt(_localctx, 14);
				{
				State = 51; Match(GSTORE);
				State = 52; expr();
				State = 53; Match(NEWLINE);
				}
				break;
			case PRINT:
				_localctx = new PrintStmtContext(_localctx);
				EnterOuterAlt(_localctx, 15);
				{
				State = 55; Match(PRINT);
				State = 56; Match(NEWLINE);
				}
				break;
			case POP:
				_localctx = new PopStmtContext(_localctx);
				EnterOuterAlt(_localctx, 16);
				{
				State = 57; Match(POP);
				State = 58; Match(NEWLINE);
				}
				break;
			case CALL:
				_localctx = new CallStmtContext(_localctx);
				EnterOuterAlt(_localctx, 17);
				{
				State = 59; Match(CALL);
				State = 60; expr();
				State = 61; expr();
				State = 62; Match(NEWLINE);
				}
				break;
			case RET:
				_localctx = new RetStmtContext(_localctx);
				EnterOuterAlt(_localctx, 18);
				{
				State = 64; Match(RET);
				State = 65; Match(NEWLINE);
				}
				break;
			case HALT:
				_localctx = new HaltStmtContext(_localctx);
				EnterOuterAlt(_localctx, 19);
				{
				State = 66; Match(HALT);
				State = 67; Match(NEWLINE);
				}
				break;
			case NEWLINE:
				_localctx = new BlankStmtContext(_localctx);
				EnterOuterAlt(_localctx, 20);
				{
				State = 68; Match(NEWLINE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expr; } }
	 
		public ExprContext() { }
		public virtual void CopyFrom(ExprContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class IntExprContext : ExprContext {
		public ITerminalNode INT() { return GetToken(AsmParser.INT, 0); }
		public IntExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterIntExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitIntExpr(this);
		}
	}
	public partial class IdExprContext : ExprContext {
		public ITerminalNode ID() { return GetToken(AsmParser.ID, 0); }
		public IdExprContext(ExprContext context) { CopyFrom(context); }
		public override void EnterRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.EnterIdExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			IAsmListener typedListener = listener as IAsmListener;
			if (typedListener != null) typedListener.ExitIdExpr(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr() {
		ExprContext _localctx = new ExprContext(Context, State);
		EnterRule(_localctx, 4, RULE_expr);
		try {
			State = 73;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case INT:
				_localctx = new IntExprContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 71; Match(INT);
				}
				break;
			case ID:
				_localctx = new IdExprContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 72; Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\x1A', 'N', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x3', '\x2', '\x6', '\x2', '\n', 
		'\n', '\x2', '\r', '\x2', '\xE', '\x2', '\v', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x5', '\x3', 'H', '\n', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x5', '\x4', 'L', '\n', '\x4', '\x3', '\x4', '\x2', '\x2', '\x5', '\x2', 
		'\x4', '\x6', '\x2', '\x2', '\x2', '_', '\x2', '\t', '\x3', '\x2', '\x2', 
		'\x2', '\x4', 'G', '\x3', '\x2', '\x2', '\x2', '\x6', 'K', '\x3', '\x2', 
		'\x2', '\x2', '\b', '\n', '\x5', '\x4', '\x3', '\x2', '\t', '\b', '\x3', 
		'\x2', '\x2', '\x2', '\n', '\v', '\x3', '\x2', '\x2', '\x2', '\v', '\t', 
		'\x3', '\x2', '\x2', '\x2', '\v', '\f', '\x3', '\x2', '\x2', '\x2', '\f', 
		'\x3', '\x3', '\x2', '\x2', '\x2', '\r', '\xE', '\a', '\x4', '\x2', '\x2', 
		'\xE', 'H', '\a', '\x19', '\x2', '\x2', '\xF', '\x10', '\a', '\x5', '\x2', 
		'\x2', '\x10', 'H', '\a', '\x19', '\x2', '\x2', '\x11', '\x12', '\a', 
		'\x6', '\x2', '\x2', '\x12', 'H', '\a', '\x19', '\x2', '\x2', '\x13', 
		'\x14', '\a', '\a', '\x2', '\x2', '\x14', 'H', '\a', '\x19', '\x2', '\x2', 
		'\x15', '\x16', '\a', '\b', '\x2', '\x2', '\x16', 'H', '\a', '\x19', '\x2', 
		'\x2', '\x17', '\x18', '\a', '\t', '\x2', '\x2', '\x18', 'H', '\a', '\x19', 
		'\x2', '\x2', '\x19', '\x1A', '\a', '\n', '\x2', '\x2', '\x1A', '\x1B', 
		'\x5', '\x6', '\x4', '\x2', '\x1B', '\x1C', '\a', '\x19', '\x2', '\x2', 
		'\x1C', 'H', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1E', '\a', '\v', '\x2', 
		'\x2', '\x1E', '\x1F', '\x5', '\x6', '\x4', '\x2', '\x1F', ' ', '\a', 
		'\x19', '\x2', '\x2', ' ', 'H', '\x3', '\x2', '\x2', '\x2', '!', '\"', 
		'\a', '\f', '\x2', '\x2', '\"', '#', '\x5', '\x6', '\x4', '\x2', '#', 
		'$', '\a', '\x19', '\x2', '\x2', '$', 'H', '\x3', '\x2', '\x2', '\x2', 
		'%', '&', '\a', '\r', '\x2', '\x2', '&', '\'', '\x5', '\x6', '\x4', '\x2', 
		'\'', '(', '\a', '\x19', '\x2', '\x2', '(', 'H', '\x3', '\x2', '\x2', 
		'\x2', ')', '*', '\a', '\xE', '\x2', '\x2', '*', '+', '\x5', '\x6', '\x4', 
		'\x2', '+', ',', '\a', '\x19', '\x2', '\x2', ',', 'H', '\x3', '\x2', '\x2', 
		'\x2', '-', '.', '\a', '\xF', '\x2', '\x2', '.', '/', '\x5', '\x6', '\x4', 
		'\x2', '/', '\x30', '\a', '\x19', '\x2', '\x2', '\x30', 'H', '\x3', '\x2', 
		'\x2', '\x2', '\x31', '\x32', '\a', '\x10', '\x2', '\x2', '\x32', '\x33', 
		'\x5', '\x6', '\x4', '\x2', '\x33', '\x34', '\a', '\x19', '\x2', '\x2', 
		'\x34', 'H', '\x3', '\x2', '\x2', '\x2', '\x35', '\x36', '\a', '\x11', 
		'\x2', '\x2', '\x36', '\x37', '\x5', '\x6', '\x4', '\x2', '\x37', '\x38', 
		'\a', '\x19', '\x2', '\x2', '\x38', 'H', '\x3', '\x2', '\x2', '\x2', '\x39', 
		':', '\a', '\x12', '\x2', '\x2', ':', 'H', '\a', '\x19', '\x2', '\x2', 
		';', '<', '\a', '\x13', '\x2', '\x2', '<', 'H', '\a', '\x19', '\x2', '\x2', 
		'=', '>', '\a', '\x14', '\x2', '\x2', '>', '?', '\x5', '\x6', '\x4', '\x2', 
		'?', '@', '\x5', '\x6', '\x4', '\x2', '@', '\x41', '\a', '\x19', '\x2', 
		'\x2', '\x41', 'H', '\x3', '\x2', '\x2', '\x2', '\x42', '\x43', '\a', 
		'\x15', '\x2', '\x2', '\x43', 'H', '\a', '\x19', '\x2', '\x2', '\x44', 
		'\x45', '\a', '\x16', '\x2', '\x2', '\x45', 'H', '\a', '\x19', '\x2', 
		'\x2', '\x46', 'H', '\a', '\x19', '\x2', '\x2', 'G', '\r', '\x3', '\x2', 
		'\x2', '\x2', 'G', '\xF', '\x3', '\x2', '\x2', '\x2', 'G', '\x11', '\x3', 
		'\x2', '\x2', '\x2', 'G', '\x13', '\x3', '\x2', '\x2', '\x2', 'G', '\x15', 
		'\x3', '\x2', '\x2', '\x2', 'G', '\x17', '\x3', '\x2', '\x2', '\x2', 'G', 
		'\x19', '\x3', '\x2', '\x2', '\x2', 'G', '\x1D', '\x3', '\x2', '\x2', 
		'\x2', 'G', '!', '\x3', '\x2', '\x2', '\x2', 'G', '%', '\x3', '\x2', '\x2', 
		'\x2', 'G', ')', '\x3', '\x2', '\x2', '\x2', 'G', '-', '\x3', '\x2', '\x2', 
		'\x2', 'G', '\x31', '\x3', '\x2', '\x2', '\x2', 'G', '\x35', '\x3', '\x2', 
		'\x2', '\x2', 'G', '\x39', '\x3', '\x2', '\x2', '\x2', 'G', ';', '\x3', 
		'\x2', '\x2', '\x2', 'G', '=', '\x3', '\x2', '\x2', '\x2', 'G', '\x42', 
		'\x3', '\x2', '\x2', '\x2', 'G', '\x44', '\x3', '\x2', '\x2', '\x2', 'G', 
		'\x46', '\x3', '\x2', '\x2', '\x2', 'H', '\x5', '\x3', '\x2', '\x2', '\x2', 
		'I', 'L', '\a', '\x18', '\x2', '\x2', 'J', 'L', '\a', '\x17', '\x2', '\x2', 
		'K', 'I', '\x3', '\x2', '\x2', '\x2', 'K', 'J', '\x3', '\x2', '\x2', '\x2', 
		'L', '\a', '\x3', '\x2', '\x2', '\x2', '\x5', '\v', 'G', 'K',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
