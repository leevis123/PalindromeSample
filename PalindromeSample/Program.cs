using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeSample
{
  class Program
  {
    const string InputMessage = "Enter the integer you would like to test: ";
    const string ContinueMessage = "Would you like to test another (y/n)? ";

    static void Main(string[] args)
    {
      bool continueTest = true;
      bool hasValidInput;

      int testValue;
      string userInput;

      // Use an array to track our results. 
      List<int> results = new List<int>();
      results.Add(0);
      results.Add(0);


      // Show InputMessage. 
      Console.Write(InputMessage);

      // Continue testing until we decide to quit. Only accept y or n as a response. 
      while (continueTest)
      {
        hasValidInput = false;
        testValue = 0;
        userInput = string.Empty;

        while (!hasValidInput)
        {
          userInput = Console.ReadLine();

          if (string.IsNullOrWhiteSpace(userInput))
          {
            // No input was entered.
            Console.WriteLine("Sorry, but your input cannot be blank. Let's try again.");
            Console.Write(InputMessage);
          }
          else if (!int.TryParse(userInput, out testValue))
          {
            // Non-numeric value was entered.
            Console.WriteLine("Sorry, numeric values only. Try again, please.");
            Console.Write(InputMessage);
          }
          else if (testValue < 0)
          {
            // A negative number was entered. 
            Console.WriteLine("Sorry, positive numbers only. Try again, please.");
            Console.Write(InputMessage);
          }
          else
          {
            // A valid integer was entered.
            hasValidInput = true;
          }
        }

        // We have a valid integer. Test whether it's a palindrome.
        if (IsPalindrome(testValue.ToString()))
        {
          Console.WriteLine(GetAttaBoyMessage() + string.Format("The integer you entered ({0}) is a palindrome.", testValue.ToString()));
          results[1] += 1;
        }
        else
        {
          Console.WriteLine(string.Format("The integer you entered ({0}) is not a palindrome. =(", testValue.ToString()));
          results[0] += 1;
        }

        // Prompt user whether they want to try continue testing. 
        Console.Write(ContinueMessage);
        hasValidInput = false;

        while (!hasValidInput)
        {
          userInput = Console.ReadLine();

          if (string.IsNullOrWhiteSpace(userInput))
          {
            // No input was entered.
            Console.WriteLine("Sorry, but your input was blank. Let's try again.");
            Console.Write(ContinueMessage);
          }
          else if (userInput.ToLower() != "y" && userInput.ToLower() != "n")
          {
            // Invalid input was entered.
            Console.WriteLine("Sorry, but your input was not valid. Please enter y or n to continue.");
            Console.Write(ContinueMessage);
          }
          else
          {
            // User entered "y" or "n".
            hasValidInput = true;
          }
        }

        if (userInput.ToLower() == "n")
        {
          // User has opted to quit. 
          continueTest = false;
        }
        else
        {
          // Show InputMessage. 
          Console.Write(InputMessage);
        }
      }

      // Show results. 
      int totalTests = results[0] + results[1];
      int totalValid = results[1];
      int totalInvalid = results[0];

      Console.WriteLine(string.Format("Out of {0} tests, {1} were valid palindromes and {2} were not.", totalTests.ToString(), totalValid.ToString(), totalInvalid.ToString()));
      Console.WriteLine("Thanks for playing.");
      Console.ReadKey();
    }

    private static bool IsPalindrome(string valueToTest)
    {
      bool isPalindrome = false;
      string testValue = string.Empty;

      if (valueToTest.ToString().Length > 0)
      {
        // Build an array to store our character values. 
        char[] values = new char[valueToTest.Length];

        for (int currIndex = 0; currIndex < valueToTest.Length; currIndex++)
        {
          values[currIndex] = valueToTest[currIndex];
        }

        // Reverse the values in our array.
        Array.Reverse(values);

        // Convert the values to a string so we can perform our test.
        testValue = string.Join(string.Empty, values);

        if (testValue.ToLower() == valueToTest.ToLower())
        {
          isPalindrome = true;
        }
      }
      return isPalindrome;
    }

    private static string GetAttaBoyMessage()
    {
      List<string> messages = new List<string>();
      Random random = new Random();
      int returnIndex;

      messages.Add("Good job! ");
      messages.Add("Woohoo... Way to go! ");
      messages.Add("Check you out!!!! ");
      messages.Add("Awesome! ");
      messages.Add("Holy cow! ");

      returnIndex = random.Next(0, messages.Count - 1);

      return messages[returnIndex];
    }
  }
}
