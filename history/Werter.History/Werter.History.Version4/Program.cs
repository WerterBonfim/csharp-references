using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Werter.History.Version4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            dynamic bag = new Bag();

            bag.Name = "Werter";
            bag.Age = 32;

            bag.CalcDoubleAge = new Func<int>((() => bag.Age * 2));

            Console.WriteLine(bag.CalcDoubleAge());

        }
    }

    public class Bag : DynamicObject
    {
        private Dictionary<string, object> members = new Dictionary<string, object>();

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return members.Keys;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            return members.TryGetValue(binder.Name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            members[binder.Name] = value;
            return true;
        }
    }
}