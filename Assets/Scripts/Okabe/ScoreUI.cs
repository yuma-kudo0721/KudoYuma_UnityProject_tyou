using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI mText = new TextMeshProUGUI();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetScore( 0 );// â“ì≠éûÇ…èâä˙âª
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore( int setScore ) {
        if(!mText){
          Debug.Log("ScoreUI:SetScore: mText is null");
          return;
        }

        mText.SetText("score:" + setScore.ToString());

    }

    public void ChangeView( GameManager.GameState state ){
        switch(state){
            case GameManager.GameState.Game:{
                gameObject.SetActive(true);
            }break;

            default:
            {
                gameObject.SetActive(false);
            }break;
        }
        
    }

}
