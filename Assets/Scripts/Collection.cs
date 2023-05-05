using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    // float collectionSpeed = 5f;
    [SerializeField] Color32 hasCone = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasCube = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noGamePiece = new Color32(1, 1, 1, 1);
    [SerializeField] GameObject coneCollect;
    [SerializeField] GameObject cubeCollect;
    SpriteRenderer spriteRendererCone;
    SpriteRenderer spriteRendererCube;
    Scoring scoring;
    bool gpCollected;
    bool coneCollected;
    bool cubeCollected;
    private void Start()
    {
        scoring = FindObjectOfType<Scoring>();
        spriteRendererCone = coneCollect.GetComponent<SpriteRenderer>();
        spriteRendererCube = cubeCollect.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        FieldCollection(other);
        HumanPlayerCollection(other);
    }

    private void HumanPlayerCollection(Collider2D other)
    {
        if (scoring.GetAlliance())
        {
            if (other.tag.Equals("RedChute"))
            {
                // if (/*player station is active*/)
                // {
                //     //player collect
                // }
                Debug.Log("red chute");
            }
            if (other.tag.Equals("RedPlatform"))
            {
                Debug.Log("red platform");
            }
        }
        else
        {
            if (other.tag.Equals("BlueChute"))
            {
                Debug.Log("blue chute");
            }
            if (other.tag.Equals("BluePlatform"))
            {
                Debug.Log("blue platform");
            }
        }
    }

    private void FieldCollection(Collider2D other)
    {
        if (other.tag.Equals("Cone"))
        {
            if (!gpCollected)
            {
                Destroy(other.gameObject);
                SetGamePieceShow("Cone");
                coneCollected = true;
            }
        }

        if (other.tag.Equals("Cube"))
        {
            if (!gpCollected)
            {
                Destroy(other.gameObject);
                SetGamePieceShow("Cube");
                cubeCollected = true;
            }
        }
    }

    private void CollectedFalse()
    {
        scoring.PieceStatus(3);
        cubeCollected = false;
        coneCollected = false;
        gpCollected = false;
    }

    public void SetGamePieceShow(string piece)
    {
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
            CollectedFalse();
        }
    }

    public int GetCollected()
    {
        if (coneCollected)
        {
            return 1;
        }
        else if (cubeCollected)
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}
