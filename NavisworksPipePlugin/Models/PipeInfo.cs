namespace NavisworksPipePlugin.Models
{
    public abstract class PipeInfo
    {
        protected const string sep = ";";

        public string ParentNames;
        public string ElementName;

        public abstract string FieldInfo();
    }
}
