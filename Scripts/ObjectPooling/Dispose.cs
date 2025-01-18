using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispose : MonoBehaviour
{
    public void OnbtnDown()
    {
        // 1 saniye bekle ve ard�ndan nesneyi devre d��� b�rak
        StartCoroutine(DisableObjectAfterDelay(1f));
    }

    private System.Collections.IEnumerator DisableObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
