using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSequencer : SingletonPersistent<LevelSequencer>
{
    [ContextMenu("Go To Next Level")]
    public void GoToNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1)%SceneManager.sceneCountInBuildSettings);
    }

    public void GoToNextLevelDelayed(float delayInSeconds)
    {
        StartCoroutine(GoToNextLevelDelayedRoutine(delayInSeconds));
    }

    private IEnumerator GoToNextLevelDelayedRoutine(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        GoToNextLevel();
    }
}
