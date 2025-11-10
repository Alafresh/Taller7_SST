using NUnit.Framework;
using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
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

    private int cantidadElementosCorrectos;

    public Transform epps;
    private int cantidadEppsEnEscena;

    public AudioManager audioManager;

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
        cantidadEppsEnEscena = epps.childCount;
        objetosCorrectos = objetosGenerales.Where(obj => obj.value).ToArray();
        foreach (EppsEnEscena obj in objetosCorrectos) 
        {
            if (obj != null) 
            {
                cantidadElementosCorrectos++;
            }
        }
    }

    //el llamado a esta función debe ir primero a la de ObjectSelection
    public void ApagarYPrenderParticulas(GameObject objeto)
    {
        int index = 0;
        int layerObj = objeto.layer;
        int elementosRecorridos = 0;

        //Este switch tiene como casos, el número de la layer del objeto, que concuerda con la categoria a la que pertenece
        //El orden de las layers NO  es el mismo orden del array del inventario
        switch (layerObj)
        {
            case 6: index = 0; break;  // tapabocas
            case 7: index = 3; break;  // casco
            case 8: index = 6; break;  // pantalon
            case 9: index = 4; break;  // camisa
            case 10: index = 5; break; // guantes
            case 11: index = 9; break; // arnes
            case 12: index = 2; break; // gafas
            case 13: index = 7; break; // rodilleras
            case 14: index = 1; break; // oidos
            case 15: index = 8; break; // zapatos
            default: Debug.Log("layer no coincide con los establecidos para los EPP"); break;
        }
        foreach (EppsEnEscena obj in objetosCorrectos) 
        {
            string tagObjeto = objeto.tag.ToString();
            string elementoObj = obj.elemento.ToString();

            if (tagObjeto == elementoObj && objectSelection.objetosSeleccionados[index] == null)
            {
                objeto.SetActive(false);
                ObjectsManagerVerdes.SpawnObject(objeto.transform);
                for (int i = 0; i < cantidadEppsEnEscena; i++) 
                {
                    GameObject eppEnEscena = epps.GetChild(i).gameObject;
                    if (eppEnEscena.layer == objeto.layer) 
                    {
                        DistanceGrabInteractable interactable = eppEnEscena.GetComponent<DistanceGrabInteractable>();
                        HandGrabInteractable handInteractable = eppEnEscena.GetComponent<HandGrabInteractable>();
                        GrabInteractable grabInteractable = eppEnEscena.GetComponent<GrabInteractable>();
                        DistanceHandGrabInteractable distanceHandGrab = eppEnEscena.GetComponent<DistanceHandGrabInteractable>();
                        Grabbable grabbable = eppEnEscena.GetComponent<Grabbable>();
                        interactable.enabled = false;
                        handInteractable.enabled = false;
                        grabInteractable.enabled = false;
                        distanceHandGrab.enabled = false;
                        grabbable.enabled = false;
                    }
                }
            }
            else if (tagObjeto != elementoObj && objectSelection.objetosSeleccionados[index] == null)
            {
                elementosRecorridos++;
                if (elementosRecorridos == cantidadElementosCorrectos)
                {
                    objeto.SetActive(false);
                    objectsManagerRojas.SpawnObject(objeto.transform);
                    audioManager.PlayByIndex(11);
                    for (int i = 0; i < cantidadEppsEnEscena; i++)
                    {
                        GameObject eppEnEscena = epps.GetChild(i).gameObject;
                        if (eppEnEscena.layer == objeto.layer)
                        {
                            DistanceGrabInteractable interactable = eppEnEscena.GetComponent<DistanceGrabInteractable>();
                            HandGrabInteractable handInteractable = eppEnEscena.GetComponent<HandGrabInteractable>();
                            GrabInteractable grabInteractable = eppEnEscena.GetComponent<GrabInteractable>();
                            DistanceHandGrabInteractable distanceHandGrab = eppEnEscena.GetComponent<DistanceHandGrabInteractable>();
                            Grabbable grabbable = eppEnEscena.GetComponent<Grabbable>();
                            interactable.enabled = false;
                            handInteractable.enabled = false;
                            grabInteractable.enabled = false;
                            distanceHandGrab.enabled = false;
                            grabbable.enabled = false;
                        }
                    }
                }

            }
            else if (objectSelection.objetosSeleccionados[index] != null)
            {              
                //aquí tengo que poner el audio diciendole que ya cogió algo de ese tipo
            }
        }
    }
}
