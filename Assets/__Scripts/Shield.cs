using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Inscribed")]
    public float rotationsPerSecond = 0.1f;

    [Header("Dynamic")]
    public int levelShown = 0;

    Material mat;

    // a

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        // b
    }

    void Update()
    {
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel); // c
        // If this is different from levelShown...
        if (levelShown != currLevel)
        {
            levelShown = currLevel;

            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0); // d
        }

        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f; // e
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
