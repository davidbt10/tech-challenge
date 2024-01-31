using System.ComponentModel;

namespace PI.Domain.Enum
{
    public enum PermissionTypes
    {
        [Description("Administrator")]
        Administrator = 1,

        [Description("Analist")]
        Analist = 2,

        [Description("Customer")]
        Customer = 3
    }

    public static class Permissions
    {
        public const string Administrator = "Administrator";
        public const string Analist = "Analist";
        public const string Customer = "Customer";
    }
}
