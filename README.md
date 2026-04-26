# SMS Service

Тестовый SMS сервис для [auth-service-2](https://github.com/talerok/auth-service-2).

Не отправляет реальные SMS — сохраняет сообщения в SQLite и отображает их в веб-интерфейсе.

## API

### POST /api/sms/send

Принимает SMS-запрос и сохраняет его в базе данных.

**Body:**
```json
{
  "requestId": "string",
  "phone": "string",
  "message": "string"
}
```

**Response:**
```json
{ "status": "delivered" }
```

### GET /

Веб-интерфейс со списком последних 100 входящих SMS.

## Запуск

```bash
docker-compose up --build
```

Сервис будет доступен на `http://localhost:5075`.

## Лицензия

[MIT](LICENSE)
