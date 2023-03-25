using System.Text.RegularExpressions;

namespace Examples
{
    internal class Program
    {
        private static void A(IList<IList<double>> a)
        {

        }

        static void Main(string[] args)
        {
            IList<IList<double>> l1 = new List<IList<double>>();
            ICollection<IList<double>> l2 = new List<IList<double>>();
            var objs = new object[]{
    new List<List<double>>(),
    l1,
    l2,
    (IList<List<double>>)(new List<List<double>>()),
    new List<IList<double>>(),
    new List<double[]>(),
    (IList<double[]>)(new List<double[]>()),
    new List<double>[0],
    (IList<double>[])(new List<double>[0]),
    new double[0][],
    (ICollection<double[]>)(new List<double[]>())
};
            var result = new Dictionary<string, ISet<string>>();
            var uniqueObjs = new HashSet<string>();

            A.Invoke()

            foreach (var o in objs)
            {
                var fullName = ConvertToName(o);
                uniqueObjs.Add(fullName);
                if (o is IReadOnlyList<IList<double>> list1)
                {
                    AddToResult(result, fullName, "IReadOnlyList<IList<double>>");
                    if (list1.Any())
                    {
                        var a = list1[0];
                    }
                }
                if (o is IList<IList<double>> list2)
                {
                    AddToResult(result, fullName, "IList<IList<double>>");
                    if (list2.Any())
                    {
                        var a = list2[0];
                    }
                }
                if (o is ICollection<IList<double>> list3)
                {
                    AddToResult(result, fullName, "ICollection<IList<double>>");
                    if (list3.Any())
                    {
                        // Cannot apply indexing with [] to an expression of type 'ICollection<IList<T>>'
                        // var a = list2[0];
                    }
                }
                if (o is IReadOnlyList<ICollection<double>> list4)
                {
                    AddToResult(result, fullName, "IReadOnlyList<ICollection<double>>");
                    if (list4.Any())
                    {
                        var a = list4[0];
                    }
                }
            }

            foreach (var r in result)
            {
                Console.WriteLine(r.Key + " (" + r.Value.Count + "/" + uniqueObjs.Count + ")");
                Console.WriteLine(string.Join(", ", r.Value.OrderBy(e => e)));
                Console.WriteLine();
            }
        }

        public static string ConvertToName(object o)
        {
            var fullName = o.GetType().FullName;
            fullName = fullName.Replace("System.Collections.Generic.", "").Replace("System.Double, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", "Double").Replace(", System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", "").Replace("System.Double", "Double");
            var reg = new Regex(@"`1\[\[([\w<>\[\]]+)\]\]");
            fullName = reg.Replace(fullName, "<$1>");
            fullName = reg.Replace(fullName, "<$1>");
            return fullName;
        }

        public static void Print(string fullName, string type)
        {
            Console.WriteLine(fullName + " can be cast to " + type);
        }

        public static void AddToResult(Dictionary<string, ISet<string>> result, string fullName, string type)
        {
            if (result.TryGetValue(type, out var v))
            {
                v.Add(fullName);
            }
            else
            {
                result[type] = new HashSet<string>() { fullName };
            }
        }
    }
}