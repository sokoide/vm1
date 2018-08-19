// Please generate listener by
//
// Linux: alias antlr4=java -jar /path/to/antlr-4.7.1-complete.jar $*)
// Win: antlr4.bat contains 'java -jar c:\tools\antlr-4.7.1-complete.jar %*'
// Then run,
// antlr4 Asm.g4 -o generated

grammar Asm;

options {
	language = CSharp;
}

// Parser Rules
prog: stmt+;

stmt: NOP NEWLINE					# nopStmt
	| IADD NEWLINE					# iaddStmt
	| ISUB NEWLINE					# isubStmt
	| IMUL NEWLINE					# imulStmt
	| ILT NEWLINE					# iltStmt
	| IEQ NEWLINE					# ieqStmt
	| BR expr NEWLINE				# brStmt
	| BRT expr NEWLINE				# brtStmt
	| BRF expr NEWLINE				# brfStmt
	| ICONST expr NEWLINE			# iconstStmt
	| LOAD expr NEWLINE				# loadStmt
	| GLOAD expr NEWLINE			# gloadStmt
	| STORE expr NEWLINE			# storeStmt
	| GSTORE expr NEWLINE			# gstoreStmt
	| PRINT NEWLINE					# printStmt
	| POP NEWLINE					# popStmt
	| CALL expr expr NEWLINE		# callStmt
	| RET NEWLINE					# retStmt
	| HALT NEWLINE					# haltStmt
	| NEWLINE						# blankStmt
	;

expr: INT							# intExpr
	| ID							# idExpr
	;


// Lexer Rules
COMMENT :  '//' ~( '\r' | '\n' )* -> skip;

NOP: 'nop';
IADD: 'iadd';
ISUB: 'isub';
IMUL: 'mul';
ILT: 'ilt';
IEQ: 'ieq';
BR: 'br';
BRT: 'brt';
BRF: 'brf';
ICONST: 'iconst';
LOAD: 'load';
GLOAD: 'gload';
STORE: 'store';
GSTORE: 'gstore';
PRINT: 'print';
POP: 'pop';
CALL: 'call';
RET: 'ret';
HALT: 'halt';

ID: [a-zA-Z]+;
INT: [0-9]+;
NEWLINE : [\r\n]+;

WS: [ \t]+ -> skip;
