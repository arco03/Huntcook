namespace _Scripts.Manager
{
    public class StarManager
    {
        public int TotalStars;
        private readonly float _threeStarTime;
        private readonly float _twoStarTime;

        public StarManager(float threeStarTime, float twoStarTime)
        {
            _threeStarTime = threeStarTime;
            _twoStarTime = twoStarTime;
            TotalStars = 0;
        }

        public void CalculateStars(float timeTaken)
        {
            if (timeTaken >= _threeStarTime)
            {
                TotalStars = 3;
            }
            else if (timeTaken >= _twoStarTime)
            {
                TotalStars = 2;
            }
            else
            {
                TotalStars = 1;
            }
        }
    }
}