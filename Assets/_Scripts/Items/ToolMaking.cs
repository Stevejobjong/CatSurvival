using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ToolMaking : MonoBehaviour
{
    public TMP_Text toolName;
    public TMP_Text toolDes;
    public TMP_Text toolIngredient;
    public TMP_Text toolUseTxt;

    [Header("Ingredients")]
    public ItemData Wood;
    public ItemData Rock;

    [Header("Results")]
    public ItemData Axe;
    public ItemData Pick;
    public ItemData Sword;
    public ItemData FishingRod; 

    public GameObject CraftPanel;


    public Button CreatToolBtn;
    private int chooseTool;


    public void ClickAxe()
    {
        toolName.text = "도끼";
        toolDes.text = "무인도에서 이정도 기술력을?!";
        toolIngredient.text = "나무 3개";
        toolUseTxt.text = "나무를 벨 수 있다.";

        chooseTool = 0;
    }
    public void ClickPick()
    {
        toolName.text = "곡괭이";
        toolDes.text = "꽤나 무겁다.";
        toolIngredient.text = "나무 5개";
        toolUseTxt.text = "돌을 캘 수 있다.";

        chooseTool = 1;
    }
    public void ClickSword()
    {
        toolName.text = "검";
        toolDes.text = "매우 날카롭다.";
        toolIngredient.text = "나무 2개 돌 4개";
        toolUseTxt.text = "동물을 사냥할 수 있다.";

        chooseTool = 2;
    }
    public void ClickFishingRod()
    {
        toolName.text = "낚시대";
        toolDes.text = "고양이는 참치가 먹고싶다!";
        toolIngredient.text = "나무 1개";
        toolUseTxt.text = "물가에서 낚시를 할 수 있다.";

        chooseTool = 3;
    }

    public void CreatTool()
    {
        switch(chooseTool)
        {
            case 0: //creat Axe
                
                if(Inventory.instance.UHaveItem(Wood, 3))
                {
                    if (!QuestManager.Instance.isMakeAxe)
                    {
                        QuestManager.Instance.isMakeAxe = true;
                        QuestManager.Instance.MakeAxe(QuestManager.Instance.isMakeAxe);
                    }
                    Inventory.instance.RemoveItem(Wood, 3); //나무 제거
                    Inventory.instance.ThrowItem(Axe);
                }
                break;
            case 1:
                if (!QuestManager.Instance.isMakePick)
                {
                    QuestManager.Instance.isMakePick = true;
                    QuestManager.Instance.MakePick(QuestManager.Instance.isMakePick);
                }
                if (Inventory.instance.UHaveItem(Wood, 5))
                {
                    Inventory.instance.RemoveItem(Wood, 5); //나무 제거
                    Inventory.instance.ThrowItem(Pick);
                }
                break;
            case 2:
                if (Inventory.instance.UHaveItem(Wood, 2) && Inventory.instance.UHaveItem(Rock, 4))
                {
                    Inventory.instance.RemoveItem(Wood, 2); //나무 제거
                    Inventory.instance.RemoveItem(Rock, 4); //돌 제거

                    Inventory.instance.ThrowItem(Sword);
                }
                break;
            case 3:
                if (!QuestManager.Instance.isMakeFishingRod)
                {
                    QuestManager.Instance.isMakeFishingRod = true;
                    QuestManager.Instance.MakeFishingRod(QuestManager.Instance.isMakeFishingRod);
                }
                if (Inventory.instance.UHaveItem(Wood, 1))
                {
                    Inventory.instance.RemoveItem(Wood, 1); //나무 제거
                    Inventory.instance.ThrowItem(FishingRod);
                }
                break;
        }
    }

}
