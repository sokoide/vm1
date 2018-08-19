using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.IO;
using vm1_lib.Grammar;

namespace vm1_lib
{
    public class AsmCompiler
    {
        public void Run(AntlrInputStream inputStream, Stream w)
        {
            var lexer = new AsmLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new AsmParser(commonTokenStream);
            var context = parser.prog();

            ParseTreeWalker walker = new ParseTreeWalker();
            AsmListener listener = new AsmListener(parser, w);
            walker.Walk(listener, context);
        }
    }
}
