using UnityEngine;
using Firebase.Extensions;


public class ImpactoManager : MonoBehaviour
{
    private DatabaseManager firebaseManager;

    void Start()
    {
        firebaseManager = FindObjectOfType<DatabaseManager>();
    }

    public void GuardarImpacto(float angulo, float fuerza, Vector3 posicion, float velocidad)
    {
        if (firebaseManager == null)
        {
            Debug.LogError("❌ FirebaseManager no encontrado en la escena.");
            return;
        }

        var dbReference = firebaseManager.GetDatabaseReference();
        if (dbReference == null) // 🔹 Evita el error si Firebase no está listo
        {
            Debug.LogError("❌ No se puede guardar impacto porque Firebase aún no está listo.");
            return;
        }

        string id = dbReference.Child("impactos").Push().Key;
        ImpactoData nuevoImpacto = new ImpactoData(angulo, fuerza, posicion, velocidad);
        string json = JsonUtility.ToJson(nuevoImpacto);

        dbReference.Child("impactos").Child(id).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
                Debug.Log("✅ Impacto guardado en Firebase");
            else
                Debug.LogError("❌ Error al guardar impacto: " + task.Exception);
        });
    }
}

[System.Serializable]
public class ImpactoData
{
    public float angulo;
    public float fuerza;
    public float x, y, z;
    public float velocidad;

    public ImpactoData(float angulo, float fuerza, Vector3 posicion, float velocidad)
    {
        this.angulo = angulo;
        this.fuerza = fuerza;
        this.x = posicion.x;
        this.y = posicion.y;
        this.z = posicion.z;
        this.velocidad = velocidad;
    }
}


