using UnityEngine; 
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GameInputAction; 

public class InputManager : MonoBehaviour, IPlayerActions 
{
    // Membuat event OnMoveInput 
    public UnityEvent<Vector2> OnMoveInput; 
    // Variable untuk menyimpan reference object input action 
    private GameInputAction _inputAction; 
    // Membuat event OnSprintInput 
    public UnityEvent<bool> OnSprintInput; 

    // Membuat event OnInteractInput
    public UnityEvent OnInteractInput;

    // Membuat event OnFlashlightInput
    public UnityEvent OnFlashLightInput;
    
    public void OnFlashLight(InputAction.CallbackContext context)
    {
       // contect.performed digunakan untuk mengecek apakah input ditekan
        if (context.performed)
        {
            // Memunculkan log interact di console  
            // ketika input interact ditekan 
            Debug.Log("Flashlight");
            // Jika input ditekan maka trigger event OnFlashlightInput
            OnFlashLightInput?.Invoke();
        }
    }

    private void Awake() 
    { 
        // Membuat object GameInputAction dan menyimpan reference nya 
        // ke variable _inputAction 
        _inputAction = new GameInputAction(); 
        // Mengaktifkan input action 
        _inputAction.Enable(); 
        // Mengaktifkan action map Player 
        _inputAction.Player.Enable(); 
        // Memberi tahu bahwa kelas ini akan mendeteksi input dari 
        // action map Player 
        _inputAction.Player.SetCallbacks(this); 
    } 
    
    public void OnInteract(InputAction.CallbackContext context) 
    { 
        // contect.performed digunakan untuk mengecek apakah input ditekan 
        if (context.performed) 
        { 
            // Memunculkan log interact di console  
            // ketika input interact ditekan 
            Debug.Log("Interact");
            // contect.performed digunakan untuk mengecek apakah input ditekan
            // Jika input ditekan maka trigger event OnInteractInput
            OnInteractInput?.Invoke();
        } 
    } 
    public void OnMove(InputAction.CallbackContext context) 
    { 
        // context.ReadValue() digunakan untuk membaca nilai input 
        // dengan tipe vector, kemudian dimunculkan pada log di console 
        Debug.Log(context.ReadValue<Vector2>()); 
        // Memanggil on move input ketika input move ditekan dan dilepas 
        // Event akan mengirimkan data arah input 
        OnMoveInput?.Invoke(context.ReadValue<Vector2>()); 
    }

    public void OnSprint(InputAction.CallbackContext context) 
    { 
        // Mengecek apakah input ditekan 
        if (context.performed) 
        { 
            // Jika input ditekan maka trigger event OnSprintInput 
            // Mengirim data true 
            OnSprintInput?.Invoke(true); 
        } 
        // Mengecek apakah input dilepas 
        if (context.canceled) 
        { 
            // Jika input dilepas maka trigger event OnSprintInput 
            // Mengirim data false 
            OnSprintInput?.Invoke(false); 
        } 
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
