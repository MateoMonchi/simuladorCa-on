using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private DatabaseReference dbReference;
    private bool isFirebaseReady = false; 

    public static DatabaseManager Instance { get; private set; } 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
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
                isFirebaseReady = true; 
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
