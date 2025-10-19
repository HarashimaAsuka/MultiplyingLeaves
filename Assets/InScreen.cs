using UnityEngine;

public class InScreen : MonoBehaviour
{
    public float top;
    public float bottom;
    public float left;
    public float right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        if (pos.x < this.left) pos.x = this.left;
        if(pos.x > this.right) pos.x = this.right;
        if(pos.y > this.top) pos.y = this.top;
        if(pos.y < this.bottom) pos.y = this.bottom;

        transform.position = pos;
    }
}
