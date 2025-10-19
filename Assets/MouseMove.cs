using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float posY = 300;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスカーソル位置
        var pos = Input.mousePosition;
        //Zが0だと見えなくなるので適当な正の値にする
        pos.z = 1;
        //pos.y += posY;
        //スクリーン座標ー＞シーン内のワールド座標
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
