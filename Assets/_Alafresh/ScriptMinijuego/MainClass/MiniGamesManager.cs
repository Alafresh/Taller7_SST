using MinijuegosObreros;
using UnityEngine;

public abstract class MiniGamesManager : MonoBehaviour
{
    [SerializeField] protected Timer timer;
    protected int contadorCheck;

    public virtual void SumContadorCheck() => contadorCheck++;
    public virtual int GetContadorCheck() => contadorCheck;
}
