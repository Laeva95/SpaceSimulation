using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetError : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DestroySelf());
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
