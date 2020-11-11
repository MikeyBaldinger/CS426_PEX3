/* This file was generated by SableCC (http://www.sablecc.org/). */

using System;
using System.Collections;
using System.Text;
using System.IO;
using CS426.parser;
using CS426.analysis;
using CS426.lexer;
using CS426.node;
using System.Linq.Expressions;

class TextPrinter : ReversedDepthFirstAdapter {
  enum codes {
    ESC = 27
  };

  enum style {
    NORMAL = 0,
    BOLD = 1,
    UNDERSCORE = 4,
    BLINK = 5,
    CONCEALED = 8
  };

  enum fg_color {
    FG_BLACK = 30,
    FG_RED = 31,
    FG_GREEN = 32,
    FG_YELLOW = 33,
    FG_BLUE = 34,
    FG_MAGENTA = 35,
    FG_CYAN = 36,
    FG_WHITE = 37
  };

  enum bg_color {
    BG_BLACK = 40,
    BG_RED = 41,
    BG_GREEN = 42,
    BG_YELLOW = 43,
    BG_BLUE = 44,
    BG_MAGENTA = 45,
    BG_CYAN = 46,
    BG_WHITE = 47
  };

  public TextPrinter ()
  {
  }

  public override void OutStart (Start node)
  {
    Console.Write (TreeColor() + "\n" + output.Substring(3) + "\n" + ResetColor());
  }

  public override void DefaultIn (Node node)
  {
    if ( last )
        indentchar.Push('`');
    else
        indentchar.Push('|');

    indent = indent + "   ";
    last = true;
  }

  public override void DefaultOut (Node node)
  {
    indent = indent.Substring(0, indent.Length - 3);
    indent = indent.Substring(0, indent.Length - 1) + indentchar.Peek();
    indentchar.Pop();
    output = indent + "- " + SetColor (style.NORMAL, fg_color.FG_GREEN,
        bg_color.BG_BLACK) + node.GetType().Name + TreeColor() + "\n" + output;
    indent = indent.Substring(0, indent.Length - 1) + "|";
  }

  public override void DefaultCase (Node node)
  {
    if ( last ) indent = indent.Substring(0, indent.Length - 1) + "`";

    output = indent + "- " + SetColor(style.NORMAL, fg_color.FG_RED, bg_color.BG_BLACK) +
        ((Token)node).Text + TreeColor() + "\n" + output;

    indent = indent.Substring(0, indent.Length - 1) + "|";

    last = false;
  }

  string SetColor (style style, fg_color fgColor, bg_color bgColor)
  {
    if ( color )
        return (char)codes.ESC + "[" + (int)style + ";" + (int)fgColor + "m";

    return "";
  }

  public override void CaseEOF (EOF node)
  {
    last = false;
  }

  string ResetColor ()
  {
    if ( color )
        return (char)codes.ESC + "[0m";
    else
        return "";
  }

  string TreeColor ()
  {
    return SetColor (style.NORMAL, fg_color.FG_BLACK, bg_color.BG_BLACK);
  }

  public void SetColor (bool b)
  {
    color = b;
  }

  string indent, output;
  Stack indentchar = new Stack();
  bool last = false;
  bool color = false;
}

class TestParser
{
    public static void Main(String[] args)
    {
        Lexer l = new Lexer(new StreamReader(args[0]));
        Parser p = new Parser(l);

        Start s = p.Parse();

        TextPrinter printer = new TextPrinter();
        if (args.Length > 0 && args[0] == "-ansi")
            printer.SetColor(true);

        s.Apply(printer);

        SemanticAnalyzer sa = new SemanticAnalyzer();
        s.Apply(sa);
        //Console.WriteLine("Press anykey to close...");
        //Console.ReadKey();
    }
}
