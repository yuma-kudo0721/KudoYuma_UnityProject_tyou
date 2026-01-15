using TMPro;
using UnityEngine;

public class LastTimeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI mText = new TextMeshProUGUI();

    [SerializeField] float mLimitTime = 45f;  //êßå¿éûä‘

    static public float mLastTime = 0f;        //åoâﬂéûä‘
    bool isEngTime = false;
    bool isUpdating = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUpdating) return;

        mLastTime -= Time.deltaTime;
        if (mLastTime <= 0)
        {
            mLastTime = 0;
            isEngTime = true;
        }
        
        if(mText){
            int inttime = ((int)mLastTime);
            string context = "<color #00FF00>íEèoÇ‹Ç≈" + inttime + "ïb</color>";
            mText.text = context;
        }

    }

    public void InitTimer()
    {
        mLastTime = mLimitTime;
        isEngTime = false;
        isUpdating = false;
    }

    public void StartTimer()
    {
        isUpdating = true;
    }

    public bool IsTimerEnd()
    {
        return isEngTime;
    }

    public float GetLastTime()
    {
        return mLastTime;
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
