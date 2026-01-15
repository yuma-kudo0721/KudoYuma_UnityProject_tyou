using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerTest : MonoBehaviour
{
    [SerializeField] private GameObject stageObj;
    [SerializeField] private TextMeshProUGUI tmpText;

    float rotationSpeed = 30f;

    private int gameStep = 0;
    private bool gameModeStarted = false;

    public enum GameState
    {
        Title,
        Game,
        Result
    }
    public static GameState CurrentState { get; private set; }
    void Start()
    {
        CurrentState = GameState.Title;
    }

    void Update()
    {
        switch (CurrentState)
        {
            case GameState.Title:
                TitleModeUpdate();
                break;
            case GameState.Game:
                GameModeUpdate();
                break;
            case GameState.Result:
                ResultModeUpdate();
                break;
            default:
                break;
        }
    }


    private void TitleModeUpdate()
    {
        tmpText.text = "PLEASE PUSH SPACE";
        gameModeStarted = false;

        if (gameStep == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameStep = 10;
            }
        }

        if (gameStep == 10)
        {
            CurrentState = GameState.Game;
            gameStep = 0;
        }
    }

    private void GameModeUpdate()
    {
        tmpText.text = "";

        if (!gameModeStarted)
        {
            StartCoroutine(GameTimeLimit(4f));
            gameModeStarted = true;
        }

        if (stageObj != null)
        {
            stageObj.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }

        if(gameStep == 10)
        {
            CurrentState = GameState.Result;
            gameStep = 0;
        }
    }

    private void ResultModeUpdate()
    {
        tmpText.text = "GAME OVER";
        if (gameStep == 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameStep = 10;
            }
        }

        if (gameStep == 10)
        {
            CurrentState = GameState.Title;
            gameStep = 0;
        }
    }

    private IEnumerator GameTimeLimit(float duration)
    {
        yield return new WaitForSeconds(duration);
        gameStep = 10;
    }
}