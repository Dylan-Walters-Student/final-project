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
    bool chuteActive = true;
    bool platformActive = true;
    private void Start()
    {
        scoring = FindObjectOfType<Scoring>();
        RemoveGamePiece();
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
                GetComponent<AudioSource>().Play();
                spriteRendererCone.color = hasCone;
                hasPiece = true;
        }

        if (other.tag.Equals("Cube") && !hasPiece)
        {
                Destroy(other.gameObject);
                GetComponent<AudioSource>().Play();
                spriteRendererCube.color = hasCube;
                hasPiece = true;
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
        hasPiece = false;
        scoring.SetPieceStatus(!hasPiece);
    }
}
