using UnityEngine;
using System;

public class TogglePlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;

    private Transform target;   // hacia dónde se mueve
    private bool isMoving = false;

    public bool IsMoving => isMoving;

    public Action OnPlatformStopped;

    private void Start()
    {
        // La plataforma arranca en A
        transform.position = pointA.position;
        target = pointB;
    }

    private void Update()
    {
        if (!isMoving) return;

        // mover hacia el destino
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

               
        // si llegó al destino, detener movimiento
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            transform.position = target.position; // ajustar exacto
            isMoving = false;
            OnPlatformStopped?.Invoke();
        }
    }

    public void ToggleMove()
    {
        // Si no se está moviendo, cambiar el destino
        if (!isMoving)
        {
            // Si está prácticamente en A, mover a B
            if (Vector3.Distance(transform.position, pointA.position) < 0.05f)
                target = pointB;
            else
                target = pointA;

            isMoving = true;
        }
    }
}