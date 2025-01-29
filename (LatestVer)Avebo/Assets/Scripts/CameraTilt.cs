using UnityEngine;

public class CameraTilt : MonoBehaviour
{
    public Transform cameraTransform; // Kamerayý referans al
    public float tiltAngle = 15f; // Eðilme açýsý
    public float tiltSpeed = 5f; // Eðilme hýzý

    private float targetTiltX = 0f; // Hedef eðilme açýsý X ekseninde
    private float targetTiltY = 0f; // Hedef eðilme açýsý Y ekseninde
    private float currentTiltX = 0f; // Mevcut eðilme açýsý X ekseninde
    private float currentTiltY = 0f; // Mevcut eðilme açýsý Y ekseninde

    void Update()
    {
        // X ekseni kontrolü
        if (Input.GetKey(KeyCode.W))
        {
            targetTiltX = tiltAngle; // Sola eð
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetTiltX = -tiltAngle; // Saða eð
        }
        else
        {
            targetTiltX = 0f; // Eski haline dön
        }

        // Y ekseni kontrolü
        if (Input.GetKey(KeyCode.D))
        {
            targetTiltY = -tiltAngle; // Yukarý eð
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetTiltY = tiltAngle; // Aþaðý eð
        }
        else
        {
            targetTiltY = 0f; // Eski haline dön
        }

        // Mevcut eðilme açýsýný yumuþak geçiþle güncelle
        currentTiltX = Mathf.Lerp(currentTiltX, targetTiltX, Time.deltaTime * tiltSpeed);
        currentTiltY = Mathf.Lerp(currentTiltY, targetTiltY, Time.deltaTime * tiltSpeed);

        // Kamerayý eð
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(currentTiltX, currentTiltY, 0f);
        }
    }
}
