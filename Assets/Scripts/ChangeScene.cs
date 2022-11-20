using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class ChangeScene : MonoBehaviour
{
    VirtualButtonBehaviour vrb;

    // Start is called before the first frame update
    void Start()
    {
        vrb = GetComponentInChildren<VirtualButtonBehaviour>();
        vrb.RegisterOnButtonPressed(onButtonPressed);
        vrb.RegisterOnButtonReleased(onButtonReleased);
    }


    public void onButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Pressed");
    }

    public void onButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Released");
        SceneManager.LoadScene("Slider");
        Debug.Log("Scene Loaded");
    }
}
