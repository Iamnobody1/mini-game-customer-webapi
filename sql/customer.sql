<<<<<<< HEAD
<<<<<<< HEAD
CREATE TABLE public."Users" (
	"Id" varchar(36) NOT NULL,
	"Username" varchar(256) NULL,
	"Password" varchar(12) NULL,
	"DisplayName" varchar(10) NULL,
	"Avatar" varchar(256) NULL,
	CONSTRAINT "Users_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Customer" (
	"Id" int NULL,
	"Name" varchar(32) NULL,
	CONSTRAINT "Customer_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Product" (
	"Id" int NULL,
	"Name" varchar(32) NULL,
	CONSTRAINT "Product_Id_PK" PRIMARY KEY ("Id")
);

CREATE TABLE public."Order" (
	"Id" int NULL,
	"CustomerId" int NULL,
	"CreateDateUTC" timestamptz NULL,
	CONSTRAINT "Order_Id_PK" PRIMARY KEY ("Id"),
	CONSTRAINT "Order_Customer_FK" FOREIGN KEY ("CustomerId") REFERENCES "Customer" ("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE public."OrderDetail" (
	"Id" int NULL,
	"OrderId" int NULL,
	"ProductId" int NULL,
	"Quantity" int NULL,
	"UnitPrice" money NULL,
	CONSTRAINT "OrderDetail_Id_PK" PRIMARY KEY ("Id"),
	CONSTRAINT "OrderDetail_Order_FK" FOREIGN KEY ("OrderId") REFERENCES "Order" ("Id") ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT "OrderDetail_Product_FK" FOREIGN KEY ("ProductId") REFERENCES "Product" ("Id") ON DELETE CASCADE ON UPDATE CASCADE
);

ALTER TABLE public."OrderDetail"
    ADD CONSTRAINT fk_orders_customers FOREIGN KEY (customer_id) REFERENCES customers (id);

insert INTO public."Customer" ("Id", "Name")
values (1 ,'John Smith');

insert INTO public."Product" ("Id", "Name")
values (1, 'Oculus Rift');

insert INTO public."Order" ("Id", "CustomerId", "CreateDateUTC")
values (1, 1, '2016-01-01 10:00:00');

insert INTO public."OrderDetail" ("Id", "OrderId", "ProductId", "Quantity" ,"UnitPrice")
values (1, 1, 4, 1, 14000);
=======
CREATE TABLE public."Users" (
	"ID" varchar(36) NOT NULL,
	"Username" varchar(256) NULL,
	"Password" varchar(12) NULL,
	"DisplayName" varchar(10) NULL,
	"Avatar" varchar(256) NULL,
	CONSTRAINT "Users_ID_PK" PRIMARY KEY ("ID")
);
>>>>>>> demo/best2
=======
CREATE TABLE public."Users" (
    "ID" int NOT NULL,
    "Username" varchar(256) NULL,
    "Password" varchar(12) NULL,
    "DisplayName" varchar(10) NULL,
    "Avatar" varchar(256) NULL,
    CONSTRAINT "Users_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Customer" (
    "ID" int NOT NULL,
    "Name" varchar(256) null,
    CONSTRAINT "Customer_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Product" (
    "ID" int NOT NULL,
    "Name" varchar(256) null,
    CONSTRAINT "Product_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."Order" (
    "ID" int NOT NULL,
    "CustomerId" int NULL,
    "CreateDateUTC" timestamptz null,
    CONSTRAINT "Order_ID_PK" PRIMARY KEY ("ID")
);

CREATE TABLE public."OrderDetail" (
    "ID" int NOT NULL,
    "OrderId" int NULL,
    "ProductId" int NULL,
    "Quantity" int NULL,
    "UnitPrice" money null,
    CONSTRAINT "OrderDetail_ID_PK" PRIMARY KEY ("ID")
);

ALTER TABLE public."Orders" ADD CONSTRAINT "Orders_CustomerId_FK" FOREIGN KEY ("CustomerId") REFERENCES public."Customers"("Id") ON DELETE CASCADE ON UPDATE CASCADE;
ALTER TABLE public."Order" RENAME TO "Orders";
>>>>>>> demo/eikkew
