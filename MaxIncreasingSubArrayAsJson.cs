using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CaseSolutions
{
	public class MaxIncreasingSubarrayAsJson
	{
		public static string MaxIncreaseSubarraySolveAsJson(List<int> numbers)
		{
			if (numbers == null || numbers.Count == 0)
				return "[]";

			List<int> maxList = new List<int>();
			List<int> tempList = new List<int>();

			for (int i = 0; i < numbers.Count; i++)
			{
				if (i == 0 || numbers[i] > numbers[i - 1])
				{
					tempList.Add(numbers[i]);
				}
				else
				{

					if (tempList.Sum() > maxList.Sum())
						maxList = new List<int>(tempList);
					tempList = new List<int> { numbers[i] };
				}
			}
			if (tempList.Sum() > maxList.Sum())
				maxList = new List<int>(tempList);

			return JsonSerializer.Serialize(maxList);
		}
	}
}