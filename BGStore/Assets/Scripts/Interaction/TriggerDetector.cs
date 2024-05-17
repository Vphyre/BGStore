using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField] private string _targetTag;
    public UnityEvent OnTriggerEnter;
    public UnityEvent OnTriggerStay;
    public UnityEvent OnTriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_targetTag))
        {
            OnTriggerEnter.Invoke();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_targetTag))
        {
            OnTriggerStay.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(_targetTag))
        {
            OnTriggerExit.Invoke();
        }
    }
}
