

namespace Common.Enum
{
    public enum MyStatusCode
    {
        OK = 200, // а тут все ок
        BadRequst = 400, // невірні вхідні данні
        AuthorizationError = 401, // помилка авторизації
        NotFound = 404, // Сторінка не знайдена
        InternalServerError = 500, // помилка на стороні БД
    }
}
