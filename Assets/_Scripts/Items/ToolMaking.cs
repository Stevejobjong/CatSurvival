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
        toolName.text = "����";
        toolDes.text = "���ε����� ������ �������?!";
        toolIngredient.text = "���� 3��";
        toolUseTxt.text = "������ �� �� �ִ�.";

        chooseTool = 0;
    }
    public void ClickPick()
    {
        toolName.text = "���";
        toolDes.text = "�ϳ� ���̴�.";
        toolIngredient.text = "���� 5��";
        toolUseTxt.text = "���� Ķ �� �ִ�.";

        chooseTool = 1;
    }
    public void ClickSword()
    {
        toolName.text = "��";
        toolDes.text = "�ſ� ��ī�Ӵ�.";
        toolIngredient.text = "���� 2�� �� 4��";
        toolUseTxt.text = "������ ����� �� �ִ�.";

        chooseTool = 2;
    }
    public void ClickFishingRod()
    {
        toolName.text = "���ô�";
        toolDes.text = "����̴� ��ġ�� �԰�ʹ�!";
        toolIngredient.text = "���� 1��";
        toolUseTxt.text = "�������� ���ø� �� �� �ִ�.";

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
                    Inventory.instance.RemoveItem(Wood, 3); //���� ����
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
                    Inventory.instance.RemoveItem(Wood, 5); //���� ����
                    Inventory.instance.ThrowItem(Pick);
                }
                break;
            case 2:
                if (Inventory.instance.UHaveItem(Wood, 2) && Inventory.instance.UHaveItem(Rock, 4))
                {
                    Inventory.instance.RemoveItem(Wood, 2); //���� ����
                    Inventory.instance.RemoveItem(Rock, 4); //�� ����

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
                    Inventory.instance.RemoveItem(Wood, 1); //���� ����
                    Inventory.instance.ThrowItem(FishingRod);
                }
                break;
        }
    }

}
