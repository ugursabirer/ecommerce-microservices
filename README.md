# E-Ticaret Mikroservis Platformu

Modern mikroservis mimarisi ile geliştirilmiş, production-ready e-ticaret platformu.

## Mimari

### Mikroservisler
- User Service: .NET Core 8.0 - JWT authentication, kullanıcı yönetimi
- API Gateway: Spring Cloud Gateway - Routing, load balancing
- Eureka Server: Netflix Eureka - Service discovery

### Altyapı
- Databases: PostgreSQL (per service)
- Cache: Redis
- Message Broker: RabbitMQ
- Service Discovery: Eureka (Spring), Consul (.NET)
- Monitoring: Prometheus, Grafana, Jaeger, ELK Stack
- Storage: MinIO (S3-compatible)

## Hızlı Başlangıç

### Gereksinimler
- Docker Desktop 20.10+
- .NET 8.0 SDK
- Java 17+
- Git

### Kurulum

1. Projeyi klonla
git clone repository-url
cd ecommerce-microservices

2. Tüm servisleri Docker ile başlat
docker-compose up -d

3. Servislerin durumunu kontrol et
docker-compose ps

### Local Development

User Service (.NET):
cd services/user-service
dotnet run
Swagger: http://localhost:5048/swagger

API Gateway (Spring Boot):
cd infrastructure/api-gateway
./mvnw spring-boot:run
Health: http://localhost:8080/actuator/health

## API Endpoints

### API Gateway (Port: 8080) - Ana Giriş Noktası

User Service Routes:
- POST /api/auth/register - Yeni kullanıcı kaydı
- POST /api/auth/login - Kullanıcı girişi
- POST /api/auth/refresh - Token yenileme
- GET /api/auth/profile - Kullanıcı profili (auth gerekli)
- GET /api/auth/health - Health check

### Test Kullanıcıları

Test:
email: test@excample.com
password: Test1234

## Teknolojiler

Backend: .NET Core 8.0, Spring Boot 3.5.6, Spring Cloud Gateway, Entity Framework Core, JWT Authentication, BCrypt

Infrastructure: Docker, PostgreSQL 15, Redis 7, RabbitMQ 3, Eureka Server, Consul

Monitoring: Prometheus, Grafana, Jaeger, ELK Stack

## Servis Portları

API Gateway: 8080
User Service: 5048
Eureka Server: 8761
PostgreSQL: 5435
Redis: 6379
RabbitMQ: 15672
Consul: 8500
Grafana: 3000

## Proje İlerlemesi

Tamamlanan:
- Docker altyapı kurulumu
- User Service (Authentication & JWT)
- Eureka Server (Service Discovery)
- API Gateway (Routing)
- Gateway → User Service entegrasyonu

Devam Eden:
- Product Service (Spring Boot)
- Order Service (Saga Pattern)
- Payment Service
- Notification Service

İlerleme: %35

## Test

Health check:
curl http://localhost:8080/api/auth/health

Login:
curl -X POST http://localhost:8080/api/auth/login -H "Content-Type: application/json" -d '{"email":"test@example.com","password":"Test1234"}'

## Docker Komutları

Tüm servisleri başlat: docker-compose up -d
Logları izle: docker-compose logs -f service-name
Servisleri durdur: docker-compose down
Servisleri durdur ve verileri sil: docker-compose down -v

## Lisans

MIT License

Son Güncelleme: 5 Ekim 2025
Versiyon: 0.3.0-alpha