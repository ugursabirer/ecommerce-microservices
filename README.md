# E-Ticaret Mikroservis Platformu

Modern mikroservis mimarisi ile geliştirilmiş e-ticaret platformu.

## 🏗️ Mimari

- **User Service**: .NET Core 8.0 - Kullanıcı yönetimi ve authentication
- **Altyapı**: PostgreSQL, Redis, RabbitMQ, Consul

## 🚀 Başlangıç

### Gereksinimler
- Docker Desktop
- .NET 8.0 SDK
- Git

### Kurulum

1. Projeyi klonla:
git clone <repository-url>
cd ecommerce-microservices

2. Altyapıyı başlat:
docker-compose up -d

3. User Service'i çalıştır:
cd services/user-service
dotnet run

4. Swagger UI:
http://localhost:5048/swagger

## 📡 API Endpoints

### User Service (Port: 5048)

- POST /api/auth/register - Kullanıcı kaydı
- POST /api/auth/login - Kullanıcı girişi
- GET /api/auth/health - Health check

## 🔧 Teknolojiler

- .NET Core 8.0
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- BCrypt
- Docker & Docker Compose

## 📊 İlerleme

- [x] Altyapı kurulumu
- [x] User Service (Register, Login)
- [ ] API Gateway
- [ ] Product Service
- [ ] Order Service

## 🌐 Servis Portları

- User Service: 5048
- PostgreSQL: 5435
- Redis: 6379
- RabbitMQ Management: 15672
- Consul: 8500