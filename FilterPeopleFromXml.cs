using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CaseSolutions
{
	public class FilterPeopleFromXml
	{
		public class PeopleStats
		{
			public List<string> Names { get; set; } = new List<string>();
			public decimal TotalSalary { get; set; }
			public decimal AverageSalary { get; set; }
			public decimal MaxSalary { get; set; }
			public int Count { get; set; }
		}

		public static string FilterPeopleSolveFromXml(string xmlData)
		{
			if (string.IsNullOrEmpty(xmlData))
				return JsonSerializer.Serialize(new PeopleStats());

			var doc = XDocument.Parse(xmlData);
			var filteredPeople = doc.Descendants("Person")
				.Select(p => new
				{
					Name = (string)p.Element("Name"),
					Age = (int)p.Element("Age"),
					Department = (string)p.Element("Department"),
					Salary = decimal.Parse((string)p.Element("Salary")),
					HireDate = DateTime.Parse((string)p.Element("HireDate"))
				})
				.Where(p => p.Age > 30 && p.Department == "IT" && p.Salary > 5000 && p.HireDate.Year < 2019)
				.OrderBy(p => p.Name)
				.ToList();

			if (!filteredPeople.Any())
				return JsonSerializer.Serialize(new PeopleStats());

			var stats = new PeopleStats
			{
				Names = filteredPeople.Select(p => p.Name).ToList(),
				TotalSalary = filteredPeople.Sum(p => p.Salary),
				AverageSalary = filteredPeople.Average(p => p.Salary),
				MaxSalary = filteredPeople.Max(p => p.Salary),
				Count = filteredPeople.Count
			};

			return JsonSerializer.Serialize(stats);
		}	
	}
}