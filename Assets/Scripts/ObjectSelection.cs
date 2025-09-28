using Meta.XR.Editor.Tags;
using System;
using UnityEngine;


//Este código funciona de la siguiente manera: Hay un array de categorias que se irá llenando cuando el usuario selecciona (coge con el distance grab o con las manos)
// un EPP. Las categorias están creadas como una clase pública con su tipo y el objeto seleccionado (de tipo ObjectSelection.Objeto).
// El enum tiene los nombre de todos los objetos que hay en la experiencia (estos nombres tambié son los tags que llevarán los game objects).
public class ObjectSelection : MonoBehaviour
{
    [SerializeField] private GameObject pinkParticles;    [SerializeField] private GameObject blueParticles;   [SerializeField] private GameObject yellowParticles; [SerializeField] private GameObject greenParticles; [SerializeField] private GameObject orangeParticles;  // partículas de colores

    public Categoria[] objetosSeleccionados = new Categoria[10];
    public int numeroDeObjetosSeleccionados = 0;
    public Objeto objetoSeleccionado;

    //Este enum contiene todos los objetos que se pueden seleccionar en la escena
    public enum Objeto
    {
        Botas_Protectoras, Tenis, Tapones, Audífonos, Rodilleras, Gafas_Protectoras, Arnes, 
        Guantes_Cuero, Guantes_Nitrilo, Guantes_Algodon, Guantes_Neopreno, Guantes_PVC, Guantes_Kevlar,
        Camisa, Camiseta, Jean, Sudadera, Casco, Tapabocas_Covid, Tapabocas_Particulas,Tapabocas_Filtros
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    //Esta función es la que se encarga de la lógica después de que se selecciona un objeto
    public void SeleccionarObjeto(int objeto)
    {
        numeroDeObjetosSeleccionados++;

        switch ((Objeto)objeto)
        {
            case Objeto.Botas_Protectoras:
                Categoria botasProtectoras = new Categoria();
                botasProtectoras.tipo = Categoria.Tipo.Zapatos;
                botasProtectoras.objetoSeleccionado = Objeto.Botas_Protectoras;
                //TENGO QUE PONEREL IF PARA COMPROBAR SI YA HAY UN ELEMENTO DE ESE TIPO ESCOGIDO
                objetosSeleccionados[8] = botasProtectoras;         
                break;
            case Objeto.Tenis:
                Categoria tenis = new Categoria();
                tenis.tipo = Categoria.Tipo.Zapatos;
                tenis.objetoSeleccionado = Objeto.Tenis;
                objetosSeleccionados[8] = tenis;
                break;
            case Objeto.Tapones:
                Categoria tapones = new Categoria();
                tapones.tipo = Categoria.Tipo.Oidos;
                tapones.objetoSeleccionado = Objeto.Tapones;
                objetosSeleccionados[1] = tapones;
                break;
            case Objeto.Audífonos:
                Categoria audifonos = new Categoria();
                audifonos.tipo = Categoria.Tipo.Oidos;
                audifonos.objetoSeleccionado = Objeto.Audífonos;
                objetosSeleccionados[1] = audifonos;
                break;
            case Objeto.Rodilleras:
                Categoria rodilleras = new Categoria();
                rodilleras.tipo = Categoria.Tipo.Rodilleras;
                rodilleras.objetoSeleccionado = Objeto.Rodilleras;
                objetosSeleccionados[7] = rodilleras;
                break;
            case Objeto.Gafas_Protectoras:
                Categoria gafas = new Categoria();
                gafas.tipo = Categoria.Tipo.Gafas;
                gafas.objetoSeleccionado = Objeto.Gafas_Protectoras;
                objetosSeleccionados[2] = gafas;
                break;
            case Objeto.Arnes:
                Categoria arnes = new Categoria();
                arnes.tipo = Categoria.Tipo.Arnes;
                arnes.objetoSeleccionado = Objeto.Arnes;
                objetosSeleccionados[9] = arnes;
                break;
            case Objeto.Guantes_Cuero:
                Categoria guantesCuero = new Categoria();
                guantesCuero.tipo = Categoria.Tipo.Guantes;
                guantesCuero.objetoSeleccionado = Objeto.Guantes_Cuero;
                objetosSeleccionados[5] = guantesCuero;
                break;
            case Objeto.Guantes_Nitrilo:
                Categoria guantesNitrilo = new Categoria();
                guantesNitrilo.tipo = Categoria.Tipo.Guantes;
                guantesNitrilo.objetoSeleccionado = Objeto.Guantes_Nitrilo;
                objetosSeleccionados[5] = guantesNitrilo;
                break;
            case Objeto.Guantes_Algodon:
                Categoria guantesAlgodon = new Categoria();
                guantesAlgodon.tipo = Categoria.Tipo.Guantes;
                guantesAlgodon.objetoSeleccionado = Objeto.Guantes_Algodon;
                objetosSeleccionados[5] = guantesAlgodon;
                break;
            case Objeto.Guantes_Neopreno:
                Categoria guantesNeopreno = new Categoria();
                guantesNeopreno.tipo = Categoria.Tipo.Guantes;
                guantesNeopreno.objetoSeleccionado = Objeto.Guantes_Neopreno;
                objetosSeleccionados[5] = guantesNeopreno;
                break;
            case Objeto.Guantes_PVC:
                Categoria guantesPVC = new Categoria();
                guantesPVC.tipo = Categoria.Tipo.Guantes;
                guantesPVC.objetoSeleccionado = Objeto.Guantes_PVC;
                objetosSeleccionados[5] = guantesPVC;
                break;
            case Objeto.Guantes_Kevlar:
                Categoria guantesKevlar = new Categoria();
                guantesKevlar.tipo = Categoria.Tipo.Guantes;
                guantesKevlar.objetoSeleccionado = Objeto.Guantes_Kevlar;
                objetosSeleccionados[5] = guantesKevlar;
                break;
            case Objeto.Camisa:
                Categoria camisa = new Categoria();
                camisa.tipo = Categoria.Tipo.Camisa;
                camisa.objetoSeleccionado = Objeto.Camisa;
                objetosSeleccionados[4] = camisa;
                break;
            case Objeto.Camiseta:
                Categoria camiseta = new Categoria();
                camiseta.tipo = Categoria.Tipo.Camisa;
                camiseta.objetoSeleccionado = Objeto.Camiseta;
                objetosSeleccionados[4] = camiseta;
                break;
            case Objeto.Jean:
                Categoria jean = new Categoria();
                jean.tipo = Categoria.Tipo.Pantalon;
                jean.objetoSeleccionado = Objeto.Jean;
                objetosSeleccionados[6] = jean;
                break;
            case Objeto.Sudadera:
                Categoria sudadera = new Categoria();
                sudadera.tipo = Categoria.Tipo.Pantalon;
                sudadera.objetoSeleccionado = Objeto.Sudadera;
                objetosSeleccionados[6] = sudadera;
                break;
            case Objeto.Casco:
                Categoria casco = new Categoria();
                casco.tipo = Categoria.Tipo.Cabeza;
                casco.objetoSeleccionado = Objeto.Casco;
                objetosSeleccionados[3] = casco;
                break;
            case Objeto.Tapabocas_Covid:
                Categoria tapabocasCovid = new Categoria();
                tapabocasCovid.tipo = Categoria.Tipo.Tapabocas;
                tapabocasCovid.objetoSeleccionado = Objeto.Tapabocas_Covid;
                objetosSeleccionados[0] = tapabocasCovid;
                break;
            case Objeto.Tapabocas_Particulas:
                Categoria tapabocasParticulas = new Categoria();
                tapabocasParticulas.tipo = Categoria.Tipo.Tapabocas;
                tapabocasParticulas.objetoSeleccionado = Objeto.Tapabocas_Particulas;
                objetosSeleccionados[0] = tapabocasParticulas;
                break;
            case Objeto.Tapabocas_Filtros:
                Categoria tapabocasFiltros = new Categoria();
                tapabocasFiltros.tipo = Categoria.Tipo.Tapabocas;
                tapabocasFiltros.objetoSeleccionado = Objeto.Tapabocas_Filtros;
                objetosSeleccionados[0] = tapabocasFiltros;
                break;
            default:
                Console.WriteLine("Ningún objeto seleccionado");
                break;
        }
    }
}

//Esta clase es para representar una categoría de objeto y el objeto seleccionado dentro de esa categoría
public class Categoria
{
    public Tipo tipo; 
    public ObjectSelection.Objeto objetoSeleccionado;

    public enum Tipo //Son 10 tipos posibles y són los que están en el GDD (Tapabocas, Cabeza, Pantalon, Camiseta/camisa, Guantes, Arnes, Gafas, Rodilleras, Oidos, Zapatos)
    {
        Tapabocas, Oidos, Gafas, Cabeza, Camisa, Guantes, Pantalon, Rodilleras, Zapatos, Arnes
    }
}

