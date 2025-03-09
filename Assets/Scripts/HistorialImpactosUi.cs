using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;

public class HistorialImpactosUi : MonoBehaviour
{
    public Button btnHistorial;
    public Text historialText;

    private DatabaseManager firebaseManager;

    void Start()
    {
        firebaseManager = FindObjectOfType<DatabaseManager>();

        if (btnHistorial != null)
        {
            btnHistorial.onClick.AddListener(ObtenerImpactos);
        }
    }

    public void ObtenerImpactos()
    {
        if (firebaseManager == null || !firebaseManager.IsFirebaseReady())
        {
            Debug.LogError("❌ Firebase aún no está listo. Esperando inicialización...");
            return;
        }

        var dbReference = firebaseManager.GetDatabaseReference();
        if (dbReference == null)
        {
            Debug.LogError("❌ No se puede obtener el historial porque Firebase aún no está inicializado.");
            return;
        }

        dbReference.Child("impactos").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("❌ Error al obtener datos: " + task.Exception);
                return;
            }

            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                List<string> impactosLista = new List<string>();

                foreach (var impacto in snapshot.Children)
                {
                    string json = impacto.GetRawJsonValue();
                    ImpactoData datos = JsonUtility.FromJson<ImpactoData>(json);
                    string impactoTexto = $"Ángulo: {datos.angulo}, Fuerza: {datos.masa}, Pos: ({datos.x}, {datos.y}, {datos.z}), Vel: {datos.velocidad}";
                    impactosLista.Add(impactoTexto);
                }

                historialText.text = string.Join("\n", impactosLista);
                Debug.Log(historialText.text);
            }
        });
    }
}
