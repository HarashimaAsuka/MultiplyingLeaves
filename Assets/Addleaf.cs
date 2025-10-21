using UnityEngine;

public class Addleaf : MonoBehaviour
{
    public GameObject leaf;          // �v���n�u
    public Transform parentObject;   // �e�I�u�W�F�N�g
    public GameObject ClearCanvas;   // ���[�`���ɕ\��
    public int maxLeaf = 10;         // �������

    private GameObject lastLeaf;     // ���O�ɐ��������t����
    private float leafnum = 0;       // ������
    private bool hasSpawned = false;

    void Update()
    {
        // y �� 3 �ɓ��B�����u�Ԃɐ���
        if (this.transform.position.y >= 3f && !hasSpawned)
        {
            SpawnLeaf();
            hasSpawned = true;
        }

        // y ��3�ȉ��ɖ߂�����ēx�����\
        if (this.transform.position.y < 3f)
        {
            hasSpawned = false;
        }
    }

    void SpawnLeaf()
    {
        GameObject newLeaf = Instantiate(leaf, parentObject);

        // �����_���ɎU��΂�ʒu
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-0.5f, 0.5f);
        newLeaf.transform.localPosition = new Vector3(randomX, -1.5f - leafnum + randomY, 0);

        // �����_����]
        newLeaf.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // �����_���X�P�[��
        float scale = Random.Range(0.8f, 1.2f);
        newLeaf.transform.localScale = new Vector3(scale, scale, 1);

        // �O�̗t���ς��^�[�Q�b�g�ɒǏ]�X�N���v�g��ǉ�
        var follow = newLeaf.AddComponent<PrehabHorming>();
        if (lastLeaf != null)
        {
            follow.target = lastLeaf.transform;
        }
        else
        {
            follow.target = this.transform; // �ŏ��̗t���ς͎����iAddleaf�I�u�W�F�N�g�j��ǂ�
        }
        follow.smoothTime = 0.3f;
        follow.swayAmount = 0.5f;
        follow.swaySpeed = 2f;

        lastLeaf = newLeaf;
        leafnum++;

        // ��������ɒB������N���A
        if (leafnum >= maxLeaf)
        {
            ClearCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}


//using UnityEngine;

//public class Addleaf : MonoBehaviour
//{
//    public GameObject leaf;
//    public Transform parentObject;
//    public GameObject ClearCanvas;

//    private GameObject spawnLeaf;
//    private bool hasSpawned = false; // ��x�����������ǂ����̃t���O
//    private float leafnum;

//    void Update()
//    {
//        // y > 3 �ɏオ�����u�ԁi�O�̃t���[���ł�3�ȉ��������Ƃ��j
//        if (this.transform.position.y == 3 && !hasSpawned)
//        {
//            spawnLeaf = Instantiate(leaf, parentObject);

//            float randomX = Random.Range(-2.0f, 2.0f);
//            float randomY = Random.Range(-0.5f, 0.5f);

//            spawnLeaf.transform.localPosition = new Vector3(randomX, -1.5f - leafnum + randomY, 0);
//            spawnLeaf.transform.localRotation = Quaternion.identity;
//            spawnLeaf.transform.localScale = new Vector3(1, 1, 1);
//            leafnum++;
//            Debug.Log(leafnum);
//            //Invoke(nameof(DestroyLeaf), 2.0f);
//            hasSpawned = true; // ��x���������̂Ńt���O�𗧂Ă�
//        }

//        // y ��3�ȉ��ɖ߂�����A�Ăѐ����ł���悤�Ƀ��Z�b�g
//        if (this.transform.position.y < 3)
//        {
//            hasSpawned = false;
//        }
//        if(leafnum == 10)
//        {
//            ClearCanvas.SetActive(true);
//            Time.timeScale = 0f;
//        }
//    }

//    void DestroyLeaf()
//    {
//        Destroy(spawnLeaf);
//    }
//}
