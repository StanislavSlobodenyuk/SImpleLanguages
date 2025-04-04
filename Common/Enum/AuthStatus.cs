
using Domain.Entity.User;

namespace Common.Enum
{
    public enum AuthStatus
    {
        IncorrectPassword,
        UserNotFound,
        UsernameIsTaken,
        EmailIsAlredyRegister,
        AuthServerError,
        AuthSuccess,

        TokenRefreshFailed,
        TokenRefreshSuccess,
    }
}
