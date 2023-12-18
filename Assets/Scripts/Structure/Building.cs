using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Craft
{
    public string craftName;
    public GameObject craftCreate;
    public GameObject craftPreview;
}

public class Building : MonoBehaviour
{
    private bool isPreviewActivate = false;

    public GameObject craftingWindow;
    //public GameObject craftingTable;

    [SerializeField] private Craft[] craft_Campfire;
    private GameObject preview;

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        craftingWindow.SetActive(false);
    }

    public void SlotClick(int slotNum)
    {
        preview = Instantiate(craft_Campfire[slotNum].craftPreview, playerTransform.position + playerTransform.forward, Quaternion.identity);
        isPreviewActivate = true;
        craftingWindow.SetActive(false);
    }
}
