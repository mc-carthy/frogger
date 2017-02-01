using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadNextScene ()
    {
        int currentIndex = SceneManager.GetActiveScene ().buildIndex;
        SceneManager.LoadScene (currentIndex + 1, LoadSceneMode.Single);
    }

    public void QuitGame ()
    {
        Application.Quit ();
    }

}
