-- Создание таблицы категорий
CREATE TABLE table_categories
(
	id		INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	name	TEXT NOT NULL
);

-- Создание таблицы поставщиков
CREATE TABLE table_suppliers
(
	id		INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	name	TEXT NOT NULL
);

-- Создание таблицы товаров
CREATE TABLE table_products
(
	id			INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	name		TEXT NOT NULL,
	price		DECIMAL NOT NULL,
	quantity	INT,
	category_id INT NOT NULL,
	supplier_id INT,
	FOREIGN KEY (category_id) REFERENCES table_categories (id) ON DELETE CASCADE,
	FOREIGN KEY (supplier_id) REFERENCES table_suppliers (id) ON DELETE SET NULL
);

-- Промежуточная таблица для связи М:М категорий и поставщиков
CREATE TABLE table_category_supplier
(
	category_id INT NOT NULL,
	supplier_id INT NOT NULL,
	PRIMARY KEY (category_id, supplier_id),
	FOREIGN KEY (category_id) REFERENCES table_categories (id) ON DELETE SET NULL,
	FOREIGN KEY (supplier_id) REFERENCES table_suppliers (id) ON DELETE SET NULL
);


-- Заполнение тестовыми данными

-- Добавление категорий
INSERT INTO table_categories (name)
VALUES	('Балки'),
		('Автоматика'),
		('Забор'),
		('Сваи');

-- Добавление поставщиков
INSERT INTO table_suppliers (name)
VALUES	('DoorHan'),
		('Aluteh'),
		('VladPromMet');

-- Добавление товаров
INSERT INTO table_products (name, price, quantity, category_id, supplier_id)
VALUES	('Балка 71/6000', 6500, 50, 1, 1),
		('Балка 95/9000', 20000, 5, 1, 2),
		('Привод 1300', 25000, 9, 2, 1),
		('Привод 1200', 28000, 6, 2, 2),
		('Сетка 1750*2500*4', 2000, 30, 3, 1),
		('Столб квадратный 60*60*2500', 1500, 7, 3, 2),
		('СВЛ 73*200*2000', 2000, 54, 4, 3),
		('СВШ 73*2500', 2200, 46, 4, 3),
		('Фланец 73', 280, 146, 4, 3);

-- Добавление связей категория-поставщик
INSERT INTO table_category_supplier (category_id, supplier_id)
VALUES	(1, 1),
		(1, 2),
		(2, 1),
		(2, 2),
		(3, 1),
		(3, 2),
		(4, 3)