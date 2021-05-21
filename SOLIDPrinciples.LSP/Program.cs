using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples.LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            Apple apple = new Orange();
            Console.WriteLine(apple.GetColor());
        }
        #region Definition 
        /* The Liskov Substitution Principle is a Substitutability principle in object-oriented programming Language. 
         * This principle states that, if S is a subtype of T, then objects of type T should be replaced with the objects of type S. 
         * In other words, we can say that objects in an application should be replaceable with the instances of their subtypes without modifying the correctness of that application. 
         */
        #endregion
        #region Bad Code
        /* In the following example, first, we create the Apple class with the method GetColor. 
         * Then we create the Orange class which inherits the Apple class as well as overrides the GetColor method of the Apple class. 
         * The point is that an Orange cannot be replaced by an Apple, which results in printing the color of the apple as Orange as shown in the below example.
         */
        public class Apple
        {
            public virtual string GetColor()
            {
                return "Red";
            }
        }
        public class Orange : Apple
        {
            public override string GetColor()
            {
                return "Orange";
            }
        }
        #endregion
        #region Good Code
        static void MainGoodCode(string[] args)
        {
            Fruit fruit = new OrangeGoodCode();
            Console.WriteLine(fruit.GetColor());
            fruit = new AppleGoodCode();
            Console.WriteLine(fruit.GetColor());
        }
        public abstract class Fruit
        {
            public abstract string GetColor();
        }
        public class AppleGoodCode : Fruit
        {
            public override string GetColor()
            {
                return "Red";
            }
        }
        public class OrangeGoodCode : Fruit
        {
            public override string GetColor()
            {
                return "Orange";
            }
        }
        #endregion
    }
}
