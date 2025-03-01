CREATE DATABASE G3_PROGRA_AVANZADA;
GO
USE G3_PROGRA_AVANZADA;

-- Tabla de Roles
CREATE TABLE Rol (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol NVARCHAR(50) NOT NULL
);

-- Tabla de Usuarios
CREATE TABLE Usuario (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    Contraseña NVARCHAR(255) NOT NULL,
    RolID INT NOT NULL FOREIGN KEY REFERENCES Rol(RolID),
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    Activo BIT NOT NULL DEFAULT 1, -- 1: Activo, 0: Inactivo
    Direccion NVARCHAR(255) NULL,
    Telefono NVARCHAR(20) NULL
);

-- Tabla de Categorías
CREATE TABLE Categoria (
    CategoriaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
);

-- Tabla de Productos
CREATE TABLE Producto (
    ProductoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(MAX) NULL,
    Precio DECIMAL(10,2) NOT NULL,
    CategoriaID INT NOT NULL FOREIGN KEY REFERENCES Categoria(CategoriaID),
    ImagenURL NVARCHAR(255) NULL,
    FechaAgregado DATETIME NOT NULL DEFAULT GETDATE(),
    Descuento DECIMAL(10,2) NULL DEFAULT 0 -- En caso de promos
);

-- Tabla de Inventario
CREATE TABLE Inventario (
    InventarioID INT IDENTITY(1,1) PRIMARY KEY,
    ProductoID INT NOT NULL FOREIGN KEY REFERENCES Producto(ProductoID),
    Cantidad INT NOT NULL CHECK (Cantidad >= 0)
);

-- Tabla de Facturas 
CREATE TABLE Factura (
    FacturaID INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioID INT NOT NULL FOREIGN KEY REFERENCES Usuario(UsuarioID),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL DEFAULT 'Pendiente', -- Pendiente, Pagado, Cancelado
    MetodoPago NVARCHAR(50) NOT NULL
);

-- Tabla Detalle de Factura 
CREATE TABLE DetalleFactura (
    DetalleID INT IDENTITY(1,1) PRIMARY KEY,
    FacturaID INT NOT NULL FOREIGN KEY REFERENCES Factura(FacturaID),
    ProductoID INT NOT NULL FOREIGN KEY REFERENCES Producto(ProductoID),
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL
);
