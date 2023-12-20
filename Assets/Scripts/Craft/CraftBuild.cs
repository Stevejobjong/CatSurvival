using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName;
    public GameObject buildCraft; // 실제 설치되는 구조물
    public GameObject previewCraft; // 설치 미리보기
}

public class CraftBuild : MonoBehaviour
{
    private bool isPreviewActivated = false;

    [SerializeField] private Craft[] crafts;
    private GameObject varPreviewCraft; // 미리보기 변수
    private GameObject varBuildCraft; // 실제 설치되는 구조물 변수

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
        if (Input.GetButtonDown("Fire2"))
        {
            Cancle();
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
            Instantiate(varBuildCraft, varPreviewCraft.transform.position, Quaternion.identity);
            Destroy(varPreviewCraft);
            isPreviewActivated = false;
            craftingWindow.SetActive(false);
            varPreviewCraft = null;
            varBuildCraft = null;
        }
    }


    // 겹쳐서 생성 안되게 하는 코드였던 것...
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

    public void CreateBtnClick(int craftNum)
    {        
        varPreviewCraft = Instantiate(crafts[craftNum].previewCraft, playerPosition.position + playerPosition.forward, Quaternion.identity);
        varPreviewCraft.transform.parent = playerPosition;
        varBuildCraft = crafts[craftNum].buildCraft;
        isPreviewActivated = true;
        craftingWindow.SetActive(false);
        PlayerController.instance.ToggleCursor(false);
    }

    private void Cancle()
    {
        if (isPreviewActivated)
        {
            Destroy(varPreviewCraft);
        }
        isPreviewActivated = false;
        varPreviewCraft = null;
        varBuildCraft = null;

    }

}
