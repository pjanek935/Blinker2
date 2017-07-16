using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkImage : MonoBehaviour {

    private Color defaultColor;
    private float prevFillAmount = 1;
    private Image image;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        defaultColor = image.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (image.color != defaultColor)
        {
            Color diffColor = defaultColor - image.color;
            diffColor *= 0.02f;
            Color color = image.color;
            color += diffColor;
            image.color = color;
        }

        if (prevFillAmount < 0.33f && image.fillAmount >= 0.33f)
            BlinkBlue();
        if (prevFillAmount < 0.67f && image.fillAmount >= 0.67f)
            BlinkBlue();
        if (prevFillAmount < 1f && image.fillAmount == 1f)
            BlinkBlue();

        prevFillAmount = image.fillAmount;
    }

    public void BlinkRed()
    {
        Color red = new Color(1, 0, 0, defaultColor.a);
        image.color = red;
    }

    public void BlinkBlue()
    {
        Color red = new Color(22/255f, 22/255f, 1, defaultColor.a);
        image.color = red;
    }
}
