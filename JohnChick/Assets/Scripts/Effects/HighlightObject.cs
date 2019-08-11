using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HighlightObject : MonoBehaviour
{
    public float animationTime = 1f;
    public float threshold = 1.5f;

    private FastAndSlowEffect fastSlowEffect;
    private HighlightController controller;
    private Material material;
    private Color normalColor;
    private Color selectedColor;
    private Color fastColor;
    private Color slowColor;
    
    void Awake()
    {
        material = GetComponent<MeshRenderer>().material;
        fastSlowEffect = GetComponent<FastAndSlowEffect>();

        normalColor = material.color;
        selectedColor = new Color(
            Mathf.Clamp01(normalColor.r * threshold),
            Mathf.Clamp01(normalColor.g * threshold),
            Mathf.Clamp01(normalColor.b * threshold));
        fastColor = new Color(
            Mathf.Clamp01(normalColor.r * (threshold * 2)),
            Mathf.Clamp01(normalColor.g * (threshold * -1 / 2)),
            Mathf.Clamp01(normalColor.b * (threshold * -1)));
        slowColor = new Color(
            Mathf.Clamp01(normalColor.r * (threshold * -1)),
            Mathf.Clamp01(normalColor.g * threshold),
            Mathf.Clamp01(normalColor.b * (threshold * 2)));
        controller = FindObjectOfType<HighlightController>();
    }

    void Update()
    {
        if (fastSlowEffect.timeScale > 0.8)
            FastHighlight();
        if (fastSlowEffect.timeScale < 1.2)
            SlowHighlight();
        if (fastSlowEffect.timeScale <=0.8 && fastSlowEffect.timeScale >=1.2)
            StopHighlight();
        if(tag == "Player")
        {
            StopHighlight();
        }
    }

    public void StartHighlight()
    {
        iTween.ColorTo(gameObject, iTween.Hash(
                "color", selectedColor,
                "time", animationTime,
                "easetype", iTween.EaseType.linear,
                "looptype", iTween.LoopType.pingPong));
    }

    public void StopHighlight()
    {
        iTween.Stop(gameObject);
        material.color = normalColor;
    }

    private void OnMouseOver()
    {
        if (fastSlowEffect.timeScale == 1)
        {
            controller.SelectObj(this);
        }
    }

    private void OnMouseExit()
    {
        StopHighlight();
    }

    public void FastHighlight()
    {
        iTween.ColorTo(gameObject, iTween.Hash(
                "color", fastColor,
                "time", (animationTime * 0.5),
                "easetype", iTween.EaseType.linear,
                "looptype", iTween.LoopType.pingPong));
    }

    public void SlowHighlight()
    {
        iTween.ColorTo(gameObject, iTween.Hash(
                "color", slowColor,
                "time", (animationTime),
                "easetype", iTween.EaseType.linear,
                "looptype", iTween.LoopType.pingPong));
    }

}
