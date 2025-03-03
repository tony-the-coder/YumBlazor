namespace YumBlazor.Services
{
    //This class manages and notifies the state of the cart count
    public class SharedStateService
    {
        public event Action OnChange;
        private int _totalCartCount;

        public int TotalCartCount
        {
            get => _totalCartCount;
            set
            {
                _totalCartCount = value;
               NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}
