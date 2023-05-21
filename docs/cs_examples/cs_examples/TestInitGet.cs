using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_examples
{
    public class TestInit
    {
        public int Value { get; init; }
    }

    public record TestRecordInit
    {
        public int Value { get; init; }
    }

    public class TestGetOnly
    {
        public int Value { get; }
    }

    public class TestReadOnly
    {
        // cannot add '{get;}' to readonly
        public readonly int Value;
    }

    public record BaseClass
    {
        public string Base { get; init; }
    }

    public record DerivedClass : BaseClass
    {
        public string Derived { get; init; }
    }

    public class TestInitGet
    {
        public static void Start()
        {
            var o1 = new TestInit() { Value = 1 };
            var o2 = new TestRecordInit() { Value = 1 };
            var o3 = o2 with { Value = 2 }; // o2 must be record or struct type

            // not allowed
            // var o4 = new TestGetOnly() { Value = 1 };

            // not allowed
            // var o4 = new TestReadOnly() { Value = 1 };}
        }
    }
}
