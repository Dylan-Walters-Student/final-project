using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    bool gpCollected;
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
                SetGamePieceShow("Cone");
            }
        }

        if (other.tag == "Cube")
        {
            if (!gpCollected)
            {
                Destroy(other.gameObject);
                SetGamePieceShow("Cube");
            }
        }
    }

    public void SetGamePieceShow(string piece)
    {
        Debug.Log(piece);
        if (piece.Equals("Cone"))
        {
            spriteRendererCone.color = hasCone;
            gpCollected = true;
        }

        if (piece.Equals("Cube"))
        {
            spriteRendererCube.color = hasCube;
            gpCollected = true;
        }

        if (piece.Equals("None"))
        {
            spriteRendererCube.color = noGamePiece;
            spriteRendererCone.color = noGamePiece;
            gpCollected = false;
        }
    }
}
