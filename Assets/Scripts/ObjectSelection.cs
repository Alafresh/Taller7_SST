using System;
using Unity.VisualScripting;
using UnityEngine;


//Este c�digo funciona de la siguiente manera: Hay un array de categorias que se ir� llenando cuando el usuario selecciona (coge con el distance grab o con las manos)
// un EPP. Las categorias est�n creadas como una clase p�blica con su tipo y el objeto seleccionado (de tipo ObjectSelection.Objeto).
// El enum tiene los nombre de todos los objetos que hay en la experiencia (estos nombres tambi� son los tags que llevar�n los game objects).

//Este enum contiene todos los objetos que se pueden seleccionar en la escena

public class EppsEnEscena 
{
    public enum Objeto
    {
        Botas_Protectoras, Tenis, Tapones, Audifonos, Rodilleras, Gafas_Protectoras, Arnes,
        Guantes_Cuero, Guantes_Nitrilo, Guantes_Algodon, Guantes_Neopreno, Guantes_PVC, Guantes_Kevlar,
        Camisa, Camiseta, Jean, Sudadera, Casco, Gorra, Tapabocas_Covid, Tapabocas_Particulas, Tapabocas_Filtros
    }

    public Objeto elemento;
    public bool value;  //esto dice si es bueno o malo en la tarea
}


