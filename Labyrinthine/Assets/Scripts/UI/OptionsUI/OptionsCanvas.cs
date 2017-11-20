using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvas : MonoBehaviour
{
    
    

    private void Awake()
    {
        
    }

    public void InstantiateCanvas()
    {
        GameObject newCanvas = new GameObject("OptionCanvasTest");
        Canvas c = newCanvas.AddComponent<Canvas>();

        c.renderMode = RenderMode.ScreenSpaceCamera;
        newCanvas.AddComponent<CanvasScaler>();
        newCanvas.AddComponent<GraphicRaycaster>();

        GameObject goPanel = new GameObject("PanelTest");
        goPanel.AddComponent<CanvasRenderer>();

        goPanel.transform.SetParent(newCanvas.transform, false);
        
    }
}
