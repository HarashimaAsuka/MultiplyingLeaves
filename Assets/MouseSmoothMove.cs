using UnityEngine;

public class MouseSmoothMove : MonoBehaviour
{
    Vector3 centerPos;
    public float speed;

    void Start()
    {
        // シーン再生時のマウスカーソル位置を覚えておく
        this.centerPos = Input.mousePosition;
    }

    void Update()
    {
        // マウスカーソルが初期位置から離れた分だけ大きく移動する
        var pos = Input.mousePosition;
        var d = pos - this.centerPos;
        d.z = 0;
        transform.Translate(d * this.speed, Space.World);
    }
}