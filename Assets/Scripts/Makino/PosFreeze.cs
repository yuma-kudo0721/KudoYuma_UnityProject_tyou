using UnityEngine;

public class PosFreeze : MonoBehaviour
{
    private Vector3 _orizinPos = default;
    private void Awake()
    {
        _orizinPos = transform.position;
    }
    private void Update()
    {
        transform.position = _orizinPos;
    }
}
