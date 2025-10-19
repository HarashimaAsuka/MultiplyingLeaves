using UnityEngine;

public class MovingDirection : MonoBehaviour
{
    Vector3 prevPos;

    void Start()
    {
        // シーン再生時に位置を覚えておく
        this.prevPos = transform.position;
    }

    void Update()
    {
        var d = transform.position - this.prevPos;
        // ある程度移動していないと計算しない
        if (d.sqrMagnitude < 0.01f) return;

        // 移動方向へ頭を向ける(2D用)
        float angle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new(0, 0, angle - 90);

        GetComponent<SpriteRenderer>().flipX = d.x < 0;

        this.prevPos = transform.position;
    }
}