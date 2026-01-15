using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    float LastTimer = 0;
    private void ResultModeUpdate()
    {
        switch(gameStep){
            case 0:{
                soundManager.PlayBGM(SoundManager.eBGMList.RESULT_Clear);

                LastTimer = 0;
                
                // é∏îséû
                ///soundManager.PlayBGM(SoundManager.eBGMList.RESULT_Gameover);
                
                gameStep++;
                }
                break;
            case 1:{
                LastTimer += Time.deltaTime;
                // ââèoäJén
                Player playerscr = playerObj.GetComponent<Player>();
                playerscr.Rush();

                if(LastTimer > 10.0f ){
                    gameStep++;
                }
            }break;
            case 2:{
                gameStep = 999;

            }break;
            case 999:{
                ChangeState(GameState.Title);
                
                uiManager.ChangeViewAll(CurrentState);
                soundManager.StopBGM(SoundManager.eBGMList.RESULT_Clear);
                soundManager.PlayBGM(SoundManager.eBGMList.TITLE);

            }break;

            default:{
                
            }break;
        }
    }



}