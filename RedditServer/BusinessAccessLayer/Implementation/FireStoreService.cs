using BusinessAccessLayer.Abstraction;
using Google.Cloud.Firestore;

namespace BusinessAccessLayer.Implementation;

public class FireStoreService : IFireStoreService
{
    #region Properties

    private readonly FirestoreDb _fireStoreDb;

    #endregion Properties

    #region Constructor

    public FireStoreService(FirestoreDb fireStoreDb)
    {
        _fireStoreDb = fireStoreDb;
    }

    #endregion Constructor

}