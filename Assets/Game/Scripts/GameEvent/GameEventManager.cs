using System.Collections.Generic;
using UnityEngine;
 
public class GameEventManager : MonoBehaviour
{
    // Variable dictionary untuk menyimpan semua game event
    // key -> string id dari game event
    // value -> game event
    private Dictionary<string, GameEventBase> _gameEvents = new Dictionary<string, GameEventBase>();

    // Variable untuk menyimpan reference  
    // instance/object GameEventManager
    // variable ini akan disimpan diaplikasi game
    // dan akan tetap ada selama game nya berjalan
    private static GameEventManager _instance;
 
    // Property untuk mengakses variable _instance
    public static GameEventManager Instance => _instance;

 
    // Function untuk melakukan register(menambahkan) game event
    // Game event yang akan di-register
    // dimasukkan melalui parameter
    public void Register(GameEventBase gameEvent)
    {
        // Memastikan di dalam dictionary belum ada id dari 
        // game event yang ingin didaftarkan 
        if (_gameEvents.ContainsKey(gameEvent.ID) == false)
        {
            // Jika belum ada, maka tambahkan game event
            // ke dalam dictionary _gameEvents
            _gameEvents.Add(gameEvent.ID, gameEvent);
        }
    }
 
    // Function untuk melakukan unregister(menghapus) game event
    // Game event yang akan di-unregister
    // dimasukkan melalui parameter
    public void Unregister(GameEventBase gameEvent)
    {
        // Memastikan di dalam dictionary ada 
        // game event dengan id daro game event 
        // yang ingin didaftarkan
        if (_gameEvents.ContainsKey(gameEvent.ID) == true)
        {
            // Jika ada, maka hapus game event dengan id yang sama
            // dari dalam dictionary _gameEvents
            _gameEvents.Remove(gameEvent.ID);
        }
    }
 
    // Function untuk trigger event dengan id 
    // yang ditentukan dari parameter
    public void TriggerEvent(string id)
    {
        // Mengecek apakah di dalam dictionary ada game event
        // dengan id yang ditentukan dari parameter. Jika ada
        // game event aka di-output melalui parameter gameEvent
        bool isGameEventFound = _gameEvents.TryGetValue(id, out GameEventBase gameEvent);
        if (isGameEventFound == true)
        {
            // Jika ada, function trigger dari game event
            // yang diambil akan dipanggil
            gameEvent.Trigger();
        }
    }
 
    // Function untuk finish event dengan id 
    // yang ditentukan dari parameter
    public void FinishEvent(string id)
    {
        // Mengecek apakah di dalam dictionary ada game event
        // dengan id yang ditentukan dari parameter. Jika ada
        // game event aka di-output melalui parameter gameEvent
        bool isGameEventFound = _gameEvents.TryGetValue(id, out GameEventBase gameEvent);
        if (isGameEventFound == true)
        {
            // Jika ada, function finish dari game event 
            // yang diambil akan dipanggil
            gameEvent.Finish();
        }
    }

    private void Awake()
    {
        // Ketika game dimulai, mengecek apakah variable _instance
        // sudah ada reference ke object GameEventManager?
        // ingat variable static akan disimpan di dalam game state
        // jadi variable nya sharing dengan object GameEventManager lainnya
        // Jika sudah ada, artinya sudah ada object GameEventManager
        // di scene. Hapus object ini supaya tidak ada lebih dari satu
        // GameEventManager
        if (_instance != null)
        {
            // Jika _instance sudah ada reference ke object GameEventManager
            // Hapus game object ini
            Destroy(gameObject);
            // Keluar dari function awake
            return;
        }
 
        // Tapi jika belum ada, maka isi variable dengan reference 
        // ke object ini
        _instance = this;
    }
}