using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHandler : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public Button SartB;
    public Button InstructionB;
    public Button SettingB;
    public Button CreditB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setPanel(int p)
    {
        switch (p)
        {
            case 0:
                p1.SetActive(true);
                p2.SetActive(false);
                SartB.interactable = true;
                InstructionB.interactable = true;
                SettingB.interactable = true;
                CreditB.interactable = true;
                break;
            case 1:
                p1.SetActive(false);
                p2.SetActive(true);
                SartB.interactable = false;
                InstructionB.interactable = false;
                SettingB.interactable = false;
                CreditB.interactable = false;
                break;
            case 2:
                p1.SetActive(true);
                p3.SetActive(false);
                SartB.interactable = true;
                InstructionB.interactable = true;
                SettingB.interactable = true;
                CreditB.interactable = true;
                break;
            case 3:
                p1.SetActive(false);
                p3.SetActive(true);
                SartB.interactable = false;
                InstructionB.interactable = false;
                SettingB.interactable = false;
                CreditB.interactable = false;
                break;
            case 4:
                p1.SetActive(true);
                p4.SetActive(false);
                SartB.interactable = true;
                InstructionB.interactable = true;
                SettingB.interactable = true;
                CreditB.interactable = true;
                break;
            case 5:
                p1.SetActive(false);
                p4.SetActive(true);
                SartB.interactable = false;
                InstructionB.interactable = false;
                SettingB.interactable = false;
                CreditB.interactable = false;
                break;
            default:
                break;
        }
    }
}
