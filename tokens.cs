/* This file was generated by SableCC (http://www.sablecc.org/). */

using System;
using System.Collections;
using System.Text;

using  CS426.analysis;

namespace CS426.node {


public sealed class TAssign : Token
{
    public TAssign(string text)
    {
        Text = text;
    }

    public TAssign(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TAssign(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTAssign(this);
    }
}

public sealed class TPlus : Token
{
    public TPlus(string text)
    {
        Text = text;
    }

    public TPlus(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TPlus(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTPlus(this);
    }
}

public sealed class TMinus : Token
{
    public TMinus(string text)
    {
        Text = text;
    }

    public TMinus(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMinus(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMinus(this);
    }
}

public sealed class TMult : Token
{
    public TMult(string text)
    {
        Text = text;
    }

    public TMult(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMult(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMult(this);
    }
}

public sealed class TDiv : Token
{
    public TDiv(string text)
    {
        Text = text;
    }

    public TDiv(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TDiv(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTDiv(this);
    }
}

public sealed class TAnd : Token
{
    public TAnd(string text)
    {
        Text = text;
    }

    public TAnd(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TAnd(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTAnd(this);
    }
}

public sealed class TOr : Token
{
    public TOr(string text)
    {
        Text = text;
    }

    public TOr(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TOr(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTOr(this);
    }
}

public sealed class TNot : Token
{
    public TNot(string text)
    {
        Text = text;
    }

    public TNot(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TNot(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTNot(this);
    }
}

public sealed class TEqual : Token
{
    public TEqual(string text)
    {
        Text = text;
    }

    public TEqual(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TEqual(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTEqual(this);
    }
}

public sealed class TGreateq : Token
{
    public TGreateq(string text)
    {
        Text = text;
    }

    public TGreateq(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TGreateq(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTGreateq(this);
    }
}

public sealed class TLesseq : Token
{
    public TLesseq(string text)
    {
        Text = text;
    }

    public TLesseq(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLesseq(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLesseq(this);
    }
}

public sealed class TGreater : Token
{
    public TGreater(string text)
    {
        Text = text;
    }

    public TGreater(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TGreater(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTGreater(this);
    }
}

public sealed class TLess : Token
{
    public TLess(string text)
    {
        Text = text;
    }

    public TLess(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLess(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLess(this);
    }
}

public sealed class TEol : Token
{
    public TEol(string text)
    {
        Text = text;
    }

    public TEol(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TEol(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTEol(this);
    }
}

public sealed class TOpenpar : Token
{
    public TOpenpar(string text)
    {
        Text = text;
    }

    public TOpenpar(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TOpenpar(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTOpenpar(this);
    }
}

public sealed class TClosepar : Token
{
    public TClosepar(string text)
    {
        Text = text;
    }

    public TClosepar(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TClosepar(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTClosepar(this);
    }
}

public sealed class TOpenbrace : Token
{
    public TOpenbrace(string text)
    {
        Text = text;
    }

    public TOpenbrace(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TOpenbrace(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTOpenbrace(this);
    }
}

public sealed class TClosebrace : Token
{
    public TClosebrace(string text)
    {
        Text = text;
    }

    public TClosebrace(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TClosebrace(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTClosebrace(this);
    }
}

public sealed class TComma : Token
{
    public TComma(string text)
    {
        Text = text;
    }

    public TComma(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TComma(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTComma(this);
    }
}

public sealed class TFunc : Token
{
    public TFunc(string text)
    {
        Text = text;
    }

    public TFunc(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TFunc(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTFunc(this);
    }
}

public sealed class TWhile : Token
{
    public TWhile(string text)
    {
        Text = text;
    }

    public TWhile(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TWhile(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTWhile(this);
    }
}

public sealed class TIf : Token
{
    public TIf(string text)
    {
        Text = text;
    }

    public TIf(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TIf(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTIf(this);
    }
}

public sealed class TElse : Token
{
    public TElse(string text)
    {
        Text = text;
    }

    public TElse(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TElse(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTElse(this);
    }
}

public sealed class TConst : Token
{
    public TConst(string text)
    {
        Text = text;
    }

    public TConst(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TConst(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTConst(this);
    }
}

public sealed class TMain : Token
{
    public TMain(string text)
    {
        Text = text;
    }

    public TMain(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMain(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMain(this);
    }
}

public sealed class TId : Token
{
    public TId(string text)
    {
        Text = text;
    }

    public TId(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TId(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTId(this);
    }
}

public sealed class TComment : Token
{
    public TComment(string text)
    {
        Text = text;
    }

    public TComment(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TComment(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTComment(this);
    }
}

public sealed class TInteger : Token
{
    public TInteger(string text)
    {
        Text = text;
    }

    public TInteger(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TInteger(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTInteger(this);
    }
}

public sealed class TFloating : Token
{
    public TFloating(string text)
    {
        Text = text;
    }

    public TFloating(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TFloating(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTFloating(this);
    }
}

public sealed class TString : Token
{
    public TString(string text)
    {
        Text = text;
    }

    public TString(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TString(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTString(this);
    }
}

public sealed class TBlank : Token
{
    public TBlank(string text)
    {
        Text = text;
    }

    public TBlank(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TBlank(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTBlank(this);
    }
}


public abstract class Token : Node
{
    private string text;
    private int line;
    private int pos;

    public virtual string Text
    {
      get { return text; }
      set { text = value; }
    }

    public int Line
    {
      get { return line; }
      set { line = value; }
    }

    public int Pos
    {
      get { return pos; }
      set { pos = value; }
    }

    public override string ToString()
    {
        return text + " ";
    }

    internal override void RemoveChild(Node child)
    {
    }

    internal override void ReplaceChild(Node oldChild, Node newChild)
    {
    }
}

public sealed class EOF : Token
{
    public EOF()
    {
        Text = "";
    }

    public EOF(int line, int pos)
    {
        Text = "";
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
        return new EOF(Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseEOF(this);
    }
}
}
