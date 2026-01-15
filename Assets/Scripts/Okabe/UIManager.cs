using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]private AddScoreManager mAddScoremanager = null;
    [SerializeField]private ScoreUI mScoreUI = null;
    [SerializeField]private LastTimeUI mLastTimeUI = null;

    [SerializeField]private GameObject titleBG = null;
    [SerializeField]private GameObject titleSTART = null;
    [SerializeField]private GameObject titleLOGO = null;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeViewAll( GameManager.GameState mode ){
        mAddScoremanager.ChangeView(mode);
        mScoreUI.ChangeView(mode);
        mLastTimeUI.ChangeView(mode);

        switch(mode){
            case GameManager.GameState.Title:{
                titleBG.SetActive(true);
                titleSTART.SetActive(true);
                titleLOGO.SetActive(true);
            }break;

            default:
            case GameManager.GameState.Game:
            case GameManager.GameState.Result:
            {
                titleBG.SetActive(false);
                titleSTART.SetActive(false);
                titleLOGO.SetActive(false);
            }break;
        }
    }

    public void AddScore( int score, Vector3 pos ){
        mAddScoremanager.Play(score,pos);
    }

    public void SetScore( int score ) {
        mScoreUI.SetScore(score);
    }

    public void StartTimer(){
        mLastTimeUI.InitTimer();
        mLastTimeUI.StartTimer();
    }

    public bool IsTimerEnd(){
        return mLastTimeUI.IsTimerEnd();
    }

}
