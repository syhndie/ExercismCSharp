using System;

  public static class TwoFer
  {
          
      public static string Name(string input = null)
      {
        if (String.IsNullOrEmpty(input))  input = "you"; 
        return $"One for {input}, one for me.";

        //this solution came from someone eles on exercism, and impressed me
        //it passes all the tests that came with the original problem
        //return String.Format("One for {0}, one for me.", input ?? "you");
    }
}
