# E-Ticaret Mikroservis Platformu

Modern mikroservis mimarisi ile geliştirilmiş, production-ready e-ticaret platformu.

## 🏗️ Mimari

### Mikroservisler
- **User Service**: .NET Core 8.0 - JWT authentication, kullanıcı yönetimi
- **API Gateway**: Spring Cloud Gateway - Routing, load balancing
- **Eureka Server**: Netflix Eureka - Service discovery

### Altyapı
- **Databases**: PostgreSQL (per service)
- **Cache**: Redis
- **Message Broker**: RabbitMQ
- **Service Discovery**: Eureka (Spring), Consul (.NET)
- **Monitoring**: Prometheus, Grafana, Jaeger, ELK Stack
- **Storage**: MinIO (S3-compatible)

## 🚀 Hızlı Başlangıç

### Gereksinimler
- Docker Desktop 20.10+
- .NET 8.0 SDK
- Java 17+ (Spring servisleri için)
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