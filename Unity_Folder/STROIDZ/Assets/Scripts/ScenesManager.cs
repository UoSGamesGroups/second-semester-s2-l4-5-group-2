using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public Canvas exitMenu;
    public Button Play;
    public Button Exit;

    public Button pauseGame;
    public bool paused;
    public Canvas pauseMenu;
    public Button Resume;
    public Button Restart;
    public Button adjustAudio;
    public Button quitToMainMenu;

    public Canvas audioMenu;
    public Button backgroundMusic;
    public Button soundEffects;
    public Button Done;

    public Canvas inGameQuitMenu;
    public Button yes;
    public Button no;

    public Canvas inGameRestartMenu;
    public Button rYes;
    public Button rNo;

    public Canvas inGameExitAppMenu;
    public Button eYes;
    public Button eNo;


    void Start()
    {
        exitMenu = exitMenu.GetComponent<Canvas>();
        Play = Play.GetComponent<Button>();
        Exit = Exit.GetComponent<Button>();

        pauseMenu = pauseMenu.GetComponent<Canvas>();
        Resume = Resume.GetComponent<Button>();
        Restart = Restart.GetComponent<Button>();
        adjustAudio = adjustAudio.GetComponent<Button>();
        quitToMainMenu = quitToMainMenu.GetComponent<Button>();

        audioMenu = audioMenu.GetComponent<Canvas>();
        backgroundMusic = backgroundMusic.GetComponent<Button>();
        soundEffects = soundEffects.GetComponent<Button>();
        Done = Done.GetComponent<Button>();


        exitMenu.enabled = false; // Hides the Exit Menu pop up at game start. 
        pauseMenu.enabled = false; // Hides the Pause Menu pop up at game start. 
        paused = false;
        audioMenu.enabled = false; // Hides the Audio Menu pop up at game start.
        inGameQuitMenu.enabled = false; //Hides the in game quit menu pop up at game start. 
        pauseGame.enabled = true; //Shows the pause button in game at level start.
    }

    public void ExitMenu()
    {
        pauseMenu.enabled = false;
        exitMenu.enabled = true; // Shows the Exit Menu pop up when the Exit button is pressed.
        Play.enabled = false;
        Exit.enabled = false;
    }

    public void HideExitPopUp()
    {
        exitMenu.enabled = false; // Hides the Exit Menu pop up confirmation.
        Play.enabled = true;
        Exit.enabled = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseButton()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            PauseMenu();
        }
        else if (!paused)
        {
            Time.timeScale = 1;
            HidePausePopUp();
        }
    }

    public void PauseMenu()
    {
        pauseMenu.enabled = true;
        Resume.enabled = true;
        Restart.enabled = true;
        adjustAudio.enabled = true;
        quitToMainMenu.enabled = true;
    }

    public void HidePausePopUp()
    {
        paused = false;
        pauseMenu.enabled = false;
        Resume.enabled = false;
        Restart.enabled = false;
        adjustAudio.enabled = false;
        quitToMainMenu.enabled = false;
        paused = false;
    }

    public void AudioMenu()
    {
        pauseMenu.enabled = false;
        audioMenu.enabled = true;
        backgroundMusic.enabled = true;
        soundEffects.enabled = true;
        Done.enabled = true;
    }

    public void HideAudioMenuPopUp()
    {
        PauseMenu();
        audioMenu.enabled = false;
        backgroundMusic.enabled = false;
        soundEffects.enabled = false;
        Done.enabled = false;
    }

    public void InGameQuitMenu()
    {
        pauseMenu.enabled = false;
        inGameQuitMenu.enabled = true;
        yes.enabled = true;
        no.enabled = true;
    }

    public void HideInGameQuitMenu()
    {
        inGameQuitMenu.enabled = false;
        yes.enabled = false;
        no.enabled = false;
        PauseMenu();
    }

    public void InGameRestartMenu()
    {
        pauseMenu.enabled = false;
        inGameRestartMenu.enabled = true;
        rYes.enabled = true;
        rNo.enabled = true;
    }

    public void HideInGameRestartMenu()
    {
        inGameRestartMenu.enabled = false;
        rYes.enabled = false;
        rNo.enabled = false;
        PauseMenu();
    }

    public void InGameExitApp()
    {
        pauseMenu.enabled = false;
        inGameExitAppMenu.enabled = true;
        eYes.enabled = true;
        eNo.enabled = true;
    }

    public void HideInGameExitApp()
    {
        
        inGameExitAppMenu.enabled = false;
        eYes.enabled = false;
        eNo.enabled = false;
        PauseMenu();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
