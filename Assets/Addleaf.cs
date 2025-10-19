using UnityEngine;

public class Addleaf : MonoBehaviour
{
    public GameObject leaf;
    private GameObject spawnLeaf;
    private bool hasSpawned = false; // ��x�����������ǂ����̃t���O

    void Update()
    {
        // y > 3 �ɏオ�����u�ԁi�O�̃t���[���ł�3�ȉ��������Ƃ��j
        if (this.transform.position.y > 3 && !hasSpawned)
        {
            spawnLeaf = Instantiate(
                leaf,
                new Vector3(this.transform.position.x + 2.0f, this.transform.position.y, this.transform.position.z),
                Quaternion.identity
            );
            Invoke(nameof(DestroyLeaf), 2.0f);
            hasSpawned = true; // ��x���������̂Ńt���O�𗧂Ă�
        }

        // y ��3�ȉ��ɖ߂�����A�Ăѐ����ł���悤�Ƀ��Z�b�g
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
