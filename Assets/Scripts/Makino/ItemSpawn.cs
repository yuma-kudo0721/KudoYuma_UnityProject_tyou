using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの生成
/// 制作者：牧野友信
/// </summary>
public class ItemSpawn : MonoBehaviour
{
    private int _spawnType = 0;

    [SerializeField, Tooltip("レーン")]
    private GameObject _lane = default;

    private GameObject _popedObj = default;

    private int _posIndex = 0;

    private float _timer = 0;
    [SerializeField, Header("生成される間隔")]
    private float _timeLimit = 3;
    #region SerializeField変数
    [SerializeField, Header("プラスアイテムのリスト")]
    private List<GameObject> _plusItemList = default;

    [SerializeField, Header("マイナスアイテムのリスト")]
    private List<GameObject> _minusItemList = default;

    [SerializeField, Header("何も出ない確率"), Tooltip("1～10までの値でお願いします")]
    private int _nothing = 2;

    [SerializeField, Header("プラスアイテムが出る確率"), Tooltip("1～10までの値でお願いします")]
    private int _plusPop = 5;

    [SerializeField, Header("マイナスアイテムが確率"), Tooltip("1～10までの値でお願いします")]
    private int _minusPop = 3;

    [SerializeField, Header("一番低い確率"), Tooltip("1～100までの値でお願いします")]
    private int _firstProbability = 5;

    [SerializeField, Header("二番目に低い確率"), Tooltip("1～100までの値でお願いします")]
    private int _secondProbability = 15;

    [SerializeField, Header("三番目に低い確率"), Tooltip("1～100までの値でお願いします")]
    private int _thirdProbability = 20;

    [SerializeField, Header("四番目に低い確率"), Tooltip("1～100までの値でお願いします")]
    private int _fourthProbability = 25;

    [SerializeField, Header("五番目に低い確率"), Tooltip("1～100までの値でお願いします")]
    private int _fifthProbability = 35;

    [SerializeField]
    private GameObject[] _spawnPoints = new GameObject[5];
    [SerializeField]
    private List<GameObject> _spawnPointsView = default;

    #endregion



    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timeLimit)
        {
            _spawnPointsView = new List<GameObject>(_spawnPoints);

            for (int i = 0; i < 5; i++)
            {
                SpawnItem();
            }
            _timer = 0;
        }
    }
    private void SpawnItem()
    {
        _spawnType = Random.Range(1, 10);

        if (_spawnType <= _nothing)
        {
            return;
        }
        else if (_spawnType <= _nothing + _plusPop)
        {
            ItemLotteryAndPop(_plusItemList);
        }
        else
        {
            ItemLotteryAndPop(_minusItemList);
        }
    }

    /// <summary>
    /// 生成するアイテムの抽選
    /// </summary>
    /// <param name="list"></param>
    private void ItemLotteryAndPop(List<GameObject> list)
    {
        int itemIndex = Random.Range(1, 100);

        if (itemIndex <= _fifthProbability)
        {
            if (list[0] == null)
            {
                return;
            }
            PopItem(list[0]);
        }
        else if (itemIndex <= _fifthProbability + _secondProbability)
        {
            if (list[1] == null)
            {
                return;
            }
            PopItem(list[1]);
        }
        else if (itemIndex <= _fifthProbability + _secondProbability + _thirdProbability)
        {
            if (list[2] == null)
            {
                return;
            }
            PopItem(list[2]);
        }
        else if (itemIndex <= _fifthProbability + _secondProbability + _thirdProbability + _fourthProbability)
        {
            if (list[3] == null)
            {
                return;
            }
            PopItem(list[3]);
        }
        else
        {
            if (list[4] == null)
            {
                return;
            }
            PopItem(list[4]);
        }

    }

    private void PopItem(GameObject gameObject)
    {

        _popedObj = Instantiate(gameObject);
        _posIndex = Random.Range(0, _spawnPointsView.Count);

        _popedObj.transform.position = _spawnPointsView[_posIndex].transform.position;
        _popedObj.transform.SetParent(_lane.transform);

        _spawnPointsView.RemoveAt(_posIndex);
    }
}
