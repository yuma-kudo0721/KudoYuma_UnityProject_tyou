using UnityEngine;
/// <summary>
/// 各食べ物のポイント
/// </summary>
public class ItemPoint : MonoBehaviour
{
    [SerializeField, Header("ポイント")]
    private int _itemPoint = default;

    public int Point
    {
        get { return _itemPoint; }
    }
}
