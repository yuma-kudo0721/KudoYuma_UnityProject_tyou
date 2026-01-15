using UnityEngine;

public partial class GameManager : MonoBehaviour
{

    private void GameModeUpdate()
    {
        stageObj.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        
        switch(gameStep){
            case 0:{
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    Vector3 pos = GameObject.Find("Cube").transform.position;
                //    uiManager.AddScore(100, pos);
                //}

                if( uiManager.IsTimerEnd()){
                    gameStep = 99;
                }
            }break;
            case 99:{
                // ここで消すもの決してモードチェンジ
                stageObj.SetActive(false);
                
                resultStageObj.SetActive(true);
                wallObj.SetActive(true);
                ChangeState(GameState.Result);

                soundManager.StopBGM(SoundManager.eBGMList.PLAY);

                uiManager.ChangeViewAll(CurrentState);
            }break;
        }
    }

}