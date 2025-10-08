# E-Ticaret Mikroservis Platformu

Modern mikroservis mimarisi ile geliştirilmiş, production-ready e-ticaret platformu. Scalable, resilient ve cloud-native özelliklere sahip enterprise-grade çözüm.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/)
[![Spring Boot](https://img.shields.io/badge/Spring%20Boot-3.5.6-6DB33F)](https://spring.io/projects/spring-boot)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED)](https://www.docker.com/)

## 📋 İçindekiler

- [Mimari Genel Bakış](#mimari-genel-bakış)
- [Özellikler](#özellikler)
- [Teknolojiler](#teknolojiler)
- [Hızlı Başlangıç](#hızlı-başlangıç)
- [API Dokümantasyonu](#api-dokümantasyonu)
- [Servis Detayları](#servis-detayları)
- [Test](#test)
- [Proje İlerlemesi](#proje-i̇lerlemesi)

---

## 🏗️ Mimari Genel Bakış

```
                                    ┌─────────────────┐
                                    │   API Gateway   │
                                    │  (Port: 8080)   │
                                    └────────┬────────┘
                                             │
                    ┌────────────────────────┼────────────────────────┐
                    │                        │                        │
            ┌───────▼────────┐      ┌───────▼────────┐      ┌───────▼────────┐
            │  User Service  │      │Product Service │      │ Order Service  │
            │   (.NET 8.0)   │      │ (Spring Boot)  │      │ (Spring Boot)  │
            │  Port: 5048    │      │  Port: 8081    │      │   (Planned)    │
            └────────┬───────┘      └────────┬───────┘      └────────────────┘
                     │                       │
            ┌────────▼───────────────────────▼────────┐
            │         Service Discovery Layer          │
            │  Eureka Server (8761) + Consul (8500)   │
            └──────────────────┬───────────────────────┘
                               │
            ┌──────────────────▼───────────────────────┐
            │          Data & Message Layer            │
            │  PostgreSQL │ Redis │ RabbitMQ │ MinIO  │
            └──────────────────────────────────────────┘
```

### Mikroservisler

| Servis | Teknoloji | Durum | Port | Açıklama |
|--------|-----------|-------|------|----------|
| **User Service** | .NET Core 8.0 | ✅ Tamamlandı | 5048 | JWT authentication, kullanıcı yönetimi, profil |
| **Product Service** | Spring Boot 3.5.6 | ✅ Tamamlandı | 8081 | Ürün kataloğu, CRUD, kategori yönetimi |
| **Order Service** | Spring Boot 3.5.6 | 🔄 Planlı | 8082 | Sipariş yönetimi, Saga Pattern |
| **Payment Service** | .NET Core 8.0 | 📋 Planlı | 5049 | Ödeme işlemleri, entegrasyon |
| **Notification Service** | Node.js | 📋 Planlı | 3001 | Email, SMS, push bildirimleri |

### Altyapı Bileşenleri

| Bileşen | Versiyon | Port | Durum | Amaç |
|---------|----------|------|-------|------|
| **API Gateway** | Spring Cloud Gateway | 8080 | ✅ Aktif | Routing, load balancing, rate limiting |
| **Eureka Server** | Netflix Eureka | 8761 | ✅ Aktif | Service discovery ve registry |
| **Consul** | 1.15 | 8500 | ✅ Aktif | .NET servisleri için service discovery |
| **PostgreSQL** | 15 | 5435 | ✅ Aktif | Her servis için ayrı database |
| **Redis** | 7 | 6379 | ✅ Aktif | Caching, session management |
| **RabbitMQ** | 3 | 5672, 15672 | ✅ Aktif | Event-driven communication |
| **MinIO** | Latest | 9000, 9001 | ✅ Aktif | Object storage (S3-compatible) |
| **Prometheus** | Latest | 9090 | 🔄 Planlı | Metrics collection |
| **Grafana** | Latest | 3000 | 🔄 Planlı | Monitoring dashboards |
| **Jaeger** | Latest | 16686 | 🔄 Planlı | Distributed tracing |

---

## ✨ Özellikler

### Tamamlanan Özellikler ✅

- **Authentication & Authorization**
  - JWT-based authentication
  - Refresh token mechanism
  - Role-based access control (RBAC)
  - BCrypt password hashing

- **Service Discovery**
  - Eureka Server ile Spring servisleri otomatik kayıt
  - Consul ile .NET servisleri entegrasyonu
  - Health check mekanizması

- **API Gateway**
  - Merkezi routing yönetimi
  - Load balancing
  - Service discovery entegrasyonu
  - Health check endpoints

- **Product Management**
  - CRUD operasyonları
  - Kategori bazlı filtreleme
  - Pagination ve sorting
  - PostgreSQL persistence

- **Containerization**
  - Tüm servisler Docker-ready
  - Docker Compose orchestration
  - Multi-stage build optimization

### Geliştirme Aşamasında 🔄

- Order Service (Saga Pattern)
- Event-driven communication (RabbitMQ)
- Distributed tracing (Jaeger)
- Centralized logging (ELK Stack)

### Roadmap 📋

- Payment gateway entegrasyonu
- Notification service
- Shopping cart service
- Inventory management
- API rate limiting
- Circuit breaker pattern (Resilience4j)
- Kubernetes deployment

---

## 🛠️ Teknolojiler

### Backend Frameworks
- **.NET Core 8.0** - User Service, modern C# features
- **Spring Boot 3.5.6** - Product & Order Services
- **Spring Cloud Gateway** - API Gateway
- **Entity Framework Core** - ORM for .NET
- **Spring Data JPA** - ORM for Spring

### Security & Authentication
- **JWT (JSON Web Tokens)** - Stateless authentication
- **BCrypt** - Password hashing
- **Spring Security** - Authorization framework

### Databases & Storage
- **PostgreSQL 15** - Primary database (per service pattern)
- **Redis 7** - Caching layer
- **MinIO** - Object storage (S3-compatible)

### Message Broker & Events
- **RabbitMQ 3** - Asynchronous messaging
- Event-driven architecture pattern

### Service Discovery & Registry
- **Netflix Eureka** - Service registry for Spring services
- **Consul** - Service mesh for .NET services

### DevOps & Infrastructure
- **Docker** - Containerization
- **Docker Compose** - Multi-container orchestration
- **Prometheus & Grafana** - Monitoring (planned)
- **Jaeger** - Distributed tracing (planned)
- **ELK Stack** - Centralized logging (planned)

### Development Tools
- **Swagger/OpenAPI** - API documentation
- **Maven** - Build automation (Java)
- **.NET CLI** - Build automation (.NET)

---

## 🚀 Hızlı Başlangıç

### Gereksinimler

```
✅ Docker Desktop 20.10+
✅ .NET 8.0 SDK
✅ Java 17+ (JDK)
✅ Maven 3.8+
✅ Git
✅ 8GB+ RAM (Docker için)
```

### Kurulum

**1. Projeyi klonla**

```bash
git clone <repository-url>
cd ecommerce-microservices
```

**2. Docker altyapısını başlat**

```bash
docker-compose up -d
```

Servisler şu sırayla başlayacak:
- PostgreSQL, Redis, RabbitMQ, MinIO, Consul
- Eureka Server
- User Service, Product Service
- API Gateway

**3. Servislerin durumunu kontrol et**

```bash
docker-compose ps
```

Tüm servisler `healthy` durumda olmalı.

**4. Service Discovery Dashboard**

Eureka: http://localhost:8761

Tüm servislerin kayıtlı olduğunu göreceksiniz.

### Local Development

**User Service (.NET):**

```bash
cd services/user-service
dotnet restore
dotnet run
```

Swagger UI: http://localhost:5048/swagger

**Product Service (Spring Boot):**

```bash
cd services/product-service
./mvnw clean install
./mvnw spring-boot:run
```

Swagger UI: http://localhost:8081/swagger-ui.html

**API Gateway:**

```bash
cd infrastructure/api-gateway
./mvnw spring-boot:run
```

Health check: http://localhost:8080/actuator/health

---

## 📡 API Dokümantasyonu

### API Gateway - Ana Giriş Noktası

Tüm istekler API Gateway üzerinden yönlendirilir: `http://localhost:8080`

### User Service Routes (`/api/auth/*`)

#### Register - Yeni Kullanıcı Kaydı
```http
POST /api/auth/register
Content-Type: application/json

{
  "username": "johndoe",
  "email": "john@example.com",
  "password": "SecurePass123!",
  "firstName": "John",
  "lastName": "Doe"
}
```

**Response (201 Created):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "username": "johndoe",
  "email": "john@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "createdAt": "2025-10-08T12:00:00Z"
}
```

#### Login - Kullanıcı Girişi
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "john@example.com",
  "password": "SecurePass123!"
}
```

**Response (200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "550e8400-e29b-41d4-a716-446655440000",
  "expiresIn": 3600,
  "user": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "username": "johndoe",
    "email": "john@example.com"
  }
}
```

#### Get Profile - Kullanıcı Profili (Authentication Required)
```http
GET /api/auth/profile
Authorization: Bearer {token}
```

#### Refresh Token - Token Yenileme
```http
POST /api/auth/refresh
Content-Type: application/json

{
  "refreshToken": "550e8400-e29b-41d4-a716-446655440000"
}
```

#### Health Check
```http
GET /api/auth/health

Response: "Healthy"
```

---

### Product Service Routes (`/api/products/*`)

#### Get All Products - Tüm Ürünleri Listele
```http
GET /api/products?page=0&size=10&sort=name,asc
```

**Response (200 OK):**
```json
{
  "content": [
    {
      "id": 1,
      "name": "Laptop",
      "description": "High-performance laptop",
      "price": 999.99,
      "stock": 50,
      "category": "Electronics",
      "createdAt": "2025-10-08T12:00:00Z"
    }
  ],
  "totalElements": 1,
  "totalPages": 1,
  "size": 10,
  "number": 0
}
```

#### Get Product by ID
```http
GET /api/products/{id}
```

#### Create Product (Authentication Required)
```http
POST /api/products
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": "Laptop",
  "description": "High-performance laptop",
  "price": 999.99,
  "stock": 50,
  "category": "Electronics"
}
```

#### Update Product
```http
PUT /api/products/{id}
Authorization: Bearer {token}
Content-Type: application/json

{
  "name": "Updated Laptop",
  "price": 899.99
}
```

#### Delete Product
```http
DELETE /api/products/{id}
Authorization: Bearer {token}
```

#### Search Products by Category
```http
GET /api/products/category/{category}
```

---

## 🧪 Test

### Health Check - Tüm Servislerin Durumu

```bash
# API Gateway
curl http://localhost:8080/actuator/health

# User Service (Gateway üzerinden)
curl http://localhost:8080/api/auth/health

# Product Service (Gateway üzerinden)
curl http://localhost:8080/api/products/health

# Eureka Dashboard
curl http://localhost:8761
```

### Authentication Flow Test

**1. Kullanıcı Kaydı:**
```bash
curl -X POST http://localhost:8080/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "testuser",
    "email": "test@example.com",
    "password": "Test1234!",
    "firstName": "Test",
    "lastName": "User"
  }'
```

**2. Login:**
```bash
curl -X POST http://localhost:8080/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test@example.com",
    "password": "Test1234!"
  }'
```

Token'ı kopyala ve sonraki isteklerde kullan.

**3. Profil Getir:**
```bash
curl http://localhost:8080/api/auth/profile \
  -H "Authorization: Bearer YOUR_TOKEN_HERE"
```

### Product Service Test

**1. Ürün Oluştur:**
```bash
curl -X POST http://localhost:8080/api/products \
  -H "Authorization: Bearer YOUR_TOKEN_HERE" \
  -H "Content-Type: application/json" \
  -d '{
    "name": "Test Product",
    "description": "Test Description",
    "price": 99.99,
    "stock": 100,
    "category": "Test"
  }'
```

**2. Ürünleri Listele:**
```bash
curl http://localhost:8080/api/products
```

### Test Kullanıcıları

Önceden oluşturulmuş test hesabı:
```
Email: test@example.com
Password: Test1234
```

---

## 🗂️ Servis Detayları

### Servis Portları

| Servis/Component | Internal Port | External Port | Docker Network |
|-----------------|---------------|---------------|----------------|
| API Gateway | 8080 | 8080 | ecommerce-network |
| User Service | 5048 | 5048 | ecommerce-network |
| Product Service | 8081 | 8081 | ecommerce-network |
| Eureka Server | 8761 | 8761 | ecommerce-network |
| PostgreSQL | 5432 | 5435 | ecommerce-network |
| Redis | 6379 | 6379 | ecommerce-network |
| RabbitMQ (AMQP) | 5672 | 5672 | ecommerce-network |
| RabbitMQ (Management) | 15672 | 15672 | ecommerce-network |
| Consul | 8500 | 8500 | ecommerce-network |
| MinIO (API) | 9000 | 9000 | ecommerce-network |
| MinIO (Console) | 9001 | 9001 | ecommerce-network |

### Database Schema

Her mikroservis kendi PostgreSQL database'ini kullanır:

- `userservice` - User Service database
- `productservice` - Product Service database
- `orderservice` - Order Service database (planned)

---

## 📊 Proje İlerlemesi

### İlerleme Durumu: **%65**

#### ✅ Tamamlanan (Phase 1 & 2)

- [x] Docker altyapı kurulumu (PostgreSQL, Redis, RabbitMQ, Consul, MinIO)
- [x] Eureka Server - Service Discovery
- [x] API Gateway - Routing ve load balancing
- [x] User Service - Authentication & JWT
- [x] User Service - Docker containerization
- [x] Product Service - CRUD operasyonları
- [x] Product Service - Docker containerization
- [x] Gateway → User Service entegrasyonu
- [x] Gateway → Product Service entegrasyonu
- [x] Swagger documentation (her servis için)
- [x] Service-to-service communication temel yapısı

#### 🔄 Devam Eden (Phase 3)

- [ ] Order Service - Sipariş yönetimi
- [ ] Saga Pattern implementation
- [ ] RabbitMQ event-driven communication
- [ ] Circuit breaker pattern (Resilience4j)

#### 📋 Planlanan (Phase 4+)

- [ ] Payment Service - Ödeme entegrasyonu
- [ ] Notification Service - Email/SMS/Push
- [ ] Shopping Cart Service
- [ ] Inventory Management
- [ ] Prometheus & Grafana monitoring
- [ ] Jaeger distributed tracing
- [ ] ELK Stack centralized logging
- [ ] API rate limiting
- [ ] Kubernetes deployment manifests
- [ ] CI/CD pipeline (GitHub Actions)
- [ ] Integration tests
- [ ] Performance tests (JMeter/K6)

### Sprint Planning

**Current Sprint:** Sprint 3 (Order Service & Saga Pattern)
**Next Sprint:** Sprint 4 (Payment & Notification Services)

---

## 🐳 Docker Komutları

### Temel İşlemler

```bash
# Tüm servisleri başlat
docker-compose up -d

# Belirli bir servisi başlat
docker-compose up -d user-service

# Logları canlı izle
docker-compose logs -f

# Belirli bir servisin loglarını izle
docker-compose logs -f user-service

# Çalışan container'ları listele
docker-compose ps

# Servisleri durdur
docker-compose stop

# Servisleri durdur ve container'ları sil
docker-compose down

# Servisleri durdur, container'ları ve volume'leri sil
docker-compose down -v

# Image'leri yeniden build et
docker-compose build

# Image'leri build et ve servisleri başlat
docker-compose up -d --build
```

### Debugging

```bash
# Container içine bash ile gir
docker exec -it user-service bash

# Container'ın resource kullanımını gör
docker stats

# Belirli bir container'ın detaylı bilgisi
docker inspect user-service

# Network bilgilerini gör
docker network ls
docker network inspect ecommerce-network
```

### Maintenance

```bash
# Kullanılmayan image'leri temizle
docker image prune -a

# Kullanılmayan volume'leri temizle
docker volume prune

# Sistemi temizle (dikkatli kullan!)
docker system prune -a --volumes
```

---

## 🔧 Troubleshooting

### Yaygın Sorunlar ve Çözümleri

**1. Port çakışması:**
```bash
# Kullanılan portları kontrol et
netstat -ano | findstr :8080

# Alternatif: Docker portlarını değiştir
# docker-compose.yml dosyasında port mapping'i değiştir
```

**2. Service discovery çalışmıyor:**
```bash
# Eureka dashboard'u kontrol et
http://localhost:8761

# Servisin Eureka'ya kayıt olup olmadığını kontrol et
docker-compose logs eureka-server
docker-compose logs user-service
```

**3. Database bağlantı hatası:**
```bash
# PostgreSQL'in çalıştığını kontrol et
docker-compose ps postgres

# Database loglarını kontrol et
docker-compose logs postgres

# Container'a bağlan ve database'i kontrol et
docker exec -it postgres psql -U admin -d userservice
```

**4. Out of memory:**
```bash
# Docker'a daha fazla RAM ayır
# Docker Desktop → Settings → Resources → Memory
```

---

## 📚 Ek Kaynaklar

### Dokümantasyon
- [Swagger - User Service](http://localhost:5048/swagger)
- [Swagger - Product Service](http://localhost:8081/swagger-ui.html)
- [Eureka Dashboard](http://localhost:8761)
- [RabbitMQ Management](http://localhost:15672) (guest/guest)
- [MinIO Console](http://localhost:9001) (minioadmin/minioadmin)

### Repository Yapısı

```
ecommerce-microservices/
├── infrastructure/
│   ├── api-gateway/          # Spring Cloud Gateway
│   ├── eureka-server/        # Service Discovery
│   └── docker-compose.yml    # Orchestration
├── services/
│   ├── user-service/         # .NET Core 8.0
│   ├── product-service/      # Spring Boot
│   └── order-service/        # (Planned)
├── docs/                     # Additional documentation
├── scripts/                  # Utility scripts
├── .gitignore
├── README.md
└── LICENSE
```

---

## 🤝 Katkıda Bulunma

1. Fork the repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

---

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

---

## 📞 İletişim

Project Link: [https://github.com/username/ecommerce-microservices](https://github.com/username/ecommerce-microservices)

---

## 🏆 Teşekkürler

Bu proje, modern mikroservis mimarisini öğrenmek ve uygulamak amacıyla geliştirilmiştir. Şu teknolojileri kullanarak:

- Spring Cloud ekosistemi
- .NET Core mikroservis best practices
- Docker containerization
- Service mesh patterns

---

**Son Güncelleme:** 8 Ekim 2025  
**Versiyon:** 0.6.5-alpha  
**Durum:** Active Development 🚀
