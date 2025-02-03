using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
  internal class Program
  {
    static void Main(string[] args)
    {
      double[] data = { 10, 20, 30, 40, 50, 60 };
      int n = data.Length;

      // 计算均值
      double mean = data.Mean();
      Console.WriteLine($"Mean: {mean}");

      // 计算标准差
      double stdDev = data.StandardDeviation();
      Console.WriteLine($"Standard Deviation: {stdDev}");

      // 计算标准误差
      double standardError = stdDev / Math.Sqrt(n);
      Console.WriteLine($"Standard Error: {standardError}");

      Console.WriteLine("");

      // 置信水平
      double confidence95 = 0.95;
      double confidence99 = 0.99;

      // T 分布的临界值
      double tCritical95 = StudentT.InvCDF(0, 1, n - 1, (1 + confidence95) / 2);
      double tCritical99 = StudentT.InvCDF(0, 1, n - 1, (1 + confidence99) / 2);

      // Z 分布的临界值 - 标准正态分布
      double zCritical95 = Normal.InvCDF(0, 1, (1 + confidence95) / 2);
      double zCritical99 = Normal.InvCDF(0, 1, (1 + confidence99) / 2);

      // 计算 95% 置信区间
      double marginOfError95 = tCritical95 * standardError;

      double lower95 = mean - marginOfError95;
      double upper95 = mean + marginOfError95;

      Console.WriteLine($"t- 95% Confidence MoE: {marginOfError95}");
      Console.WriteLine($"t- 95% Confidence Interval: [{lower95}, {upper95}]");
      Console.WriteLine("");

      // 计算 99% 置信区间
      double marginOfError99 = tCritical99 * standardError;

      double lower99 = mean - marginOfError99;
      double upper99 = mean + marginOfError99;

      Console.WriteLine($"t- 99% Confidence MoE: {marginOfError99}");
      Console.WriteLine($"t- 99% Confidence Interval: [{lower99}, {upper99}]");
      Console.WriteLine("");

      //计算 95% 置信区间的误差边界
      double errorMargin95 = zCritical95 * standardError;

      lower95 = mean - errorMargin95;
      upper95 = mean + errorMargin95;

      Console.WriteLine($"Z- 95% Confidence MoE: {errorMargin95}");
      Console.WriteLine($"Z- 95% Confidence Interval: [{lower95}, {upper95}]");
      Console.WriteLine("");

      //计算 99% 置信区间的误差边界
      double errorMargin99 = zCritical99 * standardError;

      lower99 = mean - marginOfError99;
      upper99 = mean + marginOfError99;
      Console.WriteLine($"Z- 99% Confidence MoE: {errorMargin99}");
      Console.WriteLine($"Z- 99% Confidence Interval: [{lower99}, {upper99}]");
      Console.WriteLine("");

      // 输出结果
      Console.Read();
    }
  }
}
