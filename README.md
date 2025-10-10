# Healt-Clinict
# Health Clinic Management System
# Health Clinic Management System

## Description

The **Health Clinic Management System** is a veterinary clinic management system that allows managing clients, pets, veterinarians, and appointments. Through this system, users can perform the following operations:
- Register and manage clients and their pets.
- Manage veterinarian information.
- Schedule, view, reserve, and cancel appointments.
- View available appointment calendars.

The system is designed to run in a console and simulates an in-memory database using static lists.

## Features

- **Client Management**: Allows registering, updating, and deleting clients, as well as viewing their information.
- **Pet Management**: Allows registering pets, associating them with clients, and viewing their information.
- **Veterinarian Management**: Allows managing the clinic's veterinarians' information.
- **Appointment Management**: Allows viewing, reserving, and canceling appointments for clients and their pets with available veterinarians.
- **Appointment Calendar**: Allows generating and displaying the appointment calendar by month and day, with reservation options.

## Project Structure

### Main Classes:
- **`Customer`**: Represents a client of the clinic.
- **`Pet`**: Represents a pet that belongs to a client.
- **`Veterinarian`**: Represents a veterinarian in the clinic.
- **`Appointment`**: Represents a reserved appointment at the clinic.
- **`AppointmentSystem`**: Manages the creation, reservation, and viewing of appointments.
- **`ReservationsSystem`**: Manages appointments, displaying calendars, and reserving appointments.
- **`Warehouse`**: Acts as an in-memory database, managing clients, pets, veterinarians, and appointments.
- **`Menu`**: Console user interface for navigating the system's options.

### Functionalities:
1. **Client Management**:
   - Register clients with personal data and associated pets.
   - View, update, and delete client information.
   
2. **Pet Management**:
   - Register, view, and update pet information.
   
3. **Veterinarian Management**:
   - Register, view, update, and delete veterinarian information.
   
4. **Appointment Management**:
   - Automatically generate appointments by month and year.
   - View available appointments and reserve them for a client, a pet, and a veterinarian.
   - View reserved appointments.

5. **Calendar**:
   - Display appointment calendars by month and day, allowing users to select and reserve appointments.

## Requirements

This project was developed in **C#** and requires the following tools to run:
- **.NET Core 3.1 or higher**: To run the project in a C# development environment.
- **Recommended IDE**: [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/).

## Installation

1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/David-SilvaDEV/Healt-Clinict.git


//---------------------------------------------------------------------------------------------------------------------------------------------
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