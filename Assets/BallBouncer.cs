using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject Platformprefab;
    public int numPlatform = 3;
    public float PlatformBottomY = -14f;
    public float PlatformSpacingY = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numPlatform; i++)
        {
            GameObject tPlatformGO = Instantiate<GameObject>(Platformprefab);
            Vector3 pos = Vector3.zero;
            pos.y = PlatformBottomY + (i * PlatformSpacingY);
            tPlatformGO.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
