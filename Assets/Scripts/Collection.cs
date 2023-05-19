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
    private void Start()
    {
        scoring = FindObjectOfType<Scoring>();
        RemoveGamePiece();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        FieldCollection(other);
    }

    private void FieldCollection(Collider2D other)
    {
        if (other.tag.Equals("Cone") && !StaticHelper.hasPiece)
        {
                Destroy(other.gameObject);
                spriteRendererCone.color = hasCone;
                StaticHelper.hasPiece = true;
        }

        if (other.tag.Equals("Cube") && !StaticHelper.hasPiece)
        {
                Destroy(other.gameObject);
                spriteRendererCube.color = hasCube;
                StaticHelper.hasPiece = true;
        }

        if (other.tag.Equals("BlueChute") && !StaticHelper.hasPiece || other.tag.Equals("BluePlatform") && !StaticHelper.hasPiece)
        {
            if (Random.value > 0.5)
            {
                spriteRendererCone.color = hasCone;
            }
            else 
            {
                spriteRendererCube.color = hasCube;
            }
            StaticHelper.hasPiece = true;
        }
    }

    public void RemoveGamePiece()
    {
        spriteRendererCube.color = noGamePiece;
        spriteRendererCone.color = noGamePiece;
        StaticHelper.hasPiece = false;
    }
}
