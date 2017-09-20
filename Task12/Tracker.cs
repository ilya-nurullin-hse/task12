namespace Task12
{
    public class Tracker
    {
        private int movementCount = 0;
        private int comparisonCount = 0;


        public bool Compare(bool res)
        {
            comparisonCount++;
            return res;
        }

        public void Move()
        {
            movementCount++;
        }

        public void Clear()
        {
            movementCount = 0;
            comparisonCount = 0;
        }
    }
}