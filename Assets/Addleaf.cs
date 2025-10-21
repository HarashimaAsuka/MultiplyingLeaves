using UnityEngine;

public class Addleaf : MonoBehaviour
{
    public GameObject leaf;          // プレハブ
    public Transform parentObject;   // 親オブジェクト
    public GameObject ClearCanvas;   // リーチ時に表示
    public int maxLeaf = 10;         // 生成上限

    private GameObject lastLeaf;     // 直前に生成した葉っぱ
    private float leafnum = 0;       // 生成数
    private bool hasSpawned = false;

    void Update()
    {
        // y が 3 に到達した瞬間に生成
        if (this.transform.position.y >= 3f && !hasSpawned)
        {
            SpawnLeaf();
            hasSpawned = true;
        }

        // y が3以下に戻ったら再度生成可能
        if (this.transform.position.y < 3f)
        {
            hasSpawned = false;
        }
    }

    void SpawnLeaf()
    {
        GameObject newLeaf = Instantiate(leaf, parentObject);

        // ランダムに散らばる位置
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-0.5f, 0.5f);
        newLeaf.transform.localPosition = new Vector3(randomX, -1.5f - leafnum + randomY, 0);

        // ランダム回転
        newLeaf.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // ランダムスケール
        float scale = Random.Range(0.8f, 1.2f);
        newLeaf.transform.localScale = new Vector3(scale, scale, 1);

        // 前の葉っぱをターゲットに追従スクリプトを追加
        var follow = newLeaf.AddComponent<PrehabHorming>();
        if (lastLeaf != null)
        {
            follow.target = lastLeaf.transform;
        }
        else
        {
            follow.target = this.transform; // 最初の葉っぱは自分（Addleafオブジェクト）を追う
        }
        follow.smoothTime = 0.3f;
        follow.swayAmount = 0.5f;
        follow.swaySpeed = 2f;

        lastLeaf = newLeaf;
        leafnum++;

        // 生成上限に達したらクリア
        if (leafnum >= maxLeaf)
        {
            ClearCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}


//using UnityEngine;

//public class Addleaf : MonoBehaviour
//{
//    public GameObject leaf;
//    public Transform parentObject;
//    public GameObject ClearCanvas;

//    private GameObject spawnLeaf;
//    private bool hasSpawned = false; // 一度生成したかどうかのフラグ
//    private float leafnum;

//    void Update()
//    {
//        // y > 3 に上がった瞬間（前のフレームでは3以下だったとき）
//        if (this.transform.position.y == 3 && !hasSpawned)
//        {
//            spawnLeaf = Instantiate(leaf, parentObject);

//            float randomX = Random.Range(-2.0f, 2.0f);
//            float randomY = Random.Range(-0.5f, 0.5f);

//            spawnLeaf.transform.localPosition = new Vector3(randomX, -1.5f - leafnum + randomY, 0);
//            spawnLeaf.transform.localRotation = Quaternion.identity;
//            spawnLeaf.transform.localScale = new Vector3(1, 1, 1);
//            leafnum++;
//            Debug.Log(leafnum);
//            //Invoke(nameof(DestroyLeaf), 2.0f);
//            hasSpawned = true; // 一度生成したのでフラグを立てる
//        }

//        // y が3以下に戻ったら、再び生成できるようにリセット
//        if (this.transform.position.y < 3)
//        {
//            hasSpawned = false;
//        }
//        if(leafnum == 10)
//        {
//            ClearCanvas.SetActive(true);
//            Time.timeScale = 0f;
//        }
//    }

//    void DestroyLeaf()
//    {
//        Destroy(spawnLeaf);
//    }
//}
