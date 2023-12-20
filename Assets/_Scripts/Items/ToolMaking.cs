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

    //버튼 클릭
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
