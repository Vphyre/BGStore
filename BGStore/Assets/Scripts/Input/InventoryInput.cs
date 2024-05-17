using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    private PlayerInputs playerInputs;
    private bool openInventory = false;

    private void Awake()
    {
        playerInputs = new PlayerInputs();
    }
    private void Start()
    {
        playerInputs.Main.Inventory.performed += ctx => OpenCloseInventory();
    }
    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }
    public void OpenCloseInventory()
    {
        openInventory = !openInventory;
        inventoryCanvas.SetActive(openInventory);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
