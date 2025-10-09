using System;
using Unity.VisualScripting;
using UnityEngine;


//Este c�digo funciona de la siguiente manera: Hay un array de categorias que se ir� llenando cuando el usuario selecciona (coge con el distance grab o con las manos)
// un EPP. Las categorias est�n creadas como una clase p�blica con su tipo y el objeto seleccionado (de tipo ObjectSelection.Objeto).
// El enum tiene los nombre de todos los objetos que hay en la experiencia (estos nombres tambi� son los tags que llevar�n los game objects).

//Este enum contiene todos los objetos que se pueden seleccionar en la escena
public enum Objeto
{
    Botas_Protectoras, Tenis, Tapones, Audifonos, Rodilleras, Gafas_Protectoras, Arnes,
    Guantes_Cuero, Guantes_Nitrilo, Guantes_Algodon, Guantes_Neopreno, Guantes_PVC, Guantes_Kevlar,
    Camisa, Camiseta, Jean, Sudadera, Casco, Gorra, Tapabocas_Covid, Tapabocas_Particulas, Tapabocas_Filtros
}

public class ObjectSelection : MonoBehaviour
{
    [SerializeField] private GameObject pinkParticles;    [SerializeField] private GameObject blueParticles;   [SerializeField] private GameObject yellowParticles; [SerializeField] private GameObject greenParticles; [SerializeField] private GameObject orangeParticles;  // part�culas de colores

