using MinijuegosObreros;
using UnityEngine;

public abstract class MiniGamesManager : MonoBehaviour
{
    public int contadorCheck;

    public virtual void SumContadorCheck() => contadorCheck++;
    public virtual int GetContadorCheck() => contadorCheck;
}
