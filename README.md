# Healt-Clinict
# Health Clinic Management System

## Descripción

El proyecto **Health Clinic Management System** es un sistema de gestión para una clínica veterinaria, que permite gestionar clientes, mascotas, veterinarios y citas. A través de este sistema, los usuarios pueden realizar las siguientes operaciones:
- Registrar y gestionar clientes y sus mascotas.
- Gestionar la información de veterinarios.
- Agendar, consultar, reservar y cancelar citas.
- Ver calendarios de citas disponibles.

El sistema está diseñado para ser ejecutado en una consola y simula una base de datos en memoria mediante listas estáticas.

## Características

- **Gestión de clientes**: Permite registrar, actualizar y eliminar clientes, así como visualizar su información.
- **Gestión de mascotas**: Permite registrar mascotas, asociarlas a los clientes, y ver su información.
- **Gestión de veterinarios**: Permite gestionar la información de los veterinarios de la clínica.
- **Gestión de citas**: Permite ver, reservar y cancelar citas para los clientes y sus mascotas con los veterinarios disponibles.
- **Calendario de citas**: Permite generar y mostrar el calendario de citas por mes y día, con opciones de reserva.

## Estructura del Proyecto

### Clases principales:
- **`Customer`**: Representa a un cliente de la clínica.
- **`Pet`**: Representa a una mascota que pertenece a un cliente.
- **`Veterinarian`**: Representa a un veterinario de la clínica.
- **`Appointment`**: Representa una cita reservada en la clínica.
- **`AppointmentSystem`**: Gestiona la creación, reserva y consulta de citas.
- **`ReservationsSystem`**: Permite gestionar las citas, mostrando calendarios y reservando citas.
- **`Warehouse`**: Actúa como una base de datos en memoria, gestionando los clientes, mascotas, veterinarios y citas.
- **`Menu`**: Interfaz de usuario en consola para navegar entre las opciones del sistema.

### Funcionalidades:
1. **Gestión de Clientes**:
   - Registrar cliente con datos personales y mascotas asociadas.
   - Ver, actualizar y eliminar información de clientes.
   
2. **Gestión de Mascotas**:
   - Registrar, ver y actualizar la información de las mascotas.
   
3. **Gestión de Veterinarios**:
   - Registrar, ver, actualizar y eliminar la información de los veterinarios.
   
4. **Gestión de Citas**:
   - Generar citas automáticamente por mes y año.
   - Consultar citas disponibles y reservarlas para un cliente, una mascota y un veterinario.
   - Ver citas reservadas.

5. **Calendario**:
   - Mostrar calendario de citas por mes y día, permitiendo a los usuarios elegir y reservar citas.

## Requisitos

Este proyecto fue desarrollado en **C#** y necesita las siguientes herramientas para ejecutarse:
- **.NET Core 3.1 o superior**: Para ejecutar el proyecto en un entorno de desarrollo de C#.
- **IDE recomendada**: [Visual Studio](https://visualstudio.microsoft.com/es/) o [Visual Studio Code](https://code.visualstudio.com/).

## Instalación

1. Clona este repositorio a tu máquina local:
   ```bash
   git clone hthttps://github.com/David-SilvaDEV/Healt-Clinict.git
