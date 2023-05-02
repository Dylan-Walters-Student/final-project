using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    bool gpCollected = false;
    // float collectionSpeed = 5f;
    [SerializeField] Color32 hasCone = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasCube = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noGamePiece = new Color32(1, 1, 1, 1);
    [SerializeField] GameObject coneCollect;
    [SerializeField] GameObject cubeCollect;
    SpriteRenderer spriteRendererCone;
    SpriteRenderer spriteRendererCube;
    private void Start()
    {
        spriteRendererCone = coneCollect.GetComponent<SpriteRenderer>();
        spriteRendererCube = cubeCollect.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cone")
        {
            if (!gpCollected)
            {
                gpCollected = true;
                Destroy(other.gameObject, 5f);
                Wait(5f);
                spriteRendererCone.color = hasCone;
            }
        }

        if (other.tag == "Cube")
        {
            if (!gpCollected)
            {
                gpCollected = true;
                Destroy(other.gameObject, 5f);
                Wait(5f);
                spriteRendererCube.color = hasCube;
            }
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
