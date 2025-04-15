




INSERT INTO Rol (NombreRol) VALUES ('Usuario');
INSERT INTO Rol (NombreRol) VALUES ('Administrador');

-- Inserción en la tabla Usuario (Incluyendo un administrador)
INSERT INTO Usuario (Nombre, Apellido, Correo, Contraseña, RolID, Direccion, Telefono) VALUES 
('Admin', 'Admin', 'admin@example.com', 'admin123', 2, 'Dirección Admin', '123456789'),
('Juan', 'Perez', 'juan.perez@example.com', 'password123', 1, 'Calle 123', '987654321'),
('Maria', 'Gomez', 'maria.gomez@example.com', 'password123', 1, 'Avenida 456', '456789123'),
('Carlos', 'Lopez', 'carlos.lopez@example.com', 'password123', 1, 'Calle 789', '321654987'),
('Ana', 'Ramirez', 'ana.ramirez@example.com', 'password123', 1, 'Calle 321', '654987321'),
('Pedro', 'Sanchez', 'pedro.sanchez@example.com', 'password123', 1, 'Avenida 987', '789123456'),
('Laura', 'Fernandez', 'laura.fernandez@example.com', 'password123', 1, 'Calle 654', '951753852'),
('Jose', 'Diaz', 'jose.diaz@example.com', 'password123', 1, 'Calle 852', '753951258'),
('Lucia', 'Torres', 'lucia.torres@example.com', 'password123', 1, 'Avenida 741', '852369147'),
('Roberto', 'Castro', 'roberto.castro@example.com', 'password123', 1, 'Calle 369', '147258369');

-- Inserción en la tabla Categoria
INSERT INTO Categoria (Nombre) VALUES 
('Electrónica'),
('Hogar'),
('Ropa'),
('Deportes'),
('Juguetes'),
('Belleza'),
('Automotriz'),
('Libros'),
('Muebles'),
('Mascotas');

-- Inserción en la tabla Producto
INSERT INTO Producto (Nombre, Descripcion, Precio, CategoriaID, ImagenURL, Descuento) VALUES 
('Laptop', 'Laptop de alto rendimiento', 1200.00, 1, 'https://www.cqnetcr.com/72888-large_default/laptop-hp-245-g7-14-amd-a4-9125-4gb-500gb-w10.jpg', 0),
('Televisor', 'Televisor 4K de 55 pulgadas', 800.00, 1, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNAzQoy-zXx5BVNSdrQWuax3ZV9WkC7NcfVw&s', 0),
('Sofá', 'Sofá de tres plazas', 500.00, 9, 'https://walmartcr.vtexassets.com/arquivos/ids/481899/Sof-Cama-Mainstays-Con-Patas-De-Pl-stico-1-74327.jpg?v=638371068146900000', 50),
('Zapatillas', 'Zapatillas deportivas', 100.00, 4, 'https://images-cdn.ubuy.cr/64a22f03b3ae7769e250b492-zapatos-de-hombre-zapatillas-deportivas.jpg', 10),
('Perfume', 'Perfume floral', 60.00, 6, 'https://cdn.shortpixel.ai/spai3/q_lossy+ret_img+to_webp/holacompras.com/wp-content/uploads/2023/12/PERF-AG-SWTCNDY-2.jpg', 0),
('Libro', 'Novela de ciencia ficción', 30.00, 8, 'https://www.comunidadbaratz.com/wp-content/uploads/Instrucciones-a-tener-en-cuenta-sobre-como-se-abre-un-libro-nuevo.jpg', 5),
('Coche de juguete', 'Juguete a escala', 20.00, 5, 'https://walmartcr.vtexassets.com/arquivos/ids/720604/80672_01.jpg?v=638627082647630000', 0),
('Aspiradora', 'Aspiradora potente', 250.00, 2, 'https://tienda.pequenomundo.com/media/catalog/product/1/0/10030322_03.jpg', 15),
('Collar para perro', 'Collar ajustable', 15.00, 10, 'https://media.aldoshoes.com/v3/product/galine/970/galine_multi_970_main_rc_gy_700x889.jpg', 0),
('Aceite para motor', 'Aceite sintético', 40.00, 7, 'https://www.recetasnestlecam.com/sites/default/files/2023-03/diferentes-tipos-de-aceite-para-cocinar_0.jpg', 5);


-- Inserción en la tabla Inventario
INSERT INTO Inventario (ProductoID, Cantidad) VALUES 
(1, 10),
(2, 15),
(3, 5),
(4, 20),
(5, 25),
(6, 12),
(7, 30),
(8, 8),
(9, 50),
(10, 18);

-- Inserción en la tabla Factura
INSERT INTO Factura (UsuarioID, Total, Estado, MetodoPago) VALUES 
(2, 1300.00, 'Pagado', 'Tarjeta de Crédito'),
(3, 500.00, 'Pendiente', 'Efectivo'),
(4, 120.00, 'Pagado', 'PayPal'),
(5, 30.00, 'Cancelado', 'Transferencia'),
(6, 40.00, 'Pagado', 'Tarjeta de Débito'),
(7, 200.00, 'Pendiente', 'Tarjeta de Crédito'),
(8, 300.00, 'Pagado', 'Efectivo'),
(9, 60.00, 'Pendiente', 'PayPal'),
(10, 90.00, 'Pagado', 'Transferencia'),
(2, 15.00, 'Pagado', 'Tarjeta de Débito');

-- Inserción en la tabla DetalleFactura
INSERT INTO DetalleFactura (FacturaID, ProductoID, Cantidad, PrecioUnitario, Subtotal) VALUES 
(1, 1, 1, 1200.00, 1200.00),
(1, 2, 1, 100.00, 100.00),
(2, 3, 1, 500.00, 500.00),
(3, 4, 2, 60.00, 120.00),
(4, 6, 1, 30.00, 30.00),
(5, 10, 1, 40.00, 40.00),
(6, 5, 4, 50.00, 200.00),
(7, 8, 1, 300.00, 300.00),
(8, 7, 3, 20.00, 60.00),
(9, 9, 6, 15.00, 90.00);

