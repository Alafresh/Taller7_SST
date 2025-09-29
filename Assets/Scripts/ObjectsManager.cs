using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    //Este código va a permitir el fácil establecimiento de EPP en la escena y la calidad que le responde dependiendo de la situación
    //La idea es que aparezca en el inspector un menú desplegable con las diferentes categorías de EPP, se seleccione cuáles van a estar en la situación
    //Después se debe elegir por cada categoría cuál de sus opciones son de mejor o peor calidad dependiendo de la tarea

    public List<Categoria> categoriasEnEscena; }
}
