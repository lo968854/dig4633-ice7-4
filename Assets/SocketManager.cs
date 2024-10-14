using UnityEngine;
using UnityEngine.Events;

public class SocketManager : MonoBehaviour
{
    // Event that gets invoked when the socket is occupied
    [System.Serializable]
    public class SocketOccupiedEvent : UnityEvent<GameObject> { }

    public class SocketUnOccupiedEvent : UnityEvent<GameObject> { }

    public SocketOccupiedEvent onSocketOccupied;

    public SocketUnOccupiedEvent onSocketUnoccupied;

    // This will store the current object occupying the socket
    private GameObject currentOccupant;

    // Method to occupy the socket
    public void OccupySocket(GameObject occupant)
    {
        if (currentOccupant == null)
        {
            currentOccupant = occupant;
            Debug.Log($"{occupant.name} has occupied the socket.");
            onSocketOccupied.Invoke(occupant);
        }
        else
        {
            Debug.LogWarning("Socket is already occupied!");
        }
    }

    // Method to release the socket
    public void ReleaseSocket()
    {
        if (currentOccupant != null)
        {
            Debug.Log($"{currentOccupant.name} has released the socket.");
            currentOccupant = null;
            
        }
        else
        {
            Debug.LogWarning("Socket is already empty!");
        }
    }
}