    public Categoria[] objetosSeleccionados = new Categoria[10];
    public int numeroDeObjetosSeleccionados = 0;
    public Objeto objetoSeleccionado;

    
    //Esta funci�n es la que se encarga de la l�gica despu�s de que se selecciona un objeto
    public void SeleccionarObjeto(int objeto)
    {       
        Debug.Log("Objeto seleccionado: " + (Objeto)objeto);
        switch ((Objeto)objeto)
        {
            case Objeto.Botas_Protectoras:
                Categoria botasProtectoras = new Categoria();
                botasProtectoras.tipo = Categoria.Tipo.Zapatos;
                botasProtectoras.objetoSeleccionado = Objeto.Botas_Protectoras;
                if(objetosSeleccionados[8] == null || objetosSeleccionados[8].tipo != Categoria.Tipo.Zapatos) 
                {
                    objetosSeleccionados[8] = botasProtectoras;
                    numeroDeObjetosSeleccionados++;
                }
                else 
                {                
                    Debug.Log("No se pudo agregar el elemento de tipo Zapatos en el array");
                }
                break;
            case Objeto.Tenis:
                Categoria tenis = new Categoria();
                tenis.tipo = Categoria.Tipo.Zapatos;
                tenis.objetoSeleccionado = Objeto.Tenis;
                if (objetosSeleccionados[8] == null || objetosSeleccionados[8].tipo != Categoria.Tipo.Zapatos)
                {
                    objetosSeleccionados[8] = tenis;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Zapatos en el array");
                }   
                break;
            case Objeto.Tapones:
                Categoria tapones = new Categoria();
                tapones.tipo = Categoria.Tipo.Oidos;
                tapones.objetoSeleccionado = Objeto.Tapones;
                if (objetosSeleccionados[1] == null || objetosSeleccionados[1].tipo != Categoria.Tipo.Oidos)
                {
                    objetosSeleccionados[1] = tapones;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Oidos en el array");
                } 
                break;
            case Objeto.Audifonos:
                Categoria audifonos = new Categoria();
                audifonos.tipo = Categoria.Tipo.Oidos;
                audifonos.objetoSeleccionado = Objeto.Audifonos;
                if (objetosSeleccionados[1] == null || objetosSeleccionados[1].tipo != Categoria.Tipo.Oidos)
                {
                    objetosSeleccionados[1] = audifonos;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Oidos en el array");
                }
                break;
            case Objeto.Rodilleras:
                Categoria rodilleras = new Categoria();
                rodilleras.tipo = Categoria.Tipo.Rodilleras;
                rodilleras.objetoSeleccionado = Objeto.Rodilleras;
                if (objetosSeleccionados[7] == null || objetosSeleccionados[7].tipo != Categoria.Tipo.Rodilleras)
                {
                    objetosSeleccionados[7] = rodilleras;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Rodilleras en el array" );
                }
                break;
            case Objeto.Gafas_Protectoras:
                Categoria gafas = new Categoria();
                gafas.tipo = Categoria.Tipo.Gafas;
                gafas.objetoSeleccionado = Objeto.Gafas_Protectoras;
                if (objetosSeleccionados[2] == null || objetosSeleccionados[2].tipo != Categoria.Tipo.Gafas)
                {
                    objetosSeleccionados[2] = gafas;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Gafas en el array");
                }
                break;
            case Objeto.Arnes:
                Categoria arnes = new Categoria();
                arnes.tipo = Categoria.Tipo.Arnes;
                arnes.objetoSeleccionado = Objeto.Arnes;
                if (objetosSeleccionados[9] == null || objetosSeleccionados[9].tipo != Categoria.Tipo.Arnes)
                {
                    objetosSeleccionados[9] = arnes;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Arnes en el array");
                }               
                break;
            case Objeto.Guantes_Cuero:
                Categoria guantesCuero = new Categoria();
                guantesCuero.tipo = Categoria.Tipo.Guantes;
                guantesCuero.objetoSeleccionado = Objeto.Guantes_Cuero;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesCuero;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                break;
            case Objeto.Guantes_Nitrilo:
                Categoria guantesNitrilo = new Categoria();
                guantesNitrilo.tipo = Categoria.Tipo.Guantes;
                guantesNitrilo.objetoSeleccionado = Objeto.Guantes_Nitrilo;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesNitrilo;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                
                break;
            case Objeto.Guantes_Algodon:
                Categoria guantesAlgodon = new Categoria();
                guantesAlgodon.tipo = Categoria.Tipo.Guantes;
                guantesAlgodon.objetoSeleccionado = Objeto.Guantes_Algodon;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesAlgodon;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                break;
            case Objeto.Guantes_Neopreno:
                Categoria guantesNeopreno = new Categoria();
                guantesNeopreno.tipo = Categoria.Tipo.Guantes;
                guantesNeopreno.objetoSeleccionado = Objeto.Guantes_Neopreno;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesNeopreno;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }
                break;
            case Objeto.Guantes_PVC:
                Categoria guantesPVC = new Categoria();
                guantesPVC.tipo = Categoria.Tipo.Guantes;
                guantesPVC.objetoSeleccionado = Objeto.Guantes_PVC;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesPVC;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                }    
                break;
            case Objeto.Guantes_Kevlar:
                Categoria guantesKevlar = new Categoria();
                guantesKevlar.tipo = Categoria.Tipo.Guantes;
                guantesKevlar.objetoSeleccionado = Objeto.Guantes_Kevlar;
                if (objetosSeleccionados[5] == null || objetosSeleccionados[5].tipo != Categoria.Tipo.Guantes)
                {
                    objetosSeleccionados[5] = guantesKevlar;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Guantes en el array");
                } 
                break;
            case Objeto.Camisa:
                Categoria camisa = new Categoria();
                camisa.tipo = Categoria.Tipo.Camisa;
                camisa.objetoSeleccionado = Objeto.Camisa;
                if (objetosSeleccionados[4] == null || objetosSeleccionados[4].tipo != Categoria.Tipo.Camisa)
                {
                    objetosSeleccionados[4] = camisa;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Camisa en el array");
                }  
                break;
            case Objeto.Camiseta:
                Categoria camiseta = new Categoria();
                camiseta.tipo = Categoria.Tipo.Camisa;
                camiseta.objetoSeleccionado = Objeto.Camiseta;
                if (objetosSeleccionados[4] == null || objetosSeleccionados[4].tipo != Categoria.Tipo.Camisa)
                {
                    objetosSeleccionados[4] = camiseta;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Camisa en el array");
                }      
                break;
            case Objeto.Jean:
                Categoria jean = new Categoria();
                jean.tipo = Categoria.Tipo.Pantalon;
                jean.objetoSeleccionado = Objeto.Jean;
                if (objetosSeleccionados[6] == null || objetosSeleccionados[6].tipo != Categoria.Tipo.Pantalon)
                {
                    objetosSeleccionados[6] = jean;
                    numeroDeObjetosSeleccionados++;
                    Debug.Log("el elemento en la posici�n 6 es de tipo " + objetosSeleccionados[6].tipo + " y es un " + objetosSeleccionados[6].objetoSeleccionado);
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Pantalon en el array");
                }   
                break;
            case Objeto.Sudadera:
                Categoria sudadera = new Categoria();
                sudadera.tipo = Categoria.Tipo.Pantalon;
                sudadera.objetoSeleccionado = Objeto.Sudadera;
                if (objetosSeleccionados[6] == null || objetosSeleccionados[6].tipo != Categoria.Tipo.Pantalon)
                {
                    objetosSeleccionados[6] = sudadera;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Pantalon en el array");
                }
                break;
            case Objeto.Casco:
                Categoria casco = new Categoria();
                casco.tipo = Categoria.Tipo.Cabeza;
                casco.objetoSeleccionado = Objeto.Casco;
                if (objetosSeleccionados[3] == null || objetosSeleccionados[3].tipo != Categoria.Tipo.Cabeza)
                {
                    objetosSeleccionados[3] = casco;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Cabeza en el array");
                }
                break;
            case Objeto.Tapabocas_Covid:
                Categoria tapabocasCovid = new Categoria();
                tapabocasCovid.tipo = Categoria.Tipo.Tapabocas;
                tapabocasCovid.objetoSeleccionado = Objeto.Tapabocas_Covid;
                if (objetosSeleccionados[0] == null || objetosSeleccionados[0].tipo != Categoria.Tipo.Tapabocas)
                {
                    objetosSeleccionados[0] = tapabocasCovid;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Tapabocas en el array");
                }
                break;
            case Objeto.Tapabocas_Particulas:
                Categoria tapabocasParticulas = new Categoria();
                tapabocasParticulas.tipo = Categoria.Tipo.Tapabocas;
                tapabocasParticulas.objetoSeleccionado = Objeto.Tapabocas_Particulas;
                if (objetosSeleccionados[0] == null || objetosSeleccionados[0].tipo != Categoria.Tipo.Tapabocas)
                {
                    objetosSeleccionados[0] = tapabocasParticulas;
                    numeroDeObjetosSeleccionados++;
                }
                else
                {
                    Debug.Log("No se pudo agregar el elemento de tipo Tapabocas en el array");
                }
                break;
            case Objeto.Tapabocas_Filtros:
                Categoria tapabocasFiltros = new Categoria();
                tapabocasFiltros.tipo = Categoria.Tipo.Tapabocas;
                tapabocasFiltros.objetoSeleccionado = Objeto.Tapabocas_Filtros;
                if (objetosSeleccionados[0] == null || objetosSeleccionados[0].tipo != Categoria.Tipo.Tapabocas)
                {
                    objetosSeleccionados[0] = tapabocasFiltros;
                    numeroDeObjetosSeleccionados++;
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
    public Objeto objetoSeleccionado;
}

