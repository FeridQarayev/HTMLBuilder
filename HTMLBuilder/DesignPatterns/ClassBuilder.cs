namespace DesignPatternBuilder.DesignPatterns
{
    public class ClassBuilder
    {
        public class Class
        {
            public string ClassName;
            public List<ClassField> classFields = new List<ClassField>();
        }
        public class ClassField
        {
            public string Type, Name;
        }
        public class CodeBuilder
        {
            private Class classs = new Class();
            public CodeBuilder(string className)
            {
                classs.ClassName = className;
            }
            public CodeBuilder AddField(string fieldName, string fieldType)
            {
                classs.classFields.Add(new ClassField() { Type = fieldType, Name = fieldName });
                return this;
            }
            public override string ToString()
            {
                string clas = $"public class {classs.ClassName}\n";
                string fields = "";
                foreach (var item in classs.classFields)
                {
                    fields += $"  public {item.Type} {item.Name};\n";
                }
                return clas + "{" + "\n" + fields + "}";
            }
        }
    }
}
