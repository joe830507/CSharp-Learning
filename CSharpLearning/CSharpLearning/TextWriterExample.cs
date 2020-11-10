namespace CSharpLearning
{
    public class TextWriterExample : IDemonstrate
    {
        public void Demonstrate()
        {
            using (TextWriter tw = new TextWriter())
            {
                tw.WriteText("I'm happy to code.");
            }
        }
    }
}
