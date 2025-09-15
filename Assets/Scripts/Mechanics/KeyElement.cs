using UnityEngine;
using UnityEngine.Events;

public class KeyElement : MonoBehaviour
{
    [SerializeField] KEY_CODE Code;
    public UnityEvent OnRecolectKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<KeyCodeList>().AddKey(Code);
          gameObject.SetActive(false);
            OnRecolectKey?.Invoke();
        }
    }
}
