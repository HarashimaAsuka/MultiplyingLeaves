using UnityEngine;

public class Addleaf : MonoBehaviour
{
    public GameObject leaf;
    private GameObject spawnLeaf;
    private bool hasSpawned = false; // 一度生成したかどうかのフラグ

    void Update()
    {
        // y > 3 に上がった瞬間（前のフレームでは3以下だったとき）
        if (this.transform.position.y > 3 && !hasSpawned)
        {
            spawnLeaf = Instantiate(
                leaf,
                new Vector3(this.transform.position.x + 2.0f, this.transform.position.y, this.transform.position.z),
                Quaternion.identity
            );
            Invoke(nameof(DestroyLeaf), 2.0f);
            hasSpawned = true; // 一度生成したのでフラグを立てる
        }

        // y が3以下に戻ったら、再び生成できるようにリセット
        if (this.transform.position.y <= 3)
        {
            hasSpawned = false;
        }
    }

    void DestroyLeaf()
    {
        Destroy(spawnLeaf);
    }
}
