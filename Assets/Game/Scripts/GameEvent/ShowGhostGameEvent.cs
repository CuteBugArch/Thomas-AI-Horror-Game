using UnityEngine;
 
public class ShowGhostGameEvent : GameEventBase
{
    // Variable untuk reference ke object ghost 
    // yang ingin dimunculkan
    [SerializeField]
    private GameObject _ghostObject;
    // Variable untuk menentukan apakah object ghost
    // dihapus ketika game event selesai
    [SerializeField]
    private bool _isDestroyAfterFinished;
 
    // Override function trigger untuk mengubah
    // perilaku ketika game event di-trigger
    public override void Trigger()
    {
        // Memastikan object ghost ada reference nya
        if (_ghostObject != null)
        {
            // Jika ya, maka object ghost diaktifkan
            // Maka ghost akan muncul
            _ghostObject.SetActive(true);
        }
        // Memanggil function trigger yang ada di class parent 
        // (GameEventBase)
        base.Trigger();
    }
 
    public override void Finish()
    {
        // Memastikan object ghost ada reference nya
        // dan variable _isDestroyAfterFinished bernilai true
        if (_ghostObject != null && _isDestroyAfterFinished == true)
        {
            // Jika ya object ghost dihapus
            Destroy(_ghostObject);
        }
        // Memanggil function finish yang ada di class parent 
        // (GameEventBase)
        base.Finish();
    }
}