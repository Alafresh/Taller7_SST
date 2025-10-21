using NUnit.Framework;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TareaManager : MonoBehaviour
{
    //Estos bool sirven para poder decidir desde el inspector, qué elementos sirven(true) o no(false) en la tarea de la escena
    [Header("EPP")] public bool Botas_Protectoras, Tenis, Tapones, Audifonos, Rodilleras, Gafas_Protectoras, Arnes, Guantes_Cuero, Guantes_Nitrilo, Guantes_Algodon, Guantes_Neopreno, Guantes_PVC, Guantes_Kevlar, Camisa, Camiseta, Jean, Sudadera, Casco, Gorra, Tapabocas_Covid, Tapabocas_Particulas, Tapabocas_Filtros;

    public ObjectSelection objectSelection;

    public ObjectsManager objectsManagerRojas;
    public ObjectsManager ObjectsManagerVerdes;

    public EppsEnEscena[] objetosCorrectos;
    public EppsEnEscena[] objetosGenerales;

    private void Awake()
    {
        objetosGenerales = new EppsEnEscena[]
        {
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Botas_Protectoras, value = Botas_Protectoras },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Tenis, value = Tenis },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Tapones, value = Tapones },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Audifonos, value = Audifonos },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Rodilleras, value = Rodilleras },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Gafas_Protectoras, value = Gafas_Protectoras },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Arnes, value = Arnes },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Guantes_Cuero, value = Guantes_Cuero },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Guantes_Nitrilo, value = Guantes_Nitrilo },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Guantes_Algodon, value = Guantes_Algodon },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Guantes_Neopreno, value = Guantes_Neopreno },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Guantes_PVC, value = Guantes_PVC },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Guantes_Kevlar, value = Guantes_Kevlar },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Camisa, value = Camisa },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Camiseta, value = Camiseta },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Jean, value = Jean },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Sudadera, value = Sudadera },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Casco, value = Casco },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Gorra, value = Gorra },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Tapabocas_Covid, value = Tapabocas_Covid },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Tapabocas_Particulas, value = Tapabocas_Particulas },
            new EppsEnEscena { elemento = EppsEnEscena.Objeto.Tapabocas_Filtros, value = Tapabocas_Filtros }
        };
    }
    private void Start()
    {
        objetosCorrectos = objetosGenerales.Where(obj => obj.value).ToArray();
    }

    //el llamado a esta función debe ir primero a la de ObjectSelection
    public void ApagarYPrenderParticulas(GameObject objeto)
    {
        Debug.Log("Se llamo ApagarYPrenderParticulas");
        int index = 0;
        int layerObj = objeto.layer;
        int elementosRecorridos = 0;

        //Este switch tiene como casos, el número de la layer del objeto, que concuerda con la categoria a la que pertenece
        //El orden de las layers NO  es el mismo orden del array del inventario
        switch (layerObj) 
        {
            case 6: //tapabocas
                Debug.Log("Caso 6, tapabocas");
                index = 0;
                break;
            case 7: //casco
                Debug.Log("Caso 7, casco");
                index = 3;
                break;
            case 8: //pantalon
                Debug.Log("Caso 8, pantalon");
                index = 6;
                break;
            case 9: //camisa
                Debug.Log("Caso 9, camisa");
                index = 4;
                break;
            case 10: //guantes
                Debug.Log("Caso 10, guantes");
                index = 5;
                break;
            case 11: //arnes
                Debug.Log("Caso 11, arnes");
                index = 9;
                break;
            case 12: //gafas
                Debug.Log("Caso 12, gafas");
                index = 2;
                break;
            case 13: //rodilleras
                Debug.Log("Caso 13, rodilleras");
                index = 7;
                break;
            case 14: //proteccion oidos
                Debug.Log("Caso 14, proteccion oidos");
                index = 1;
                break;
            case 15: //zapatos
                Debug.Log("Caso 15, zapatos");
                index = 8;
                break;
            default:
                Debug.Log("layer no coincide con los establecidos para los EPP");
                break;
        }
        foreach (var obj in objetosCorrectos) 
        {
            string tagObjeto = objeto.tag.ToString();
            string elementoObj = obj.elemento.DisplayName().ToString();
            Debug.Log("Entro al Foreach de correctos");
            Debug.Log("Tag: " + tagObjeto + "elementoObj" + elementoObj);
            //si este if no funciona, probablemente sea porque el puesto del inventario que se está verificando fue ocupado antes de que la lógica llegara a este punto
            if (tagObjeto == elementoObj && objectSelection.objetosSeleccionados[index] == null)
            {
                Debug.Log("el tag concuerda con un elemento correcto y la posición del arreglo está vacío");
                objeto.SetActive(false);
                ObjectsManagerVerdes.SpawnObject(objeto.transform);
            }
            else if (tagObjeto != elementoObj && objectSelection.objetosSeleccionados[index] == null)
            {
                elementosRecorridos++;
                if(elementosRecorridos == objectSelection.objetosSeleccionados.Length) 
                {
                    Debug.Log("Se recorrió todo el arreglo de elementos correctos y no coincidio el objeto");
                    objeto.SetActive(false);
                    objectsManagerRojas.SpawnObject(objeto.transform);
                }
            }
        }
    }
}
