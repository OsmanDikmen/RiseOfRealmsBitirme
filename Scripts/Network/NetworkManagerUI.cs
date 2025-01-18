using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;  // UI butonları için

public class NetworkManagerUI : MonoBehaviour
{
    public Button hostButton;  // Host başlatan buton
    public Button clientButton;  // Client başlatan buton

    private void Awake()
    {
        // Butonlara event listener ekleyin
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);

        // Eğer oyun başlatıldığında otomatik olarak bir host veya client başlatmak istiyorsanız, bu da yapılabilir.
        // Örneğin, bir koşul ekleyip buna göre başlatma işlemi yapılabilir.
    }

    // Host başlatma
    private void StartHost()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("Host başlatıldı.");
           //StartCoroutine(DisableCoroutine(1f));
        }
    }

    // Client başlatma
    private void StartClient()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartClient();
            Debug.Log("Client bağlanıyor...");
        }
    }

    
}
