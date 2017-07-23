using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingLampAction : SwitchAction {

    public GameObject cilinder;
    public Light light;

    private bool isOn = true;

    public override void Action()
    {
        if (isOn)
            TurnOff();
        else
            TurnOn();
    }

    void TurnOn()
    {
        isOn = true;
        Renderer renderer = cilinder.GetComponent<Renderer>();
        Material mat = renderer.material;
        mat.SetColor("_EmissionColor", Color.white);
        light.intensity = 8;
    }

    void TurnOff()
    {
        isOn = false;
        Renderer renderer = cilinder.GetComponent<Renderer>();
        Material mat = renderer.material;
        mat.SetColor("_EmissionColor", Color.black);
        light.intensity = 0;
    }
}
