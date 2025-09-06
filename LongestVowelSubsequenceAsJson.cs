using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CaseSolutions
{
	public class LongestVowelSubsequenceAsJson
	{
		public static string LongestVowelSubsequenceSolveAsJson(List<string> words)
		{
			HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
			var result = new List<Dictionary<string, object>>();

			foreach (var word in words)
			{
				string maxSeq = "";
				string currentSeq = "";

				foreach (char c in word)
				{
					if (vowels.Contains(c))
					{
						currentSeq += c;
						if (currentSeq.Length > maxSeq.Length)
							maxSeq = currentSeq;
					}
					else
					{
						currentSeq = "";
					}
				}

				result.Add(new Dictionary<string, object>
			{
				{ "word", word },
				{ "sequence", maxSeq },
				{ "length", maxSeq.Length }
			});
			}

			return JsonSerializer.Serialize(result);
		}
	}
}