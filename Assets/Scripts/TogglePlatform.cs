using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;

    private Transform target;   // hacia dónde se mueve
    private bool isMoving = false;

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
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            transform.position = target.position; // ajustar exacto
            isMoving = false;
        }
    }

    public void ToggleMove()
    {
        // invertir el destino
        target = (target == pointA) ? pointB : pointA;
        isMoving = true;
    }
}