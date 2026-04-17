using UnityEngine;

public class ScoreTracker : Singleton<ScoreTracker>
{
    private int _score = 0;
    private readonly float _endLevelDelayInSeconds = 5f;
    public void ShowScoreAndEndLevel()
    {
        MessageBox.Instance.DisplayMessage($"GAME OVER! Final Score {_score}",_endLevelDelayInSeconds);
        LevelSequencer.Instance.GoToNextLevelDelayed(_endLevelDelayInSeconds);
    }
    public void IncrementScore() { _score++; }
}
