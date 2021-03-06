﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadNextScene ()
    {
        int currentIndex = SceneManager.GetActiveScene ().buildIndex;
        SceneManager.LoadScene (currentIndex + 1, LoadSceneMode.Single);
    }

	public void ReloadScene ()
    {
        int currentIndex = SceneManager.GetActiveScene ().buildIndex;
        SceneManager.LoadScene (currentIndex, LoadSceneMode.Single);
    }

    public void QuitGame ()
    {
        Application.Quit ();
    }

    private void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
