using UnityEngine;
using System.Collections;

public class BlinkLightScript : MonoBehaviour {

    public Light pointLight;
    public bool blink = false;
    public float deltaTime = 0.3f;
    public int numberOfBlinks = 3;
    public float minColorEmission = 0.05f;
    public float minLightIntensity = 0;
    public float maxColorEmission = 0.3f;
    public float maxLightIntensity = 1;

    public bool isOn = true;


    private Renderer renderer;
    private Material material;

    private bool enlighten = false;
    private bool longLight = false;
    private int counter = 0;
    private float timer = 0;


    // Use this for initialization
    void Start () {
        renderer = GetComponent<Renderer>();
        material = renderer.sharedMaterial;

        //can be set in the inspector
        material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

        if (!blink)
        {
            pointLight.intensity = 1;
            material.SetColor("_EmissionColor", new Color(maxColorEmission, 0, 0));
            RendererExtensions.UpdateGIMaterials(renderer);
            DynamicGI.UpdateEnvironment();
        }
       
    }

    public void TurnOn()
    {
        isOn = true;
        pointLight.intensity = 1;
        material.SetColor("_EmissionColor", new Color(maxColorEmission, 0, 0));
        RendererExtensions.UpdateGIMaterials(renderer);
        DynamicGI.UpdateEnvironment();

    }

    public void TurnOff()
    {
        isOn = false;
        pointLight.intensity = minLightIntensity;
        material.SetColor("_EmissionColor", new Color(minColorEmission, 0, 0));
        RendererExtensions.UpdateGIMaterials(renderer);
        DynamicGI.UpdateEnvironment();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isOn)
        {
            return;
        }

        if (blink)
        {
            timer += Time.deltaTime;
            if (timer >= deltaTime)
            {
                timer = 0;
                counter++;
                if (counter == numberOfBlinks)
                {
                    pointLight.intensity = maxLightIntensity;
                    material.SetColor("_EmissionColor", new Color(maxColorEmission, 0, 0));
                }
                if (counter > 20)
                {
                    counter = 0;
                }
                if (counter > 4)
                {
                    return;
                }

                if (enlighten)
                {
                    pointLight.intensity = minLightIntensity;
                    material.SetColor("_EmissionColor", new Color(minColorEmission, 0, 0));
                }
                else
                {
                    pointLight.intensity = maxLightIntensity;
                    material.SetColor("_EmissionColor", new Color(maxColorEmission, 0, 0));
                }
                enlighten = !enlighten;
                RendererExtensions.UpdateGIMaterials(renderer);
                DynamicGI.UpdateEnvironment();
            }
        }
        
      

        
    }
}
