# Proyecto Trainingym

Este proyecto es una aplicación web desarrollada en **.NET** que utiliza el patrón **MVC** (Modelo-Vista-Controlador) y la inyección de dependencias para crear un monolito. El objetivo es proporcionar una solución rápida y sencilla para desplegar proyectos en .NET y otros lenguajes.

## Características

- **Monolito**: He optado por un enfoque monolítico para simplificar el desarrollo y la implementación inicial. Sin embargo, estoy consciente de que si la aplicación crece y se espera un alto tráfico (más de 70,000 usuarios), consideraré migrar a microservicios.
- **Inyección de Dependencias**: Utilizo la inyección de dependencias para gestionar las dependencias y mejorar la modularidad del código.
- **Swagger**: La documentación del código está integrada mediante **Swagger**, lo que me permite documentar y probar fácilmente las API que desarrollo.
- **DTOs (Objetos de Transferencia de Datos)**: He implementado DTOs como una capa adicional de seguridad. Esto ayuda a evitar la ingeniería inversa a la base de datos y protege la integridad de los datos.
- **Diseño de la Base de Datos**:
    - Los nombres de las variables en la base de datos siguen una convención específica: `[nombre de tabla]_[nombre de variable]`. Esto facilita la comprensión y mantiene la coherencia en el código.
    - La tabla **Order** representa una relación de muchos a muchos entre usuarios y productos. Algunos puntos clave:
        - Un usuario puede estar asociado con varios productos.
        - Un producto puede estar asociado con múltiples usuarios.
        - La tabla **Order** nos permite consultar productos por usuario o usuarios por producto, según el ID proporcionado.
    - Las restricciones de datos son las siguientes:
        - El campo `name` está limitado a **500 caracteres**.
        - Los IDs son de tipo **long int**.
        - La fecha se almacena como **smallDatetime2(0)**.

## Configuración

Para ejecutar el proyecto localmente, sigue estos pasos:

1. Clona este repositorio.
2. Abre la solución en Visual Studio o tu IDE preferido.
3. Configura la cadena de conexión a la base de datos en `appsettings.json`.
4. Ejecuta las migraciones para crear la base de datos.
5. Inicia la aplicación y accede a la URL local.

## Consideraciones
En cuanto al uso de herramientas como AutoMapper, he optado por evitar su uso en este proyecto debido a la simplicidad de las estructuras y la falta de necesidad de mapeos extensos. Sin embargo, reconozco que en casos de estructuras más grandes o complejas, consideraría configurar AutoMapper para facilitar el mapeo entre objetos.

## Contribuciones

¡Estoy abierto a contribuciones! Si deseas colaborar, crea un *pull request* y estaré encantado de revisarlo.

