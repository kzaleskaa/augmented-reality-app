using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class changeModels : MonoBehaviour
{
    VirtualButtonBehaviour[] virtualButtonBehaviours;
    string virtualButtonName;
    public GameObject firstPanel, secondPanel, cube, sphere, cylinder, capsule;

    void Start()
    {
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            virtualButtonBehaviours[i].RegisterOnButtonPressed(onButtonPressed);
            virtualButtonBehaviours[i].RegisterOnButtonReleased(onButtonReleased);
        }
    }

    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        virtualButtonName = vb.VirtualButtonName;

        if(virtualButtonName == "VirtualButtonChange") {
            VirtualButtonChange();
            Debug.Log("Button Pressed - Change");
        } else if(firstPanel.activeSelf) {
            Deactivate();
            if(virtualButtonName == "VirtualButton1") {
                Btn1();
                Debug.Log("Button Pressed - Cube");
            } else if(virtualButtonName == "VirtualButton2") {
                Btn2();
                Debug.Log("Button Pressed - Sphere");
            }
        } else {
            Deactivate();
            if(virtualButtonName == "VirtualButton1") {
                Btn3();
                Debug.Log("Button Pressed - Cylinder");
            } else if(virtualButtonName == "VirtualButton2") {
                Btn4();
                Debug.Log("Button Pressed - Capsule");
            }
        }
    }

    public void onButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button released");
    }

    void VirtualButtonChange()
    {
        if(firstPanel.activeInHierarchy) {
            firstPanel.SetActive(false);
            secondPanel.SetActive(true);
        } else {
            firstPanel.SetActive(true);
            secondPanel.SetActive(false);
        }
    }

    void Deactivate() 
    {
        cube.SetActive(false);
        sphere.SetActive(false);
        cylinder.SetActive(false);
        capsule.SetActive(false);
    }

    void Btn1 () 
    {
        cube.SetActive(true);
    }

    void Btn2 () 
    {
        sphere.SetActive(true);
    }

    void Btn3 () 
    {
        cylinder.SetActive(true);
    }

    void Btn4 () 
    {
        capsule.SetActive(true);
    }
}
