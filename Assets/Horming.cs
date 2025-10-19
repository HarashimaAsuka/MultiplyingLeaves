using UnityEngine;

public class Horming : MonoBehaviour
{
    public Transform target;
    public float smoothTime;

    Vector3 currentVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ŠŠ‚ç‚©ˆÚ“®
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentVelocity, smoothTime);
    }
}
