using UnityEngine;
using UnityEngine.Events;


public class UnlockElement : MonoBehaviour
{
    [SerializeField] KEY_CODE Code;

    public UnityEvent OnElementUnlock;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<KeyCodeList>().KeyCodes.Contains(Code))
            {
                OnElementUnlock?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}