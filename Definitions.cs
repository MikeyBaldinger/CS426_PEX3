using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS426
{
    public abstract class Definition
    {
        public string name;     // associated with variable name, type name, or function name
    }
    public abstract class TypeDefinition : Definition
    {
    }
    public class BasicTypeDefinition : TypeDefinition
    {
    }
    public class StringTypeDefinition : TypeDefinition
    {
    }
    public class VariableDefinition : Definition
    {
        public TypeDefinition vartype;
    }
    public class MethodDefinition : Definition
    {
        public List<VariableDefinition> paramList;

    }
}