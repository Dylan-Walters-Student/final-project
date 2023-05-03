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
                Destroy(other.gameObject);
                Appear("Cone");
            }
        }

        if (other.tag == "Cube")
        {
            if (!gpCollected)
            {
                Destroy(other.gameObject);
                Appear("Cube");
            }
        }
    }

    private void Appear(string piece)
    {
        // yield return new WaitForSeconds(5f);
        gpCollected = true;
        if (piece.Equals("Cone")){
             spriteRendererCone.color = hasCone;
        } 

        if (piece.Equals("Cube"))
        {
            spriteRendererCube.color = hasCube;
        }
    }
}
