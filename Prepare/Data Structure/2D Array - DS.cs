namespace HackerRank.Data_Structure
{
    // https://www.hackerrank.com/challenges/2d-array/problem

    public class _2D_Arrays
    {       

        static int CalculateSum(int[][] arr, int x, int y)
        {
            return
                arr[y + 0][x + 0] + arr[y + 0][x + 1] + arr[y + 0][x + 2] +
                                    arr[y + 1][x + 1] +
                arr[y + 2][x + 0] + arr[y + 2][x + 1] + arr[y + 2][x + 2];
        }


        // Complete the hourglassSum function below.
        static int HourglassSum(int[][] arr)
        {
            int[] sums = new int[16];

            int hourglassIndex = 0;            

            for (var x = 0; x < arr.Length; x++)
                for (var y = 0; y < arr.Length; y++)
                    sums[hourglassIndex] = CalculateSum(arr, x, y);
            
            return sums.Max();
        }
    }
}
