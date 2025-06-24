using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector instance;

    [Header("Manager")]
    public LevelManager levelManager;
    public CoinManager coinManager;
    public FXManagers fXManager;
    public AudioManager audioManager;
    public Player player;

    [Header("UI")]
    public MainMenu mainMenu;
    public PlayerHitUI playerHitUI;
    public PlayerHealthUI playerHealthUI;
    public MessageUI messageUI;

    public CameraHolder cameraHolder;

    public GameState gameState;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        gameState = GameState.MainMenu;
        HideInGameUI();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
            mainMenu.Hide();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadPreviousLevel();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerHealthUI.Show();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            playerHealthUI.Hide();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            mainMenu.Show();
            mainMenu.EnabledResumeButton();
            mainMenu.startButtonTMP.text = "RESTART";
            gameState = GameState.MainMenu;
            HideInGameUI();
        }

    }

    public void RestartLevel()
    {
        gameState = GameState.GamePlay;
        ShowInGameUI();
        levelManager.RestartLevelManager();
        player.RestartPlayer();
        playerHealthUI.Show();
    }
    void LoadNextLevel()
    {
        if (levelManager.levelNo < levelManager.levels.Count)
        {
            levelManager.levelNo += 1;
        }

        RestartLevel();
    }

    void LoadPreviousLevel()
    {
        if (levelManager.levelNo > 1)
        {
            levelManager.levelNo -= 1;
        }

        RestartLevel();
    }

    public void LevelCompleted()
    {
        Invoke(nameof(LoadNextLevel), 0.2f);
    }

    public void Loose()
    {

    }

    public void ShowInGameUI()
    {
        coinManager.coinUI.Show();
    }
    public void HideInGameUI()
    {
        coinManager.coinUI.Hide();
    }
}

public enum GameState
{
    MainMenu,
    GamePlay,
    VictoryUI,
    FailUI,
}