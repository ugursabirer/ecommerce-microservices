# E-Commerce Microservices Platform

A production-ready e-commerce platform built with modern microservices architecture. Scalable, resilient, and cloud-native enterprise-grade solution.

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/)
[![Spring Boot](https://img.shields.io/badge/Spring%20Boot-3.5.6-6DB33F)](https://spring.io/projects/spring-boot)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED)](https://www.docker.com/)

## 📋 Table of Contents

- [Architecture Overview](#architecture-overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Quick Start](#quick-start)
- [API Documentation](#api-documentation)
- [Service Details](#service-details)
- [Testing](#testing)
- [Project Progress](#project-progress)

---

## 🏗️ Architecture Overview

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

### Microservices

| Service | Technology | Status | Port | Description |
|---------|-----------|--------|------|-------------|
| **User Service** | .NET Core 8.0 | ✅ Completed | 5048 | JWT authentication, user management, profile |
| **Product Service** | Spring Boot 3.5.6 | ✅ Completed | 8081 | Product catalog, CRUD, category management |
| **Order Service** | Spring Boot 3.5.6 | 🔄 Planned | 8082 | Order management, Saga Pattern |
| **Payment Service** | .NET Core 8.0 | 📋 Planned | 5049 | Payment processing, integration |
| **Notification Service** | Node.js | 📋 Planned | 3001 | Email, SMS, push notifications |

### Infrastructure Components

| Component | Version | Port | Status | Purpose |
|-----------|---------|------|--------|---------|
| **API Gateway** | Spring Cloud Gateway | 8080 | ✅ Active | Routing, load balancing, rate limiting |
| **Eureka Server** | Netflix Eureka | 8761 | ✅ Active | Service discovery and registry |
| **Consul** | 1.15 | 8500 | ✅ Active | Service discovery for .NET services |
| **PostgreSQL** | 15 | 5435 | ✅ Active | Separate database per service |
| **Redis** | 7 | 6379 | ✅ Active | Caching, session management |
| **RabbitMQ** | 3 | 5672, 15672 | ✅ Active | Event-driven communication |
| **MinIO** | Latest | 9000, 9001 | ✅ Active | Object storage (S3-compatible) |
| **Prometheus** | Latest | 9090 | 🔄 Planned | Metrics collection |
| **Grafana** | Latest | 3000 | 🔄 Planned | Monitoring dashboards |
| **Jaeger** | Latest | 16686 | 🔄 Planned | Distributed tracing |

---

## ✨ Features

### Completed Features ✅

- **Authentication & Authorization**
  - JWT-based authentication
  - Refresh token mechanism
  - Role-based access control (RBAC)
  - BCrypt password hashing

- **Service Discovery**
  - Automatic registration with Eureka Server for Spring services
  - Consul integration for .NET services
  - Health check mechanism

- **API Gateway**
  - Centralized routing management
  - Load balancing
  - Service discovery integration
  - Health check endpoints

- **Product Management**
  - CRUD operations
  - Category-based filtering
  - Pagination and sorting
  - PostgreSQL persistence

- **Containerization**
  - All services Docker-ready
  - Docker Compose orchestration
  - Multi-stage build optimization

### In Development 🔄

- Order Service (Saga Pattern)
- Event-driven communication (RabbitMQ)
- Distributed tracing (Jaeger)
- Centralized logging (ELK Stack)

### Roadmap 📋

- Payment gateway integration
- Notification service
- Shopping cart service
- Inventory management
- API rate limiting
- Circuit breaker pattern (Resilience4j)
- Kubernetes deployment
- CI/CD pipeline (GitHub Actions)
- Integration tests
- Performance tests (JMeter/K6)

---

## 🛠️ Tech Stack

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

## 🚀 Quick Start

### Prerequisites

```
✅ Docker Desktop 20.10+
✅ .NET 8.0 SDK
✅ Java 17+ (JDK)
✅ Maven 3.8+
✅ Git
✅ 8GB+ RAM (for Docker)
```

### Installation

**1. Clone the repository**

```bash
git clone <repository-url>
cd ecommerce-microservices
```

**2. Start Docker infrastructure**

```bash
docker-compose up -d
```

Services will start in this order:
- PostgreSQL, Redis, RabbitMQ, MinIO, Consul
- Eureka Server
- User Service, Product Service
- API Gateway

**3. Check service status**

```bash
docker-compose ps
```

All services should be in `healthy` state.

**4. Service Discovery Dashboard**

Eureka: http://localhost:8761

You should see all services registered.

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

## 📡 API Documentation

### API Gateway - Main Entry Point

All requests are routed through API Gateway: `http://localhost:8080`

### User Service Routes (`/api/auth/*`)

#### Register - New User Registration
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

#### Login - User Authentication
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

#### Get Profile - User Profile (Authentication Required)
```http
GET /api/auth/profile
Authorization: Bearer {token}
```

#### Refresh Token - Token Renewal
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

#### Get All Products - List All Products
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

## 🧪 Testing

### Health Check - All Services Status

```bash
# API Gateway
curl http://localhost:8080/actuator/health

# User Service (via Gateway)
curl http://localhost:8080/api/auth/health

# Product Service (via Gateway)
curl http://localhost:8080/api/products/health

# Eureka Dashboard
curl http://localhost:8761
```

### Authentication Flow Test

**1. User Registration:**
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

Copy the token and use it in subsequent requests.

**3. Get Profile:**
```bash
curl http://localhost:8080/api/auth/profile \
  -H "Authorization: Bearer YOUR_TOKEN_HERE"
```

### Product Service Test

**1. Create Product:**
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

**2. List Products:**
```bash
curl http://localhost:8080/api/products
```

### Test Users

Pre-created test account:
```
Email: test@example.com
Password: Test1234
```

---

## 🗂️ Service Details

### Service Ports

| Service/Component | Internal Port | External Port | Docker Network |
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

Each microservice uses its own PostgreSQL database:

- `userservice` - User Service database
- `productservice` - Product Service database
- `orderservice` - Order Service database (planned)

---

## 📊 Project Progress

### Current Progress: **65%**

#### ✅ Completed (Phase 1 & 2)

- [x] Docker infrastructure setup (PostgreSQL, Redis, RabbitMQ, Consul, MinIO)
- [x] Eureka Server - Service Discovery
- [x] API Gateway - Routing and load balancing
- [x] User Service - Authentication & JWT
- [x] User Service - Docker containerization
- [x] Product Service - CRUD operations
- [x] Product Service - Docker containerization
- [x] Gateway → User Service integration
- [x] Gateway → Product Service integration
- [x] Swagger documentation (for each service)
- [x] Service-to-service communication foundation

#### 🔄 In Progress (Phase 3)

- [ ] Order Service - Order management
- [ ] Saga Pattern implementation
- [ ] RabbitMQ event-driven communication
- [ ] Circuit breaker pattern (Resilience4j)

#### 📋 Planned (Phase 4+)

- [ ] Payment Service - Payment integration
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

## 🐳 Docker Commands

### Basic Operations

```bash
# Start all services
docker-compose up -d

# Start specific service
docker-compose up -d user-service

# Follow logs live
docker-compose logs -f

# Follow specific service logs
docker-compose logs -f user-service

# List running containers
docker-compose ps

# Stop services
docker-compose stop

# Stop and remove containers
docker-compose down

# Stop, remove containers and volumes
docker-compose down -v

# Rebuild images
docker-compose build

# Build and start services
docker-compose up -d --build
```

### Debugging

```bash
# Enter container with bash
docker exec -it user-service bash

# View container resource usage
docker stats

# Detailed container information
docker inspect user-service

# View network information
docker network ls
docker network inspect ecommerce-network
```

### Maintenance

```bash
# Clean unused images
docker image prune -a

# Clean unused volumes
docker volume prune

# Clean system (use carefully!)
docker system prune -a --volumes
```

---

## 🔧 Troubleshooting

### Common Issues and Solutions

**1. Port conflicts:**
```bash
# Check used ports
netstat -ano | findstr :8080

# Alternative: Change Docker ports
# Modify port mapping in docker-compose.yml
```

**2. Service discovery not working:**
```bash
# Check Eureka dashboard
http://localhost:8761

# Check if service registered with Eureka
docker-compose logs eureka-server
docker-compose logs user-service
```

**3. Database connection error:**
```bash
# Check PostgreSQL is running
docker-compose ps postgres

# Check database logs
docker-compose logs postgres

# Connect to container and check database
docker exec -it postgres psql -U admin -d userservice
```

**4. Out of memory:**
```bash
# Allocate more RAM to Docker
# Docker Desktop → Settings → Resources → Memory
```

---

## 📚 Additional Resources

### Documentation
- [Swagger - User Service](http://localhost:5048/swagger)
- [Swagger - Product Service](http://localhost:8081/swagger-ui.html)
- [Eureka Dashboard](http://localhost:8761)
- [RabbitMQ Management](http://localhost:15672) (guest/guest)
- [MinIO Console](http://localhost:9001) (minioadmin/minioadmin)

### Repository Structure

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

## 🤝 Contributing

1. Fork the repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

---

## 📄 License

This project is licensed under the MIT License. See [LICENSE](LICENSE) file for details.

---

## 📞 Contact

Project Link: [https://github.com/username/ecommerce-microservices](https://github.com/username/ecommerce-microservices)

---

## 🏆 Acknowledgments

This project was developed to learn and implement modern microservices architecture using:

- Spring Cloud ecosystem
- .NET Core microservice best practices
- Docker containerization
- Service mesh patterns

---

**Last Updated:** October 8, 2025  
**Version:** 0.6.5-alpha  
**Status:** Active Development 🚀
