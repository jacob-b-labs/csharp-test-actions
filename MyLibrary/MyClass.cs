namespace MyLibrary;

/*
  Sum:
  - returns 0 for empty string
  - returns a number if it is an only number
  - returns a sum of numbers if they are separated with a comma
  - ... or a newline
  - ... or mixed
  - ignores numbers larger than 1000
  - throws ArgumentNullException if loaded number is negative
  - allows /X/ on the start, then X (char) can be a separator alongside comma and newline
  - allows /[XYZ]/ on the start - same as above, but XYZ is a string
*/

public class MyClass
{
    public static int Sum(string Input)
    {
        if (Input == string.Empty)
            return 0;

        var delimiters = new List<string>(new[] { ",", "\n" });
        // if (Input.StartsWith("/["))
        // {
        //     var parsed = Input.Split(new[] { "/[", "]/" }, StringSplitOptions.None);
        // } 
        if (Input.StartsWith("/"))
        {
            delimiters.Add(Input.Substring(1, 1));
        }
        var numbers = Input.Replace("/", String.Empty).Split(delimiters.ToArray(), StringSplitOptions.None);
        int result = 0;
        foreach (var num in numbers)
            if (int.TryParse(num, out int val))
            {
                if (val < 0)
                    throw new ArgumentException();
                result += (val <= 1000 ? val : 0);
            }
        return result;

        throw new NotImplementedException();
    }
}
