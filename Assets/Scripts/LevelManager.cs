using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadLevel(string name)
    {
        print("Load level requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        print("Quit requested.");
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.BreakableCount <= 0)
        {
            LoadLevel("Win");
        }
    }

}
