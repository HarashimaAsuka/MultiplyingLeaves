using UnityEngine;

public class MovingDirection : MonoBehaviour
{
    Vector3 prevPos;

    void Start()
    {
        // �V�[���Đ����Ɉʒu���o���Ă���
        this.prevPos = transform.position;
    }

    void Update()
    {
        var d = transform.position - this.prevPos;
        // ������x�ړ����Ă��Ȃ��ƌv�Z���Ȃ�
        if (d.sqrMagnitude < 0.01f) return;

        // �ړ������֓���������(2D�p)
        float angle = Mathf.Atan2(d.y, d.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new(0, 0, angle - 90);

        GetComponent<SpriteRenderer>().flipX = d.x < 0;

        this.prevPos = transform.position;
    }
}