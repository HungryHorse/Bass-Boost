using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public GameObject PauseMenu;
    public PlayerMovement player;
    public AudioSource Audio;
    public CursorManager cursorManager;
    private bool currStateUnpaused;

    private void Start()
    {
        currStateUnpaused = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
	}

    public void PauseUnpause()
    {
        if (currStateUnpaused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            player.enabled = false;
            Audio.Pause();
            currStateUnpaused = false;
            cursorManager.makeCursorVisable();
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            player.enabled = true;
            Audio.UnPause();
            currStateUnpaused = true;
            cursorManager.makeCursorInvisable();
        }
    }
}
