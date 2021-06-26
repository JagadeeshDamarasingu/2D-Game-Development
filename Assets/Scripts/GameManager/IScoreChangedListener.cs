/// <summary>
/// Notifies when player's score is changed
/// </summary>
public interface IScoreChangedListener
{
    void OnScoreChanged(int score);
}