using UnityEngine;
/// <summary>
/// プレイヤーが食べ物を取得した時に消す
/// 制作者：牧野友信
/// </summary>
public class GetItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
