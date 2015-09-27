namespace CampanhaBD.Interface
{
    public interface IUnityOfWork
    {
        void Commit();

        void RollBack();
    }
}
