using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CaseSolutions
{
	public class FilterEmployees
	{
		public static string FilterEmployeesSolve(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
		{
			var filtered = employees
				.Where(e => e.Age >= 25 && e.Age <= 40)
				.Where(e => e.Department == "IT" || e.Department == "Finance")
				.Where(e => e.Salary >= 5000m && e.Salary <= 9000m)
				.Where(e => e.HireDate.Year > 2017)
				.ToList();

			var sortedNames = filtered
				.OrderByDescending(e => e.Name.Length)
				.ThenBy(e => e.Name)
				.Select(e => e.Name)
				.ToList();

			var result = new
			{
				Names = sortedNames,
				TotalSalary = filtered.Sum(e => e.Salary),
				AverageSalary = filtered.Any() ? Math.Round(filtered.Average(e => e.Salary), 2) : 0,
				MinSalary = filtered.Any() ? filtered.Min(e => e.Salary) : 0,
				MaxSalary = filtered.Any() ? filtered.Max(e => e.Salary) : 0,
				Count = filtered.Count
			};

			return JsonSerializer.Serialize(result);
		}
	}
}