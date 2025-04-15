
using Domain.Entity.User;

namespace Common.Enum
{
    public enum AuthStatus
    {
        IncorrectPassword,
        NotConfirmedPassword,
        UserNotFound,
        UsernameIsTaken,
        EmailIsAlredyRegister,
        AuthServerError,
        AuthSuccess,

        TokenRefreshFailed,
        TokenRefreshSuccess,
    }
}
