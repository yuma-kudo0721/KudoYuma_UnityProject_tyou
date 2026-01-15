using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreManager : MonoBehaviour
{
    [SerializeField]
    List<AddScoreUI> datList = new List<AddScoreUI>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play(int score, Vector3 pos) {
        for ( int i = 0 ; i < datList.Count ; i++ ){
            if( datList[i].isActiveAndEnabled )    continue;

            datList[i].gameObject.SetActive(true);
            datList[i].Play(score,pos);

            break;

        }
        
    }

    public void ChangeView( GameManager.GameState state ){
        for ( int i = 0 ; i < datList.Count ; i++ ){
            datList[i].ChangeView(state);
        }
    }

    
}
