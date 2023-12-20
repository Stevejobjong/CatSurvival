using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolMaking : MonoBehaviour
{
    public TMP_Text toolName;
    public TMP_Text toolDes;
    public TMP_Text toolIngredient;
    public TMP_Text toolUseTxt;


    public GameObject CraftPanel;
    public GameObject craftingWindow;
    public GameObject craftingToolTabPanel;


    public Button CreatToolBtn;
    private int chooseTool;


    private void Awake()
    {
        CraftPanel.SetActive(false);
    }

    //��ư Ŭ��
    public void ChooseFurnitureTab()
    {
        craftingWindow.SetActive(true);
        craftingToolTabPanel.SetActive(false);
    }
    public void ChooseToolTab()
    {
        craftingWindow.SetActive(false);
        craftingToolTabPanel.SetActive(true);
    }




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

                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

}
