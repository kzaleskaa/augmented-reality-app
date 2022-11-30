using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;
using TMPro;

public class changeModels : MonoBehaviour
{
    VirtualButtonBehaviour[] virtualButtonBehaviours;
    string virtualButtonName;
    int numberOfPlace;
    string[] models = new string[] { "Italy", "Norway", "Spain", "Greece"};
    string[] welcomeMsg = new string[] { "Bongiorno in Italia", "Velkommen til Norge", "Bienvenido a España", "Καλώς ήρθατε στην Ελλάδα" };
    public GameObject informationPanel, videoPanel;
    public GameObject placeVideoPanel, placeInformationPanel;
    public GameObject flagMaterial, welcomeText;

    void Start()
    {
        numberOfPlace = 0;
        Debug.Log(models[numberOfPlace]);
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            virtualButtonBehaviours[i].RegisterOnButtonPressed(onButtonPressed);
        }
    }

    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        virtualButtonName = vb.VirtualButtonName;

        if(virtualButtonName == "VirtualButtonChange") {
            VirtualButtonChange();
            ChangePlace();
            Debug.Log("Button Pressed - Change");
        } else if(virtualButtonName == "VirtualButtonInfo") {
            VirtualButtonInfo();
            Debug.Log("Button Pressed - Info");
        } else if(virtualButtonName == "VirtualButtonVideo") {
            VirtualButtonVideo();
            Debug.Log("Button Pressed - Video");
        }
    }

    void VirtualButtonChange()
    {
        if (numberOfPlace == models.Length - 1)
            numberOfPlace = 0;
        else
            numberOfPlace++;
    }

    void VirtualButtonInfo()
    {
        placeVideoPanel.SetActive(false);
        // update panelInfo flag materialAssets/Resources/Flags/Materials/Spain.mat
        placeInformationPanel.SetActive(true);
    }

    void VirtualButtonVideo()
    {
        placeInformationPanel.SetActive(false);
        placeVideoPanel.SetActive(true);
    }

    void ChangePlace() {
        flagMaterial.GetComponent<Renderer>().material = Resources.Load("Flags/Materials/" + models[numberOfPlace], typeof(Material)) as Material;
        // update background image
        placeInformationPanel.GetComponent<Renderer>().material = Resources.Load("Borders/" + models[numberOfPlace], typeof(Material)) as Material;
        // update text
        welcomeText.GetComponent<TextMeshPro>().text = welcomeMsg[numberOfPlace];
        placeVideoPanel.GetComponent<VideoPlayer>().clip = (VideoClip)Resources.Load(models[numberOfPlace]); 
    }
}
