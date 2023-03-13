create database  Store;
use Store;
drop database  Store;

# TABLE MClient
CREATE TABLE IF NOT EXISTS MClient(
    IdClient INT NOT NULL AUTO_INCREMENT,
    DNI VARCHAR(20) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Direction VARCHAR(100) NOT NULL,
    Phone VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    City VARCHAR(50),
    PRIMARY KEY(idClient),
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

insert into  MClient(dni, firstname, lastname, direction, phone, email, city)
values('1721457495', 'jorge', 'loor', 'libertad del toachi', '0960806054', 'erudito@gmail.com', 'quito'),
    ('123456789', 'erudito', 'the boss', 'santo domingo', '0960806054', 'theboss@gmail.com', 'cuenca');


# TABLE MProduct
CREATE TABLE IF NOT EXISTS MProduct(
        IdProduct INT NOT NULL AUTO_INCREMENT,
        NameProduct VARCHAR(50) NOT NULL,
        CodeProduct VARCHAR(60) NOT NULL,
        Brand VARCHAR(60) NOT NULL,
        Description VARCHAR(100) NOT NULL,
        Quantity INT NOT NULL,
        P_Unitary FLOAT NULL,
        Image_Product VARCHAR(300) NOT NULL,
        PRIMARY KEY(IdProduct),
        created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
        updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
    );

insert into  MProduct(NameProduct, CodeProduct, Brand, Description, Quantity, P_Unitary, Image_Product)
values('chupete', '3123', 'Plop', 'Dulce 125', 5, 2.50, 'img'),
    ('papas', '32sad4', 'lays', '124 gr', 5, 2.50, 'img'),
    ('cerveza', '324ds', 'pilsener', 'Litrona', 1, 2.50, 'img');


# TABLE MCompany
CREATE TABLE IF NOT EXISTS MCompany(
        IdCompany INT NOT NULL AUTO_INCREMENT,
        NameCompany VARCHAR(50) NOT NULL,
        NameOwner varchar(60) NOT NULL,
        Direction VARCHAR(60) NOT NULL,
        Email VARCHAR(100) NOT NULL,
        RUC VARCHAR(50) NOT NULL,
        Phone VARCHAR(50) NOT NULL,
        numDocument INT(100) NOT NULL,
        Serie1 VARCHAR(10) NOT NULL,
        Serie2 VARCHAR(10) NOT NULL,
        Document VARCHAR(100) NOT NULL,
        DB VARCHAR(60) NOT NULL,
        Iva FLOAT(10, 2) NOT NULL,
        Coin VARCHAR(50) NOT NULL,
        PRIMARY KEY(IdCompany),
        created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
        updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
    );

insert into MCompany(NameCompany, NameOwner, Direction, Email, RUC, Phone, numDocument, Serie1, Serie2, Document, DB, Iva, Coin)
values('Buy Here', 'Jorge Loor', 'Libertad del toachi', 'erudito', '2125454', '066', 1233, '001', '002', 'factura', 'firebase', 0.12, 'dollar');


# TABLE MAuth
CREATE TABLE IF NOT EXISTS MAuth(
    IdAuth INT NOT NULL AUTO_INCREMENT,
    User VARCHAR(50),
    Email VARCHAR(50) NOT NULL unique key,
    Password VARCHAR(50) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY(IdAuth)
);

# TABLA CARRITO DE COMPRAS
CREATE TABLE IF NOT EXISTS MCart(
    IdCart INT NOT NULL AUTO_INCREMENT,
    IdClient INT NOT NULL,
    IdProduct INT NOT NULL,
    P_Total FLOAT(10, 2) NOT NULL,
    PRIMARY KEY(IdCart),
    FOREIGN KEY(IdClient) REFERENCES MClient(IdClient),
    FOREIGN KEY(IdProduct) REFERENCES MProduct(IdProduct)
);

# TABLA DETALLE DE LA COMPRA
CREATE TABLE IF NOT EXISTS MDetailCart(
    IdDetailCart INT NOT NULL AUTO_INCREMENT,
    IdCart INT NOT NULL,
    Date_Now VARCHAR(50) NOT NULL,
    Hour_Now VARCHAR(50) NOT NULL,
    Subtotal FLOAT(10, 2) NOT NULL,
    Subtotal12 FLOAT(10, 2) NOT NULL,
    SubTotal0 FLOAT(10, 2) NOT NULL,
    IvaTotal  FLOAT(10, 2) NOT NULL,
    Total FLOAT(10, 2) NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    PRIMARY KEY(IdDetailCart),
    FOREIGN KEY(IdCart) REFERENCES MCart(IdCart)
);


CREATE TABLE IF NOT EXISTS MCodeApp(
    IdCode INT NOT NULL AUTO_INCREMENT  PRIMARY KEY,
    CodeAdmin INT UNIQUE NOT NULL
);

drop table MClient;
drop table  MProduct;
drop table  MCompany;
drop table MCart;
drop table MDetailCart;
drop table MAuth;
drop table MCodeApp;



var resultado = await FilePicker.PickAsync();
if (resultado != null) {
    var stream = await resultado.OpenReadAsync();
    var bytes = new byte[stream.Length];
    await stream.ReadAsync(bytes, 0, (int)stream.Length);
        string base64 = Convert.ToBase64String(bytes);
    var imagen = new Imagen { ImagenBase64 = base64 };
    var conexion = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "database.db3"));
    await conexion.CreateTableAsync<Imagen>();
    await conexion.InsertAsync(imagen);
}


public async Task < ImageSource > ConvertirBase64(string base64)
{
    try {
        byte[] bytes = Convert.FromBase64String(base64);
        Stream stream = new MemoryStream(bytes);
        return ImageSource.FromStream(() => stream);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return null;
    }
}


string base64 = "TU_CADENA_BASE64";
ImageSource imagen = await ConvertirBase64(base64);
MiImagen.Source = imagen;