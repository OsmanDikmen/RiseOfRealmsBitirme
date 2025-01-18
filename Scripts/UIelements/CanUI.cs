using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanUI : MonoBehaviour
{
    private SHealth sHealth;


    // Bu bir 3D Text veya UI TextMeshPro olabilir. Inspector’da atayýn.
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private winLoseActive winLoseActive;

    private void Awake()
    {
        // Ayný GameObject üzerindeki SHealth component’ini bulalým
        sHealth = GetComponent<SHealth>();

        // SHealth script’i yoksa uyarý verelim
        if (sHealth == null)
        {
            Debug.LogError("Bu GameObject'te SHealth component'i bulunamadý.");
        }
    }

    private void Update()
    {

        // SHealth script'inden healthPoints deðerini alýp text'e basýyoruz
        if (sHealth != null && textMesh != null)
        {
            textMesh.text = sHealth.healthPoints.ToString();
        }
        if (sHealth.healthPoints <= 20)
        {
            Debug.Log("LoseX");
            if (CompareTag("CasttleEnemy"))
            {
                winLoseActive.Win();
                Debug.Log("Lose");
            }else if (CompareTag("CasttleMe"))
            {
                winLoseActive.Lose();
                Debug.Log("Lose");
            }
        }
        
    }
}
