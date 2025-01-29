using UnityEngine;

public class HoverPopup : MonoBehaviour
{
    public GameObject popupPanel; // Panel GameObject'i buraya atanacak

    public void ShowPopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(true); // Paneli görünür yap
        }
    }

    public void HidePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false); // Paneli gizle
        }
    }
}
