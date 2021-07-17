/// <summary>
/// notifies when Player's lives count changes
/// </summary>
public interface ILivesCountChangeListener
{
    void OnLivesCountChanged(int livesRemaining);
}