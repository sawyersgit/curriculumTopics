using System;

namespace AccessModifiersPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Whats up?!");

            PublicClass pc = new PublicClass();
            pc.ProtectedInternalMethod();
            pc.PublicMethod();
            pc.PublicMethod(3);
            pc.InternalMethod();

            int myint1 = pc.MyInt;
            //pc.MyInt = 2;//cant change a readonly value.

            DerivedClass dc = new DerivedClass();
            dc.InternalMethod();
            dc.ProtectedInternalMethod();
            dc.PublicMethod();

            PublicClass pc1 = new DerivedClass();
            pc1.InternalMethod();

            DerivedClass pc2 = (DerivedClass)pc1;//cast the Public class to an instance of a derived class
            pc2.InternalMethod();

            DerivedClass dc1 = new DerivedClass();
            dc1.ProtectedInternalMethod();

            dc.CallsProtectedMethod();


        }
    }
}
