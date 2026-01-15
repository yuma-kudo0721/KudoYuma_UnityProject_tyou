using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    // スコア関連コード
    // 増えるも減るもこの関数
    public void AddScore( int add, Vector3 pos ){
        mScore += add;

        uiManager.AddScore(add, pos);
        if (add > 0) {
            soundManager.PlaySE(SoundManager.eSeList.good);
        } else {
            soundManager.PlaySE(SoundManager.eSeList.bad);
        }

    }


    public bool IsTimeOver(){
       return uiManager.IsTimerEnd();
    }

}