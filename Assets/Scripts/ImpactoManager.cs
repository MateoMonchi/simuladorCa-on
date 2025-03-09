using UnityEngine;
using Firebase.Extensions;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ImpactoManager : MonoBehaviour
{
    private DatabaseManager firebaseManager;

    void Start()
    {
        firebaseManager = FindObjectOfType<DatabaseManager>();
    }
    public void Update()
    {
        
    }
    public void GuardarImpacto( float masa, float posicionX, float posicionY, float velocidad)
    {
        if (firebaseManager == null)
        {
            Debug.LogError("❌ FirebaseManager no encontrado en la escena.");
            return;
        }

        var dbReference = firebaseManager.GetDatabaseReference();
        if (dbReference == null) 
        {
            Debug.LogError("❌ No se puede guardar impacto porque Firebase aún no está listo.");
            return;
        }

        string id = dbReference.Child("impactos").Push().Key;
        ImpactoData nuevoImpacto = new ImpactoData(masa, posicionX, posicionY, velocidad);
        Debug.Log(ImpactoData.text);
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
    public float masa;
    public float x, y;
    public float velocidad;
    public static string text;

    public ImpactoData( float masa, float x, float y, float velocidad)
    {
        this.velocidad = velocidad;
        text = $" {masa}, {velocidad},{x},{y}";
        this.masa = masa;
        this.x = x;
        this.y = y;
    }
}


