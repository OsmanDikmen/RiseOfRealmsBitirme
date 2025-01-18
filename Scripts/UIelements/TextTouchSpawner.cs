using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TextTouchSpawner : NetworkBehaviour
{
    public ObjectActivator spawner; // Spawner script'ini bağlamak için referans

    private void Update()
    {
        // Dokunma var mı kontrol edelim
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Ekrana ilk dokunulduğunda (TouchPhase.Began) işlem yapalım
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log($"Ray hit: {hit.collider.gameObject.name}");

                    // Eğer dokunulan obje bu script'in bağlı olduğu obje ise
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("TextMesh Pro tıklandı (Touch)!");
                        spawner.ActivatePrefab1Object(); // Prefab oluşturma fonksiyonunu çağır
                    }
                }
            }
        }

        // Dilerseniz bilgisayarda test için aşağıdaki mouse kontrolünü de bırakabilirsiniz:
        /*
        if (Input.GetMouseButtonDown(0)) // Sol fare tıklaması
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Ray hit: {hit.collider.gameObject.name}");
                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    Debug.Log("TextMesh Pro tıklandı (Mouse)!");
                    spawner.SpawnPrefab1();
                }
            }
        }
        */
    }
}
