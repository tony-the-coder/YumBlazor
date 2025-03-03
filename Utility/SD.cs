namespace YumBlazor.Utility
//This is a static class that will hold all the static details
//of the application.For example, the roles of the users, the session keys, etc.
//This class will be used to avoid hardcoding the values in the application.
{
    public class SD
    {
        public static string Role_Admin = "Admin";
        public static string Role_Customer = "Customer";

        public static string StatusPending = "Pending";
        public static string StatusReadyForPickup = "ReadyForPickup";
        public string StatusCompleted = "Completed";
        public static string StatusCancelled = "Cancelled";
    }
}
