using UnityEngine;

public class ResultTest : MonoBehaviour
{
    GameObject wallObj;

    void Start()
    {
        wallObj = GameObject.Find("Wall");
        WallAttack();
    }

    void Update()
    {
        
    }

    private void WallAttack()
    {
        transform.SetParent(wallObj.transform, true);
        //transform.position = new Vector3(0, 0, 0);
    }
}
