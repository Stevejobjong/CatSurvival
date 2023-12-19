using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName;
    public GameObject buildCraft; // ���� ��ġ�Ǵ� ������
    public GameObject previewCraft; // ��ġ �̸�����
}

public class CraftBuild : MonoBehaviour
{
    private bool isPreviewActivated = false;

    [SerializeField] private Craft[] craftCampfire;
    private GameObject varPreviewCraft; // �̸����� ����
    private GameObject varBuildCraft; // ���� ��ġ�Ǵ� ������ ����

    [SerializeField] private Transform playerPosition;
    private RaycastHit hitInfor;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float range;

    [SerializeField] private GameObject craftingWindow;

    // Button createBtn;

    //private void Start()
    //{
    //    createBtn = GetComponent<Button>();
    //    createBtn?.onClick.AddListener(() => CreateBtnClick());
    //}

    private void Update()
    {
        if (isPreviewActivated)
        {
            //PreviewPosition();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Click");
            Build();
        }
    }

    //private void PreviewPosition()
    //{
    //    if (Physics.Raycast(playerPosition.position, playerPosition.forward, out hitInfor, range, layerMask))
    //    {
    //        if (hitInfor.transform != null)
    //        {
    //            Vector3 location = hitInfor.point;
    //            varPreviewCraft.transform.position = location;
                
    //        }
    //    }
    //}

    private void Build()
    {
        if (isPreviewActivated)
        {
            Debug.Log("Create");
            Instantiate(varBuildCraft, varPreviewCraft.transform.position, Quaternion.identity);
            Destroy(varPreviewCraft);
            isPreviewActivated = false;
            craftingWindow.SetActive(false);
            varPreviewCraft = null;
            varBuildCraft = null;
        }
    }

    public void CreateBtnClick(int craftNum)
    {        
        varPreviewCraft = Instantiate(craftCampfire[craftNum].previewCraft, playerPosition.position + playerPosition.forward, Quaternion.identity);
        varPreviewCraft.transform.parent = playerPosition;
        varBuildCraft = craftCampfire[craftNum].buildCraft;
        isPreviewActivated = true;
        craftingWindow.SetActive(false);
        PlayerController.instance.ToggleCursor(false);
    }

    //private void Cancle()
    //{
    //    if (isPreviewActivated)
    //    {
    //        Destroy(varPreviewCraft);
    //    }
    //    isPreviewActivated = false;
    //    varPreviewCraft = null;
    //   varBuildCraft = null;

    //    craftInforPanel.SetActive(false);
    //}

}
