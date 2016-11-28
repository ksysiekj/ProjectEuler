using System;
using System.Diagnostics;

namespace Euler.Common
{
    public static class MeasureTool
    {
        public static double MeasureTotalMiliSeconds(Action call)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            call.Invoke();

            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
