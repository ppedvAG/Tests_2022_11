namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            //throw new OverflowException();
            return checked(a + b);
        }
    }
}