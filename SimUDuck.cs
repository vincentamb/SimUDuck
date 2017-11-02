using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public abstract class Duck
    {
        protected IFlyBehavior flyBehavior;
        protected IQuackBehavior quackBehavior;
        public IQuackBehavior quackBehavior
        {
            get
            {
                return quackBehavior;
            }
            set
            {
                quackBehavior = value;
            }
        }
        public IFlyBehavior flyBehavior
        {
            get
            {
                return flyBehavior;
            }
            set
            {
                flyBehavior = value;
            }
        }
        public abstract object Display();
        public object PerformFly()
        {
            return FlyBehavior.Fly();
        }
        public object PerformQuack()
        {
            return quackBehavior.Quacking();
        }
        public string Swim()
        {
            return " All Ducks float, even toys...";
        }
    }
    public interface IFlyBehavior
    {
        object Fly();
    }
    public class FlyNoWay : IFlyBehavior
    {
        public object Fly()
        {
            return "I can't fly";
        }
    }
    public class FlyRocketPowered : IFlyBehavior
    {
        public object Fly()
        {
            return "I'm flying like a Rocket";
        }
    }
    public class FlyWithWings : IFlyBehavior
    {
        public object Fly()
        {
            return "I'm flying";
        }
    }
    public interface IQuackBehavior
    {
        object Quacking();
    }
    class MuteQuack : IQuackBehavior
    {
        public object Quacking()
        {
            return "<<silence>>";
        }
    }
    public class Quack : IQuackBehavior
    {
        public object Quacking()
        {
            return "Quack";
        }
    }
    public class Squeak : IQuackBehavior
    {
        public object Quacking()
        {
            return "Squeak";
        }
    }
    public class MallardDuck: Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();
        }
        public override object Display()
        {
            return "I'm a real Mallard Duck";
        }
    }
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Quack();
        }
        public override object Display()
        {
            return "I'm a Model Duck";
        }
    }
    public class DuckTest
    {
        public void TestMallardDuck()
        {
            var mallard = new MallardDuck();
            Assert.AreEqual("Quack", mallard.PerformQuack());
            Assert.AreEqual("I'm Flying", mallard.PerformFly());
        }
        public void TestModelDuck()
        {
            var modelDuck = new ModelDuck();
            Assert.AreEqual("Quack", modelDuck.PerformQuack());
            Assert.AreEqual("I'm Flying", modelDuck.PerformFly());
            modelDuck.FlyBehavior = new FlyWithWings();
            Assert.AreEqual("I'm Flying", modelDuck.PerformFly());

        }
    }
}
