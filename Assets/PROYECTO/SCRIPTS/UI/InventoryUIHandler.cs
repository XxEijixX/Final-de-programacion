using UnityEngine;

public class InventoryUIHandler : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject uiItem;
    public GameObject instanceDestination;
    public GameObject[] itemsInstanciados;
    public int itemIndexCount = 0;
    private InventoryHandler inventory;
    public bool inventoryOpened = false;
    public int currentPage = 0; // Nuevo campo para controlar la página actual
    public int itemsPerPage = 8; // Items por página

    private void Start()
    {
        inventory = FindObjectOfType<InventoryHandler>();
        itemsInstanciados = new GameObject[inventory.maxCapacity];
    }

    private void Update()
    {
        ToggleInventory();
        HandlePageNavigation();
    }

    private void ToggleInventory()
    {
        if (OpenInventoryInput())
        {
            inventoryOpened = !inventoryOpened;
            inventoryPanel.SetActive(inventoryOpened);

            if (inventoryOpened)
            {
                UpdateInventory();
                UpdatePageDisplay();
            }
        }
    }

    private void UpdateInventory()
    {
        for (int i = itemIndexCount; i < inventory.inventario.Count; i++)
        {
            GameObject newUiItem = Instantiate(uiItem);
            newUiItem.transform.parent = instanceDestination.transform;
            newUiItem.GetComponent<UIItem>().SetItemInfo(inventory.inventario[i]);
            newUiItem.transform.localScale = Vector3.one;
            itemsInstanciados[i] = newUiItem;
            itemIndexCount++;
        }
    }

    private void HandlePageNavigation()
    {
        if (inventoryOpened)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                currentPage = Mathf.Min(currentPage + 1, CalculateMaxPages() - 1);
                UpdatePageDisplay();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                currentPage = Mathf.Max(currentPage - 1, 0);
                UpdatePageDisplay();
            }
        }
    }

    private int CalculateMaxPages()
    {
        return Mathf.CeilToInt(inventory.inventario.Count / (float)itemsPerPage);
    }

    private void UpdatePageDisplay()
    {
        int startIndex = currentPage * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, inventory.inventario.Count);

        for (int i = 0; i < itemsInstanciados.Length; i++)
        {
            itemsInstanciados[i]?.SetActive(i >= startIndex && i < endIndex);
        }
    }

    private bool OpenInventoryInput()
    {
        return Input.GetKeyDown(KeyCode.I);
    }
}

