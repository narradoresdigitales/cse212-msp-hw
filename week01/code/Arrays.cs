using System.Reflection.Metadata.Ecma335;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // ** // 

        // Create an array to hold the multiples
        double[] results = new double[length];

        // Build the array with multiples
        for (int i = 0; i < length; i++)
        {
            results[i] = number * (i + 1);
        }

        return results; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // ** PLAN/PROCESS 
        // 1) Restate the goal: 
        //    - Move every element to the right by 'amount' positions; elements that fall off the end wrap to the   front.
        //
        // 2) Inputs / outputs:
        //    - Input: List<int> data (mutated in-place), int amount (1..data.Count inclusive per spec).
        //    - Output: same list instance, rotated.
        //
        // 3) Edge cases / guards:
        //    - If data == null -> throw ArgumentNullException (fail early).
        //    - If data.Count <= 1 -> nothing to do (return).
        //    - If amount is 0 or a multiple of data.Count -> nothing to do.
        //    - If amount > data.Count -> normalize using modulo.
        //
        // 4) Strategy:
        //    A) Simple slice + rebuild:
        //         partA = data.GetRange(n - k, k)
        //         partB = data.GetRange(0, n - k)
        //         data.Clear(); data.AddRange(partA); data.AddRange(partB);
        //       - Simple and easy to read; creates two new lists 
        //
        //    B) Slice tail + remove + insert (chosen here):
        //         tail = data.GetRange(n - k, k)      
        //         data.RemoveRange(n - k, k)         // remove tail from end
        //         data.InsertRange(0, tail)          // insert tail at front
        //       time.
        //
        //    C) Build a new list by computing new indices with modulo:
        //       - Create newList of size n and map each value to new List index using (i + k) % n, then copy back.
        //       - Clear and AddRange the built list or replace in-place.
        //
        //    D) In-place three-reverse method:
        //       - Reverse whole, reverse first k, reverse remainder. O(1) extra space.
        //       - Slightly more algorithmic; nice to know but hint suggests slicing/modulo.
        //
        // 5) Choice justification:
        //    - Use approach B (GetRange tail + RemoveRange + InsertRange). It matches the instructor's hint
        //      about GetRange/RemoveRange/InsertRange and keeps extra allocations minimal while staying readable.
        //

        // *** IMPLEMENTATION *** // 
        
        // Guard clauses
        if (data == null) throw new ArgumentNullException(nameof(data));
        int n = data.Count;
        if (n <= 1) return;

        if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));

        int k = amount % n;
        if (k == 0) return;

        // 1) copy the last k elements (the tail)
        List<int> tail = data.GetRange(n - k, k);

        // 2) remove those k elements from the end
        data.RemoveRange(n - k, k);

        // 3) insert the tail at the front (index 0)
        data.InsertRange(0, tail);


    }
    



}
