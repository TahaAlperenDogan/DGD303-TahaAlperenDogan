using UnityEngine;

public class CameraTilt : MonoBehaviour
{
    public Transform cameraTransform; // Kameray� referans al
    public float tiltAngle = 15f; // E�ilme a��s�
    public float tiltSpeed = 5f; // E�ilme h�z�

    private float targetTiltX = 0f; // Hedef e�ilme a��s� X ekseninde
    private float targetTiltY = 0f; // Hedef e�ilme a��s� Y ekseninde
    private float currentTiltX = 0f; // Mevcut e�ilme a��s� X ekseninde
    private float currentTiltY = 0f; // Mevcut e�ilme a��s� Y ekseninde

    void Update()
    {
        // X ekseni kontrol�
        if (Input.GetKey(KeyCode.W))
        {
            targetTiltX = tiltAngle; // Sola e�
        }
        else if (Input.GetKey(KeyCode.S))
        {
            targetTiltX = -tiltAngle; // Sa�a e�
        }
        else
        {
            targetTiltX = 0f; // Eski haline d�n
        }

        // Y ekseni kontrol�
        if (Input.GetKey(KeyCode.D))
        {
            targetTiltY = -tiltAngle; // Yukar� e�
        }
        else if (Input.GetKey(KeyCode.A))
        {
            targetTiltY = tiltAngle; // A�a�� e�
        }
        else
        {
            targetTiltY = 0f; // Eski haline d�n
        }

        // Mevcut e�ilme a��s�n� yumu�ak ge�i�le g�ncelle
        currentTiltX = Mathf.Lerp(currentTiltX, targetTiltX, Time.deltaTime * tiltSpeed);
        currentTiltY = Mathf.Lerp(currentTiltY, targetTiltY, Time.deltaTime * tiltSpeed);

        // Kameray� e�
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(currentTiltX, currentTiltY, 0f);
        }
    }
}
