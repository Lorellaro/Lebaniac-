using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoveFontAliasing : MonoBehaviour
{
    [SerializeField] Font font;
    [SerializeField] TMP_FontAsset font1;

    // Start is called before the first frame update
    void Start()
    {
        font.material.mainTexture.filterMode = FilterMode.Point;
        font1.material.mainTexture.filterMode = FilterMode.Point;
    }
}
