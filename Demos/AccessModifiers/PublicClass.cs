namespace AccessModifiersPractice
{
    public class PublicClass
    {//everything is a member

        //this is a property
        public readonly int MyInt = 1;

        //this is a field
        public int myOtherInt = 2;


        public void PublicMethod()
        {
            System.Console.WriteLine("this is parent PublicMethod()");
        }

        //this method overload
        public void PublicMethod(int x)
        {
            System.Console.WriteLine($"This is publicMethod() Overloaded with {x}");
        }

        private void PrivateMethod()
        {
            System.Console.WriteLine("this is parent PrivateMethod()");
        }

        virtual internal void InternalMethod()
        {
            System.Console.WriteLine("this is parent InternalMethod()");
        }

        protected void ProtectedeMethod()
        {
            System.Console.WriteLine("this is parent ProtectedeMethod()");
        }

        protected internal void ProtectedInternalMethod()
        {
            System.Console.WriteLine("this is parent ProtectedInternalMethod()");
        }

        private protected void PrivateProtectedMethod()
        {
            System.Console.WriteLine("this is parent PrivateProtectedMethod()");
        }
    }
}