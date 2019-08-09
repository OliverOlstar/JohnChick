using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    private HighlightObject highlightObj;

    public void SelectObj(HighlightObject pHighlightObj)
    {
        if(highlightObj != null)
        {
            highlightObj.StopHighlight();
        }
        highlightObj = pHighlightObj;
        highlightObj.StartHighlight();

    }

}
