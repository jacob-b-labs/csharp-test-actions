namespace MyLibrary;

/*
  Sum:
  - returns 0 for empty string
  - returns a number if it is an only number
  - returns a sum of numbers if they are separated with a comma
  - ... or a newline
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

        if (int.TryParse(Input, out int result))
            return result;

        throw new NotImplementedException();
    }
}
