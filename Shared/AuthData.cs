using System;

namespace Shared
{

    public class AuthData
    {
        public string UserId { get; }
        public bool LoggedIn { get; }
        public DateTime ExpiryDate { get; }

        public void Deconstruct(out bool isLoggedIn, out double expiryDate) => 
            (isLoggedIn, expiryDate) = (LoggedIn, ExpiryDate.ToOADate());
    }
}
