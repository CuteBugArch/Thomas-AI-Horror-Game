using UnityEngine;

// Serialize class item data supaya variable di dalamnya
// nilai nya bisa ditentukan melalui inspector
[System.Serializable]
public class ItemData 
{
    // Membuat variable untuk menyimpan id item
    public string ID;
    // Membuat variable untuk menyimpan id item
    public string Name;
 
    // Membuat constructor class ItemData untuk mengisi data id dan nama
    public ItemData(string id, string name)
    {
        ID = id;
        Name = name;
    }
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
