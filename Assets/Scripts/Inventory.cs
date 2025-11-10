using UnityEngine;
using UnityEngine.UI;
using static EppsEnEscena;

public class Inventory : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] Sprite[] sprites;
    private int cont = default;
    public static Inventory Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Debug.LogError("hay mas de un singleton");
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void AddToInventory(Objeto elemento) {
        switch (elemento) {
            case Objeto.Botas_Protectoras:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[0];
                cont++;
                break;
            case Objeto.Tenis:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[1];
                cont++;
                break;
            case Objeto.Tapones:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[2];
                cont++;
                break;
            case Objeto.Audifonos:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[3];
                cont++;
                break;
            case Objeto.Gafas_Protectoras:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[4];
                cont++;
                break;
            case Objeto.Guantes_Cuero:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[5];
                cont++;
                break;
            case Objeto.Guantes_Nitrilo:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[6];
                cont++;
                break;
            case Objeto.Guantes_Algodon:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[7];
                cont++;
                break;
            case Objeto.Camisa:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[8];
                cont++;
                break;
            case Objeto.Camiseta:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[9];
                cont++;
                break;
            case Objeto.Jean:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[10];
                cont++;
                break;
            case Objeto.Sudadera:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[11];
                cont++;
                break;
            case Objeto.Casco:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[12];
                cont++;
                break;
            case Objeto.Gorra:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[13];
                cont++;
                break;
            case Objeto.Tapabocas_Covid:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[14];
                cont++;
                break;
            case Objeto.Tapabocas_Particulas:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[15];
                cont++;
                break;
            case Objeto.Tapabocas_Filtros:
                images[cont].gameObject.SetActive(true);
                images[cont].sprite = sprites[16];
                cont++;
                break;
            default:
                break;
        }
    }
}
