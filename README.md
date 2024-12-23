# GtMotive.Renting

## Descripción del Proyecto
GtMotive.Renting es un sistema modular y escalable diseñado para gestionar de manera eficiente el proceso de alquiler de vehículos. Este sistema utiliza una arquitectura modular basada en los principios de **Clean Architecture** para garantizar la separación de responsabilidades, alta mantenibilidad y escalabilidad.

El proyecto está compuesto por tres módulos principales:
- **Vehicles**: Gestiona la flota de vehículos y sus categorías.
- **Rentals**: Administra las reservas y los alquileres de los vehículos.
- **Customers**: Maneja la información y las actividades de los clientes.

Cada módulo está diseñado para ser desacoplado y organizado en capas según los principios de Clean Architecture, asegurando independencia y flexibilidad en su desarrollo.

---

## Arquitectura
El sistema está construido utilizando los principios de **Clean Architecture**, organizando el código en capas para maximizar la independencia de los módulos y reducir el acoplamiento entre ellos.

### Tecnologías Utilizadas
- **Framework**: .NET Core
- **Base de Datos**: PostgreSQL
- **Cache Distribuida**: Redis
- **Mensajería**: RabbitMQ (para soporte de patrones de integración interna si es necesario)
- **Contenedores**: Docker

### Diagrama de Arquitectura
El sistema está compuesto por los siguientes componentes organizados según los principios de Clean Architecture:
1. **Vehicles**: Módulo para gestionar la flota de vehículos y sus categorías.
2. **Rentals**: Módulo para administrar las reservas y alquileres.
3. **Customers**: Módulo para manejar la información de los clientes y su historial.
4. **Distributed Cache**: Redis para acelerar el acceso a datos frecuentemente solicitados.
5. **Message Broker**: RabbitMQ para la comunicación eventual entre procesos internos.

---

## Funcionalidades

### Módulo: Vehicles
- **Crear Vehículo**: Registro de nuevos vehículos en la flota.
- **Consultar Vehículos**: Listado de vehículos disponibles para alquiler.
- **Gestionar Categorías**: Creación y consulta de categorías de vehículos.

### Módulo: Rentals
- **Crear Reserva**: Permite a los clientes reservar un vehículo disponible.
- **Iniciar Alquiler**: Inicia el proceso de alquiler de un vehículo.
- **Finalizar Alquiler**: Registra la devolución del vehículo y cierra el alquiler.

### Módulo: Customers
- **Registrar Cliente**: Creación de perfiles de clientes.
- **Consultar Clientes**: Obtener información de los clientes registrados.
- **Registrar Actividad**: Historial de interacciones y actividades de los clientes.

---

## Reglas de Negocio
1. Un vehículo no puede ser alquilado si su antigüedad supera los 5 años desde su fecha de fabricación.
2. Solo los vehículos con estado `disponible` pueden ser reservados o alquilados.
3. Los clientes deben estar en estado `activo` para realizar reservas o alquileres.

---

## Arquitectura del Sistema

![Diagrama de Arquitectura](assets/ArchitectureDiagram.png)

