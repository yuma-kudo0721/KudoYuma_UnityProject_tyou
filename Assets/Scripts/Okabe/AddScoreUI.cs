using TMPro;
using UnityEngine;

public class AddScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI mText = new TextMeshProUGUI();

    int state = 0;
    float timer = 0;
    float limitTime = 1.0f;

    Camera cam = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case 0: {
                // 何もしない
            }break;
            case 1: {
                // 実際の動作

                if((timer += Time.deltaTime) > limitTime ) {
                    timer = 0;
                    state++;
                }

            }break;
            case 2: {
                // 動作終了
                state = 0;
                gameObject.SetActive(false);
            }break;
        }
    }

    public void Play( int score, Vector3 pos)
    {
        if(!mText)return;

        // 座標変換

        Vector2 pos2 = cam.WorldToScreenPoint(pos);

        gameObject.transform.position = pos2;// 座標変更

        // テキスト変更
        if(score > 0){
            mText.SetText("<color #eba947>+"+ score.ToString() +"</color>");
        } else if (score < 0) {
            mText.SetText("<color #3069c4>-"+ score.ToString() +"</color>");
        }

        state = 1;

    }

    public void ChangeView( GameManager.GameState state ){
        switch(state){
            //case GameManager.GameState.Game:{
            //    gameObject.SetActive(true);
            //}break;

            default:
            {
                gameObject.SetActive(false);
            }break;
        }
        
    }

}
