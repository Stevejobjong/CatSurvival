using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCraftTab : MonoBehaviour
{
    public GameObject craftingWindow;
    public GameObject craftingToolTabPanel;

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

}
