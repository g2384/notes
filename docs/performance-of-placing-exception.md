# Performance Analysis of Exception Handling in Different Function Calls

## Analysis

-	Throwing exception in the first method call has the lowest mean execution time (BenchmarkMethodWithException, 4.759 us).
-	Throwing exception in inner methods has the highest mean execution time (BenchmarkMethodCallingAnotherWithException2, 6.432 us).
-	Inlining optimization has a low mean execution time (BenchmarkMethodInlining, 4.804 us) because it reduces the overhead of method calls.

## Code to reproduce

```cs
    /*
BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4890/23H2/2023Update/SunValley3)
11th Gen Intel Core i7-11850H 2.50GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

| Method                                      | Mean     | Error     | StdDev    |
|-------------------------------------------- |---------:|----------:|----------:|
| BenchmarkMethodWithException                | 4.759 us | 0.0851 us | 0.0754 us |
| BenchmarkMethodCallingAnotherWithException  | 5.607 us | 0.0627 us | 0.0586 us |
| BenchmarkMethodCallingAnotherWithException2 | 6.432 us | 0.1272 us | 0.1249 us |
| BenchmarkMethodInlining                     | 4.804 us | 0.0947 us | 0.0930 us |
     */
    public class ExceptionBenchmark
    {
        private static readonly double[] values = new double[] { 0, 1, 2, 3 };

        [Benchmark]
        public void BenchmarkMethodWithException()
        {
            try
            {
                // exception is thrown in the first method call
                ExecuteTestException1(values);
            }
            catch (Exception)
            {
                // Handle exception
            }
        }

        [Benchmark]
        public void BenchmarkMethodCallingAnotherWithException()
        {
            try
            {
                // exception is thrown in the second method call
                ExecuteTestException2(values);
            }
            catch (Exception)
            {
                // Handle exception
            }
        }

        [Benchmark]
        public void BenchmarkMethodCallingAnotherWithException2()
        {
            try
            {
                // exception is thrown in the third method call
                ExecuteTestException3(values);
            }
            catch (Exception)
            {
                // Handle exception
            }
        }

        [Benchmark]
        public void BenchmarkMethodInlining()
        {
            try
            {
                // exception is thrown in the third method call, but with inlining optimization
                ExecuteTestException4(values);
            }
            catch (Exception)
            {
                // Handle exception
            }
        }

        #region TestException1

        private void MultiplyValues(double[] array)
        {
            array[0] = array[0] * array[1];
        }

        private void MultiplyAndCallMethod(double[] array)
        {
            MultiplyValues(array);
            array[0] = array[0] * array[1];
        }

        private void ExecuteTestException1(double[] array)
        {
            MultiplyAndCallMethod(array);
            foreach (var value in array)
            {
                if (value == 2)
                    throw new InvalidOperationException("This is a test exception.");
            }
            array[0] = array[0] * array[1];
            array[0] = array[0] * array[1];
            array[0] = array[0] + array[1] + array[2];
        }

        #endregion TestException1

        #region TestException2

        private void MultiplyValuesAgain(double[] array)
        {
            array[0] = array[0] * array[1];
        }

        private void MultiplyAndCheckException(double[] array)
        {
            MultiplyValuesAgain(array);
            array[0] = array[0] * array[1];
            foreach (var value in array)
            {
                if (value == 2)
                    throw new InvalidOperationException("This is a test exception.");
            }
            array[0] = array[0] * array[1];
        }

        private void ExecuteTestException2(double[] array)
        {
            MultiplyAndCheckException(array);
            array[0] = array[0] * array[1];
            array[0] = array[0] + array[1] + array[2];
        }

        #endregion TestException2

        #region TestException3

        private void MultiplyValuesAndCheck(double[] array)
        {
            array[0] = array[0] * array[1];
            array[0] = array[0] * array[1];
            foreach (var value in array)
            {
                if (value == 2)
                    throw new InvalidOperationException("This is a test exception.");
            }
        }

        private void MultiplyAndCallMethodAgain(double[] array)
        {
            MultiplyValuesAndCheck(array);
            array[0] = array[0] * array[1];
        }

        private void ExecuteTestException3(double[] array)
        {
            MultiplyAndCallMethodAgain(array);
            array[0] = array[0] * array[1];
            array[0] = array[0] + array[1] + array[2];
        }

        #endregion TestException3

        #region TestException4

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InlineMultiplyValuesAndCheck(double[] array)
        {
            array[0] = array[0] * array[1];
            array[0] = array[0] * array[1];
            foreach (var value in array)
            {
                if (value == 2)
                    throw new InvalidOperationException("This is a test exception.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InlineMultiplyAndCallMethod(double[] array)
        {
            InlineMultiplyValuesAndCheck(array);
            array[0] = array[0] * array[1];
        }

        private void ExecuteTestException4(double[] array)
        {
            InlineMultiplyAndCallMethod(array);
            array[0] = array[0] + array[1] + array[2];
        }

        #endregion TestException4
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ExceptionBenchmark>();
        }
    }
```
