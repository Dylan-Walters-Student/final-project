using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // float collectionSpeed = 5f;
    [SerializeField] Color32 hasCone = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasCube = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noGamePiece = new Color32(1, 1, 1, 1);
    [SerializeField] SpriteRenderer spriteRendererCone;
    [SerializeField] SpriteRenderer spriteRendererCube;
    Scoring scoring;
    bool hasPiece;
    bool coneCollected;
    bool cubeCollected;
    bool chuteActive = true;
    bool platformActive = true;
    private void Start()
    {
        scoring = FindObjectOfType<Scoring>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        FieldCollection(other);
        HumanPlayerCollection(other);
    }

    private void FieldCollection(Collider2D other)
    {
        if (other.tag.Equals("Cone") && !hasPiece)
        {
                Destroy(other.gameObject);
                spriteRendererCone.color = hasCone;
                hasPiece = true;
                coneCollected = true;
        }

        if (other.tag.Equals("Cube") && !hasPiece)
        {
                Destroy(other.gameObject);
                spriteRendererCube.color = hasCube;
                hasPiece = true;
                cubeCollected = true;
        }
        scoring.SetPieceStatus(hasPiece);
    }

    private void HumanPlayerCollection(Collider2D other)
    {
        if (other.tag.Equals("BlueChute"))
        {
            if (chuteActive && !hasPiece)
            {
                FieldCollection(other);
            }
        }
        if (other.tag.Equals("BluePlatform"))
        {
            if (platformActive && !hasPiece)
            {
                FieldCollection(other);
            }
        }
    }

    public void RemoveGamePiece()
    {
        spriteRendererCube.color = noGamePiece;
        spriteRendererCone.color = noGamePiece;
        cubeCollected = false;
        coneCollected = false;
        hasPiece = false;
        scoring.SetPieceStatus(!hasPiece);
    }
}
