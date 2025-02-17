using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private DatabaseReference dbReference;
    private bool isFirebaseReady = false; // Verifica si Firebase está listo

    public static DatabaseManager Instance { get; private set; } // Singleton opcional

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Opcional para mantener Firebase en todas las escenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                FirebaseApp app = FirebaseApp.DefaultInstance;
                dbReference = FirebaseDatabase.DefaultInstance.RootReference;
                isFirebaseReady = true; // ✅ Firebase está listo
                Debug.Log("✅ Firebase inicializado correctamente.");
            }
            else
            {
                Debug.LogError("❌ Firebase no está disponible: " + task.Result);
            }
        });
    }

    public DatabaseReference GetDatabaseReference()
    {
        if (!isFirebaseReady)
        {
            Debug.LogError("❌ Firebase aún no está listo. Inténtalo más tarde.");
            return null;
        }
        return dbReference;
    }

    public bool IsFirebaseReady()
    {
        return isFirebaseReady;
    }
}
