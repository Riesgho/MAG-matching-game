namespace Code.Core.Domain
{
    public class Level
    {
        private readonly int _number;

        public Level(int number)
        {
            _number = number;
        }

        public int Number => _number;
    }
}