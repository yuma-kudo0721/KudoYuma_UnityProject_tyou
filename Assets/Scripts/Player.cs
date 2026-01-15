using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -7.5f;
    public float maxX = 7.5f;

    public float rushSpeed = 10f;
    public float rotateSpeed = 90f;
    private Quaternion targetRotation;

    public int roundLevel = 0; // ← 0番目のモデルが最初
    bool isFlipped = false;

    public GameObject[] levelModels = new GameObject[5]; // [0]=Lv1, [1]=Lv2, [2]=Lv3…

    private GameObject currentModel;
    private SoundManager soundManager;
    private GameManager gameManager;
    private Collider col;


    void Start()
    {
        soundManager = FindFirstObjectByType<SoundManager>();
        gameManager = FindFirstObjectByType<GameManager>();
        UpdatePlayerAppearance();

        col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        transform.Translate(move * moveSpeed * Time.deltaTime, 0f, 0f);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
        
        

    }

    // 食べ物を取得した際に外部から呼び出す関数
    public void PickUpFood(FoodType type)
    {
        if (type == FoodType.Round)
        {
            // 丸い食べ物：レベルダウン
            roundLevel = Mathf.Max(0, roundLevel - 1); // 0未満にならない
        }
        else if (type == FoodType.Pointy)
        {
            // 尖った食べ物：レベルアップ
            roundLevel = Mathf.Min(levelModels.Length - 1, roundLevel + 1); // 配列範囲外防止
        }

        //gameManager.GetUIManager().AddScore();

        UpdatePlayerAppearance();

    }

    void UpdatePlayerAppearance()
    {
        // 全モデル非表示
        foreach (GameObject model in levelModels)
        {
            if (model != null)
                model.SetActive(false);
        }

        // 現在レベルのモデルを表示
        if (levelModels[roundLevel] != null)
        {
            levelModels[roundLevel].SetActive(true);
            currentModel = levelModels[roundLevel];
        }
        else
        {
            Debug.LogError("モデルが設定されていません: " + roundLevel);
        }
    }

    public void Rush()
    {
        col.isTrigger = true;
        


        targetRotation = Quaternion.Euler(90f, 0f, 0f);
        isFlipped = true;

        if (isFlipped)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.position += Vector3.forward * rushSpeed * Time.deltaTime;
            }
        }


    }
}

public enum FoodType
{
    Round,   // 丸い → レベル下がる
    Pointy   // 尖った → レベル上がる
}
