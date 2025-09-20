using UnityEngine;
using Cinemachine;
using Platformer.Mechanics;

public class CameraLookAhead : MonoBehaviour
{
    public PlayerController player;          // referencia directa al PlayerController
    public CinemachineVirtualCamera vcam;    // referencia a la c�mara virtual
    public float lookAheadDistance = 2f;     // cu�nto se adelanta
    public float smoothTime = 0.2f;          // suavizado

    private CinemachineCameraOffset camOffset;
    private float currentOffsetX;
    private float targetOffsetX;
    private float velocity;

    void Start()
    {
        if (vcam != null)
            camOffset = vcam.GetComponent<CinemachineCameraOffset>();

        if (camOffset == null)
            Debug.LogError("No se encontr� CinemachineCameraOffset en la c�mara virtual.");
    }

    void Update()
    {
        if (player == null || camOffset == null) return;

        // Usamos el spriteRenderer del player para determinar la direcci�n
        float direction = player.GetComponent<SpriteRenderer>().flipX ? -1f : 1f;

        // Calculamos la posici�n deseada
        targetOffsetX = direction * lookAheadDistance;

        // Suavizamos el movimiento de la c�mara
        currentOffsetX = Mathf.SmoothDamp(currentOffsetX, targetOffsetX, ref velocity, smoothTime);

        // Aplicamos el offset a la c�mara
        camOffset.m_Offset = new Vector3(currentOffsetX, camOffset.m_Offset.y, camOffset.m_Offset.z);
    }
}