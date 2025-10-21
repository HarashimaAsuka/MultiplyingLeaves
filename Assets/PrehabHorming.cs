using UnityEngine;

public class PrehabHorming : MonoBehaviour
{
    public Transform target;       // �Ǐ]�Ώ�
    public float smoothTime = 0.3f;
    public float swayAmount = 0.5f;
    public float swaySpeed = 2f;

    private Vector3 currentVelocity;
    private float randomOffset;

    void Start()
    {
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (target == null) return;

        // �Ǐ]�{�h��
        Vector3 targetPos = target.position;

        // �����_���h��Ńq���q��
        float swayX = Mathf.Sin(Time.time * swaySpeed + randomOffset) * swayAmount;
        float swayY = Mathf.Cos(Time.time * swaySpeed * 0.7f + randomOffset) * swayAmount * 0.5f;
        targetPos += new Vector3(swayX, swayY, 0);

        // ���炩�Ǐ]
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothTime);

        // �����_����]�ŕ������A�b�v
        float angle = Mathf.Sin(Time.time * swaySpeed + randomOffset) * 30f; // �}30�x
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}



//using UnityEngine;

//public class PrehabHorming : MonoBehaviour
//{
//    public string targetName = "koala";
//    public float smoothTime = 0.3f;
//    public float swayAmount = 0.5f;
//    public float swaySpeed = 2.0f;

//    private Transform target;
//    private Vector3 currentVelocity;
//    private float randomOffset;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        GameObject targetObj = GameObject.Find(targetName);
//        target = targetObj.transform;
//        randomOffset = Random.Range(0f, 100f);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (target != null)
//        {
//            GameObject obj = GameObject.Find(targetName);
//            if (obj != null) target = obj.transform;
//            else return;
//        }

//        // ��{�Ǐ]
//        Vector3 targetPos = target.position;

//        // �����_���ȍ��E�E�㉺�h���������
//        float swayX = Mathf.Sin(Time.time * swaySpeed + randomOffset) * swayAmount;
//        float swayY = Mathf.Cos(Time.time * swaySpeed * 0.7f + randomOffset) * swayAmount * 0.5f;
//        targetPos += new Vector3(swayX, swayY, 0);
//        // ���炩�ړ�
//        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentVelocity, smoothTime);
//    }
//}
