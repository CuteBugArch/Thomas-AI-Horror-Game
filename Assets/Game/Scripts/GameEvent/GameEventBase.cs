using UnityEngine;
using UnityEngine.Events;
 
public class GameEventBase : MonoBehaviour
{
    // Variable untuk menentukan id game event
    [SerializeField]
    private string _id;
    // Variable untuk menentukan apakah game event
    // hanya akan berjalan satu kali
    [SerializeField]
    private bool _isOneTime;
 
    // Membuat event yang akan dipanggil 
    // ketika game event dijalankan
    public UnityEvent OnEventTriggered;
    // Membuat event yang akan dipanggil 
    // ketika game event dihentikan
    public UnityEvent OnEventFinished;
 
    // Property untuk mengakses variable _id
    public string ID => _id;
 
    public void Start()
    {
        // Register game event ini ketika game dimulai
        GameEventManager.Instance.Register(this);
    }
 
    // Function untuk menjalankan event
    // function dibuat virtual karena setiap child
    // dari class GameEventBased punya 
    // perilaku yang berbeda ketika ditrigger
    public virtual void Trigger()
    {
        // Memanggil event OnEventFinished
        // ketika event dijalankan
        OnEventTriggered?.Invoke();
    }
 
    // Function untuk menghentikan event
    // function dibuat virtual karena setiap child
    // dari class GameEventBased punya 
    // perilaku yang berbeda ketika berhenti
    public virtual void Finish()
    {
        // Memanggil event OnEventFinished 
        // ketika event berhenti
        OnEventFinished?.Invoke();
 
        // Mengecek apakah event hanya dijalankan sekali
        if (_isOneTime == true)
        {
            // Jika ya,
            // Unregister game event ini
            GameEventManager.Instance.Unregister(this);
            // Hapus game object game event
            Destroy(gameObject);
        }
    }
}