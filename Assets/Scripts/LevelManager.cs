using UnityEngine.SceneManagement;

public class LevelManager
{
    private const string CurrentLevelName = "Runner";
    public void RestartScene()
    {
        LoadLevel(CurrentLevelName);
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
    }
}
