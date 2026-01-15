using UnityEngine;

public partial class GameManager : MonoBehaviour
{

    private void TitleModeUpdate()
    {
        switch(gameStep){
            case 0:{
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    gameStep++;
                }
            }break;

            case 1:{
                soundManager.StopBGM(SoundManager.eBGMList.TITLE);
                soundManager.PlaySE(SoundManager.eSeList.playStart);
                gameStep++;
            }break;
            case 100:{
                uiManager.StartTimer();// タイマーカウント開始
                soundManager.PlayBGM(SoundManager.eBGMList.PLAY);

                ChangeState(GameState.Game);
                uiManager.ChangeViewAll(CurrentState);
            }break;

            default:{
                gameStep++;
            }break;
        }

    }

}