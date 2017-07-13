using UnityEngine;
using System.Collections;

public class ThrowingScript : MonoBehaviour {

    public Transform katanaTransform;
    public ThrowThisScript katanaScript;
    public MeshRenderer katanaMesh;

    private AnimationManagerScript animManager;
    private BlinkingScript blinkingScript;
    private FPSMovementScript fpsMovementScript;

    private bool throwing = false;

    public bool IsThrown()
    {
        return katanaScript.getIsThrown();
    }

    public void PickUp()
    {
        katanaScript.PickUp();
        throwing = false;
        katanaMesh.enabled = true;
        animManager.Normal();
    }

    public void Throw()
    {
        katanaMesh.enabled = false;
        katanaScript.ThrowThis();
        throwing = false;
    }

    

    public bool isThrowing()
    {
        return throwing;
    }

    // Use this for initialization
    void Start () {
        animManager = GetComponent<AnimationManagerScript>();
        blinkingScript = GetComponent<BlinkingScript>();
        fpsMovementScript = GetComponent<FPSMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !katanaScript.getIsThrown())
        {
            throwing = true;
            animManager.Throw();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && katanaScript.getIsThrown())
        {
            float d = Vector3.Distance(katanaTransform.position, transform.position);
            if (d < 10)
            {
                PickUp();
            }
            else
            {
                blinkingScript.BlinkToKatana(katanaTransform);
                katanaScript.Freeze();
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Katana" && IsThrown())
            PickUp();
    }
}
