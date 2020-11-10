using System;
using UnityEngine;
using UnityEngine.UI;


public class ToggleLayer : MonoBehaviour
{

    [SerializeField]
    string layerName;

    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    public void UpdateCameraLayers()
    {
        int layerValue = LayerMask.NameToLayer(layerName);
        int layerShiftedValue = 1 << layerValue;
        string layerBinPosition = Convert.ToString(layerShiftedValue, 2);
        string cameraMaskBinValue = Convert.ToString(mainCamera.cullingMask, 2);

        GameObject.Find("LabelTitle1").GetComponent<Text>().text = "Current camera binary mask:";
        GameObject.Find("LabelTitle1_value").GetComponent<Text>().text = cameraMaskBinValue;




        if (GetComponent<Toggle>().isOn)
        {
            //Bitwise OR "|"
            mainCamera.cullingMask = mainCamera.cullingMask | layerShiftedValue;

            //Simplified version:
            //mainCamera.cullingMask |= layerShiftedValue;

            GameObject.Find("LabelTitle2").GetComponent<Text>().text = $"Adding (+) {layerName} layer:";
        }
        else
        {
            //Bitwise AND "&"
            //Bitwise NOT "~"
            mainCamera.cullingMask = mainCamera.cullingMask & ~(layerShiftedValue);

            //Simplified version:
            //mainCamera.cullingMask &= ~(layerShiftedValue);

            GameObject.Find("LabelTitle2").GetComponent<Text>().text = $"Subtracting (-) {layerName} layer:";
        }

        GameObject.Find("LabelTitle2_value").GetComponent<Text>().text = layerBinPosition;

        cameraMaskBinValue = Convert.ToString(mainCamera.cullingMask, 2);
      

        GameObject.Find("LabelTitle3").GetComponent<Text>().text = "New camera binary mask:";
        GameObject.Find("LabelTitle3_value").GetComponent<Text>().text = cameraMaskBinValue;
    }
}