public class ObjectSelection : MonoBehaviour
{  
    public  Categoria[] objetosSeleccionados = new Categoria[10];
    public int numeroDeObjetosSeleccionados = 0;
    public EppsEnEscena.Objeto objetoSeleccionado;

    
    public void SeleccionarObjeto(int objeto)
    {       
        Debug.Log("Objeto seleccionado: " + (EppsEnEscena.Objeto)objeto);
        switch ((EppsEnEscena.Objeto)objeto)
        {
            case EppsEnEscena.Objeto.Botas_Protectoras:
                Categoria botasProtectoras = new Categoria();
                botasProtectoras.tipo = Categoria.Tipo.Zapatos;
                botasProtectoras.objetoSeleccionado = EppsEnEscena.Objeto.Botas_Protectoras;
                if(objetosSeleccionados[8] == null || objetosSeleccionados[8].tipo != Categoria.Tipo.Zapatos) 
                {
                    objetosSeleccionados[8] = botasProtectoras;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else 
                {                
                    Debug.Log("No se pudo agregar el elemento de tipo Zapatos en el array");
                }
                break;
            case EppsEnEscena.Objeto.Tenis:
                Categoria tenis = new Categoria();
                tenis.tipo = Categoria.Tipo.Zapatos;
                tenis.objetoSeleccionado = EppsEnEscena.Objeto.Tenis;
                if (objetosSeleccionados[8] == null || objetosSeleccionados[8].tipo != Categoria.Tipo.Zapatos)
                {
                    objetosSeleccionados[8] = tenis;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Zapatos en el array");
                }   
                break;
            case EppsEnEscena.Objeto.Tapones:
                Categoria tapones = new Categoria();
                tapones.tipo = Categoria.Tipo.Oidos;
                tapones.objetoSeleccionado = EppsEnEscena.Objeto.Tapones;
                if (objetosSeleccionados[1] == null || objetosSeleccionados[1].tipo != Categoria.Tipo.Oidos)
                {
                    objetosSeleccionados[1] = tapones;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Oidos en el array");
                } 
                break;
            case EppsEnEscena.Objeto.Audifonos:
                Categoria audifonos = new Categoria();
                audifonos.tipo = Categoria.Tipo.Oidos;
                audifonos.objetoSeleccionado = EppsEnEscena.Objeto.Audifonos;
                if (objetosSeleccionados[1] == null || objetosSeleccionados[1].tipo != Categoria.Tipo.Oidos)
                {
                    objetosSeleccionados[1] = audifonos;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Oidos en el array");
                }
                break;
            case EppsEnEscena.Objeto.Rodilleras:
                Categoria rodilleras = new Categoria();
                rodilleras.tipo = Categoria.Tipo.Rodilleras;
                rodilleras.objetoSeleccionado = EppsEnEscena.Objeto.Rodilleras;
                if (objetosSeleccionados[7] == null || objetosSeleccionados[7].tipo != Categoria.Tipo.Rodilleras)
                {
                    objetosSeleccionados[7] = rodilleras;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Rodilleras en el array" );
                }
                break;
            case EppsEnEscena.Objeto.Gafas_Protectoras:
                Categoria gafas = new Categoria();
                gafas.tipo = Categoria.Tipo.Gafas;
                gafas.objetoSeleccionado = EppsEnEscena.Objeto.Gafas_Protectoras;
                if (objetosSeleccionados[2] == null || objetosSeleccionados[2].tipo != Categoria.Tipo.Gafas)
                {
                    objetosSeleccionados[2] = gafas;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Gafas en el array");
                }
                break;
            case EppsEnEscena.Objeto.Arnes:
                Categoria arnes = new Categoria();
                arnes.tipo = Categoria.Tipo.Arnes;
                arnes.objetoSeleccionado = EppsEnEscena.Objeto.Arnes;
                if (objetosSeleccionados[9] == null || objetosSeleccionados[9].tipo != Categoria.Tipo.Arnes)
                {
                    objetosSeleccionados[9] = arnes;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Arnes en el array");
                }               
                break;
            case EppsEnEscena.Objeto.Guantes_Cuero:
                Categoria guantesCuero = new Categoria();
                guantesCuero.tipo = Categoria.Tipo.Guantes;
                guantesCuero.objetoSeleccionado = EppsEnEscena.Objeto.Guantes_Cuero;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesCuero;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                break;
            case EppsEnEscena.Objeto.Guantes_Nitrilo:
                Categoria guantesNitrilo = new Categoria();
                guantesNitrilo.tipo = Categoria.Tipo.Guantes;
                guantesNitrilo.objetoSeleccionado = EppsEnEscena.Objeto.Guantes_Nitrilo;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesNitrilo;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                
                break;
            case EppsEnEscena.Objeto.Guantes_Algodon:
                Categoria guantesAlgodon = new Categoria();
                guantesAlgodon.tipo = Categoria.Tipo.Guantes;
                guantesAlgodon.objetoSeleccionado = EppsEnEscena.Objeto.Guantes_Algodon;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesAlgodon;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                break;
            case EppsEnEscena.Objeto.Guantes_Neopreno:
                Categoria guantesNeopreno = new Categoria();
                guantesNeopreno.tipo = Categoria.Tipo.Guantes;
                guantesNeopreno.objetoSeleccionado = EppsEnEscena.Objeto.Guantes_Neopreno;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesNeopreno;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                break;
            case EppsEnEscena.Objeto.Guantes_PVC:
                Categoria guantesPVC = new Categoria();
                guantesPVC.tipo = Categoria.Tipo.Guantes;
                guantesPVC.objetoSeleccionado = EppsEnEscena.Objeto.Guantes_PVC;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesPVC;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }    
                break;
            case EppsEnEscena.Objeto.Guantes_Kevlar:
                Categoria guantesKevlar = new Categoria();
                guantesKevlar.tipo = Categoria.Tipo.Guantes;
                guantesKevlar.objetoSeleccionado = EppsEnEscena.Objeto.Guantes_Kevlar;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesKevlar;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                } 
                break;
            case EppsEnEscena.Objeto.Camisa:
                Categoria camisa = new Categoria();
                camisa.tipo = Categoria.Tipo.Camisa;
                camisa.objetoSeleccionado = EppsEnEscena.Objeto.Camisa;
                if (objetosSeleccionados[4] == null || objetosSeleccionados[4].tipo != Categoria.Tipo.Camisa)
                {
                    objetosSeleccionados[4] = camisa;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Camisa en el array");
                }  
                break;
            case EppsEnEscena.Objeto.Camiseta:
                Categoria camiseta = new Categoria();
                camiseta.tipo = Categoria.Tipo.Camisa;
                camiseta.objetoSeleccionado = EppsEnEscena.Objeto.Camiseta;
                if (objetosSeleccionados[4] == null || objetosSeleccionados[4].tipo != Categoria.Tipo.Camisa)
                {
                    objetosSeleccionados[4] = camiseta;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Camisa en el array");
                }      
                break;
            case EppsEnEscena.Objeto.Jean:
                Categoria jean = new Categoria();
                jean.tipo = Categoria.Tipo.Pantalon;
                jean.objetoSeleccionado = EppsEnEscena.Objeto.Jean;
                if (objetosSeleccionados[6] == null || objetosSeleccionados[6].tipo != Categoria.Tipo.Pantalon)
                {
                    objetosSeleccionados[6] = jean;
                    numeroDeObjetosSeleccionados++;
                    Debug.Log("el elemento en la posici�n 6 es de tipo " + objetosSeleccionados[6].tipo + " y es un " + objetosSeleccionados[6].objetoSeleccionado);
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Pantalon en el array");
                }   
                break;
            case EppsEnEscena.Objeto.Sudadera:
                Categoria sudadera = new Categoria();
                sudadera.tipo = Categoria.Tipo.Pantalon;
                sudadera.objetoSeleccionado = EppsEnEscena.Objeto.Sudadera;
                if (objetosSeleccionados[6] == null || objetosSeleccionados[6].tipo != Categoria.Tipo.Pantalon)
                {
                    objetosSeleccionados[6] = sudadera;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Pantalon en el array");
                }
                break;
            case EppsEnEscena.Objeto.Casco:
                Categoria casco = new Categoria();
                casco.tipo = Categoria.Tipo.Cabeza;
                casco.objetoSeleccionado = EppsEnEscena.Objeto.Casco;
                if (objetosSeleccionados[3] == null || objetosSeleccionados[3].tipo != Categoria.Tipo.Cabeza)
                {
                    objetosSeleccionados[3] = casco;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Cabeza en el array");
                }
                break;
            case EppsEnEscena.Objeto.Tapabocas_Covid:
                Categoria tapabocasCovid = new Categoria();
                tapabocasCovid.tipo = Categoria.Tipo.Tapabocas;
                tapabocasCovid.objetoSeleccionado = EppsEnEscena.Objeto.Tapabocas_Covid;
                if (objetosSeleccionados[0] == null || objetosSeleccionados[0].tipo != Categoria.Tipo.Tapabocas)
                {
                    objetosSeleccionados[0] = tapabocasCovid;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Tapabocas en el array");
                }
                break;
            case EppsEnEscena.Objeto.Tapabocas_Particulas:
                Categoria tapabocasParticulas = new Categoria();
                tapabocasParticulas.tipo = Categoria.Tipo.Tapabocas;
                tapabocasParticulas.objetoSeleccionado = EppsEnEscena.Objeto.Tapabocas_Particulas;
                if (objetosSeleccionados[0] == null || objetosSeleccionados[0].tipo != Categoria.Tipo.Tapabocas)
                {
                    objetosSeleccionados[0] = tapabocasParticulas;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Tapabocas en el array");
                }
                break;
            case EppsEnEscena.Objeto.Tapabocas_Filtros:
                Categoria tapabocasFiltros = new Categoria();
                tapabocasFiltros.tipo = Categoria.Tipo.Tapabocas;
                tapabocasFiltros.objetoSeleccionado = EppsEnEscena.Objeto.Tapabocas_Filtros;
                if (objetosSeleccionados[0] == null || objetosSeleccionados[0].tipo != Categoria.Tipo.Tapabocas)
                {
                    objetosSeleccionados[0] = tapabocasFiltros;
                    Debug.Log("Objeto agregado");
                    numeroDeObjetosSeleccionados++;
                    Inventory.Instance.AddToInventory(objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Tapabocas en el array");
                }
                break;
            default:
                Debug.Log("Ning�n objeto agregado");
                break;
        }
    }
}

//Esta clase es para representar una categor�a de objeto y el objeto seleccionado dentro de esa categor�a
public class Categoria
{
    public enum Tipo //Son 10 tipos posibles y s�n los que est�n en el GDD (Tapabocas, Cabeza, Pantalon, Camiseta/camisa, Guantes, Arnes, Gafas, Rodilleras, Oidos, Zapatos)
    {
        Tapabocas, Oidos, Gafas, Cabeza, Camisa, Guantes, Pantalon, Rodilleras, Zapatos, Arnes
    }

    public Tipo tipo; 
    public EppsEnEscena.Objeto objetoSeleccionado;
}

