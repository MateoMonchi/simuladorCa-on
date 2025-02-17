using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;

public class historialimpacto : MonoBehaviour
{
    private DatabaseManager firebaseManager;

    void Start()
    {
        firebaseManager = FindObjectOfType<DatabaseManager>();
    }

    public void ObtenerImpactos()
    {
        if (firebaseManager == null)
        {
            Debug.LogError("FirebaseManager no encontrado en la escena.");
            return;
        }

        var dbReference = firebaseManager.GetDatabaseReference();
        dbReference.Child("impactos").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (var impacto in snapshot.Children)
                {
                    string json = impacto.GetRawJsonValue();
                    ImpactoData datos = JsonUtility.FromJson<ImpactoData>(json);
                    Debug.Log($"Impacto: Ángulo {datos.angulo}, Fuerza {datos.fuerza}, Posición ({datos.x}, {datos.y}, {datos.z}), Velocidad {datos.velocidad}");
                }
            }
            else
            {
                Debug.LogError("Error al obtener datos: " + task.Exception);
            }
        });
    }
}
