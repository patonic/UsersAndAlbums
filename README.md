# UsersAndAlbums
Пути:
1. Список всех пользователей - https://{хост}:5001/api/user
2. Пользователь по id - https://{хост}:5001/api/user/{id}
3. Список всех альбомов - https://{хост}:5001/api/album
4. Альбом по id - https://{хост}:5001/api/album/{id}
5. Список всех альбомов по id пользователя - https://{хост}:5001/api/user/{id}

Формат выходных данных:

API умеет возвращать данные в формате JSON и XML. Для выбора формата используйте Accept в заголовке запроса (соответственно Accept: application/json для JSON и Accept: application/xml для XML). Формат по умолчанию JSON. 

Возвращаемые значения:

Структура данных пользователей и альбомов полностью соответствует источнику. В случае если должен возвращаться массив объектов, а он окажется пустым, то будет возвращен пустой массив. В случае же с единичными объектами, при отсутствии его в источнике, будет возвращена пустота.

Защита данных:

Для защиты данных от перехвата и различных атак MITM используется HTTPS. Для защиты доступа к API можно включить аутентификацию.
