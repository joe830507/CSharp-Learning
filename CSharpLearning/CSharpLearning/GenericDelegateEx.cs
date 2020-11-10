namespace CSharpLearning
{
    public class GenericDelegateEx : IDemonstrate
    {
        // The definition of MyTestDel, return type is R, input types are A1, A2.
        //A1 and A2 need to be primitive type(int,short,long,float,double...)
        public delegate R MyTestDel<in A1, in A2, out R>(A1 m, A2 n)
            where A1 : struct
            where A2 : struct;

        //implementation of MyTestDel function
        //set a is int and b is byte, return value is string.
        MyTestDel<int, byte, string> test = (a, b) =>
          {
              string ret = $"type = {a.GetType().Name}, value = {a}\ntype = {b.GetType().Name}, value = {b}";
              return ret;
          };
        public void Demonstrate()
        {
            System.Console.WriteLine(test(350, 27));
        }
    }
}
