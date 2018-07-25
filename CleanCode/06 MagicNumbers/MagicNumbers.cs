
namespace CleanCode.MagicNumbers
{
    public class MagicNumbers
    {
        public void ApproveDocument(int status)
        {
            if (status == (int)DocumentStatus.Pending)
            {
                // ...
            }
            else if (status == (int)DocumentStatus.Completed)
            {
                // ...
            }
        }

        public void RejectDoument(string status)
        {
            if (status == DocumentStatus.Pending.ToString())
            {
                // ...
            }
            else if (status == DocumentStatus.Completed.ToString())
            {
                // ...
            }
        }
    }

    public enum DocumentStatus
    {
        Pending = 1,
        Completed = 2
    }
}
