using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

}
