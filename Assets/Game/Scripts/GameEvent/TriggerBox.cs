using UnityEngine;
using UnityEngine.Events;
 
public class TriggerBox : MonoBehaviour
{
    // Variable untuk menentukan apakah event 
    // sudah aktif dari awal
    [SerializeField]
    private bool _autoActive;
    // Variable untuk tag dari object yang 
    // akan dideteksi oleh trigger box
    [SerializeField]
    private string _tag;
    // Variable untuk menentukan apakah trigger
    // hanya dijalankan sekali
    [SerializeField]
    private bool _isOneTime;
 
    // Event yang akan dipanggil ketika box ditrigger
    public UnityEvent OnTrigger;
 
    // Variable untuk menentukan status trigger box
    // sedang aktif atau tidak  
    private bool _isActive;
 
    private void Awake()
    {
        // Jika auto active maka ketika game berjalan,
        // status trigger akan menjadi aktif   
        _isActive = _autoActive;
    }
 
    // Function untuk mengubah status aktif trigger   
    public void SetActive(bool value)
    {
        _isActive = value;
    }
 
    // Function untuk mengecek apakah ada object lain
    // yang menembus trigger box
    void OnTriggerEnter(Collider other)
    {
        // Mengecek apakah object yang terdeteksi 
        // menembus trigger box memiliki tag yang sama
        // dengan tag yang ditentukan di variable _tag
        // dan apakah status trigger box sedang aktif
        if (other.CompareTag(_tag) && _isActive == true)
        {
            // Jika ya, maka trigger box akan di-trigger 
            // event OnTrigger akan dipanggil
            OnTrigger?.Invoke();
            // Jika hanya dijalankan satu kali
            if (_isOneTime == true)
            {
                // Maka object trigger akan dihapus
                Destroy(gameObject);
            }
        }
    }
}