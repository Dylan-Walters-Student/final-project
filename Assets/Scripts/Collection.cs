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
    bool hasPiece;
    bool coneCollected;
    bool cubeCollected;
    bool chuteActive = true;
    bool platformActive = true;
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
            if (other.tag.Equals("BlueChute"))
            {
                if (chuteActive/*player station is active*/)
                {
                    //player collect
                    AddGamePiece(1);
                }
            }
            if (other.tag.Equals("BluePlatform"))
            {
                if (platformActive)
                {
                    AddGamePiece(1);
                }
            }
        }
        else
        {
            if (other.tag.Equals("RedChute"))
            {
                if (chuteActive)
                {
                    AddGamePiece(1);
                }
            }
            if (other.tag.Equals("RedPlatform"))
            {
                if (platformActive)
                {
                    AddGamePiece(1);
                }
            }
            if (other.tag.Equals("BlueChute"))
            {
                if (chuteActive/*player station is active*/)
                {
                    //player collect
                    AddGamePiece(1);
                }
            }
            if (other.tag.Equals("BluePlatform"))
            {
                if (platformActive)
                {
                    AddGamePiece(1);
                }
            }
        }
    }

    private void FieldCollection(Collider2D other)
    {
        if (other.tag.Equals("Cone"))
        {
            if (!hasPiece)
            {
                Destroy(other.gameObject);
                AddGamePiece(1);
                coneCollected = true;
            }
        }

        if (other.tag.Equals("Cube"))
        {
            if (!hasPiece)
            {
                Destroy(other.gameObject);
                AddGamePiece(2);
                cubeCollected = true;
            }
        }
    }

    public void AddGamePiece(int status)
    {
        if (status == 1)
        {
            spriteRendererCone.color = hasCone;
            coneCollected = true;
            hasPiece = true;
        }
        else if (status == 2)
        {
            spriteRendererCube.color = hasCube;
            cubeCollected = true;
            hasPiece = true;
        }
        else
        {
            spriteRendererCube.color = noGamePiece;
            spriteRendererCone.color = noGamePiece;
            RemoveGamePiece();
        }
        scoring.SetPieceStatus(hasPiece);
    }

    private void RemoveGamePiece()
    {
        cubeCollected = false;
        coneCollected = false;
        hasPiece = false;
        scoring.SetPieceStatus(!hasPiece);
    }
}
