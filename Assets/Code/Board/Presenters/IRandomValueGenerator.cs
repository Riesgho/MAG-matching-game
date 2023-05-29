namespace Code.Board.Presenters
{
    public interface IRandomValueGenerator
    {
        int GetValueBetween(int min, int max);
    }
}