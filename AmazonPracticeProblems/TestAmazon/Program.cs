using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAmazon
{
    class Program
    {
        static void Main(string[] args)
        {
			String helpText = "Jack and Jill went to the market to buy bread and cheese. Cheese is Jack's and Jill's favorite food.";

			List<String> wordsToExclude = new List<string>();

			wordsToExclude.Add("and");
			wordsToExclude.Add("he");
			wordsToExclude.Add("the");
			wordsToExclude.Add("to");
			wordsToExclude.Add("is");

			List<String> mostSearchedWords = retrieveMostFrequentlyUsedWords(helpText, wordsToExclude);

		}

		public static List<String> retrieveMostFrequentlyUsedWords(String helpText,
												   List<String> wordsToExclude)
		{
			// WRITE YOUR CODE HERE

			//Split the helpText string into words
			string[] wordsInHelpText = helpText.Split(' ', '\'', '.');

			int numberOfWordsInHelpText = wordsInHelpText.Length;

			int maxInstancesOfWordFound = 0;
			List<string> maxInstanceWord = new List<string>();

			for (int i = 0; i < numberOfWordsInHelpText; i++)
			{

				if (wordsToExclude.Contains(wordsInHelpText[i])) continue;

				string wordToSearch = wordsInHelpText[i];
				int numberOfTimesWordToSearchPresent = 0;

				for (int j = 0; j < numberOfWordsInHelpText; j++)
				{
					if (wordsInHelpText[j].ToLower() == wordToSearch.ToLower())
					{
						numberOfTimesWordToSearchPresent++;
					}
				}

				if (numberOfTimesWordToSearchPresent >= maxInstancesOfWordFound)
				{
					maxInstancesOfWordFound = numberOfTimesWordToSearchPresent;

					if (!maxInstanceWord.Contains(wordToSearch.ToLower()))
						maxInstanceWord.Add(wordToSearch.ToLower());
				}

			}

			return maxInstanceWord;
		}
	}
}
