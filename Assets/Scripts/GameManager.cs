using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private UIManager uiManager;

    [SerializeField] private GameObject stageObj;

    [SerializeField] private GameObject resultStageObj;
    [SerializeField] private GameObject wallObj;

    [SerializeField] private GameObject playerObj;

    private float rotationSpeed = 30f;

    private int gameStep = 0;

    private int mScore = 0;

    public UIManager GetUIManager(){
        return uiManager;
    }

    public enum GameState
    {
        Title,
        Game,
        Result
    }
    public static GameState CurrentState { get; private set; }
    void ChangeState( GameState state, int step = 0){
        CurrentState = state;
        gameStep = step;
    }

    void Start()
    {
        ChangeState(GameState.Title);

        if(uiManager){
            uiManager.ChangeViewAll(CurrentState);
        }
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

}