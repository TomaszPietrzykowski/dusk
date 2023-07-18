using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    private PlayerUI playerUI;
    private ResourceManager rm;

    // Start is called before the first frame update
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        rm = FindObjectOfType<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // create a ray at the center of the camera shooting outwards
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // variable to store collision data
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if(Input.GetKey(KeyCode.E))
                {
                    if(interactable.promptMessage == "gold")
                    {
                        rm.AddGold(2f);
                        interactable.Remove();
                    }
                }
            }
        }
    }
}
