using GuessNumber.Abstractions;

namespace GuessNumber
{
    class GetRandomInt : IGetRandomInt
    {
        private readonly Random _random;

        public GetRandomInt()
        {
            _random = new Random();
        }

        public int Execute(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }
    }
}