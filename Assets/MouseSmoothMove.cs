using UnityEngine;

public class MouseSmoothMove : MonoBehaviour
{
    Vector3 centerPos;
    public float speed;

    void Start()
    {
        // �V�[���Đ����̃}�E�X�J�[�\���ʒu���o���Ă���
        this.centerPos = Input.mousePosition;
    }

    void Update()
    {
        // �}�E�X�J�[�\���������ʒu���痣�ꂽ�������傫���ړ�����
        var pos = Input.mousePosition;
        var d = pos - this.centerPos;
        d.z = 0;
        transform.Translate(d * this.speed, Space.World);
    }
}