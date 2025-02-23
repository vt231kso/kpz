**1. SOLID (5 принципів)**

S - Single Responsibility Principle (SRP)

Кожен клас відповідає лише за одну відповідальність:
-	[Money]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Money.cs) – зберігає інформацію про гроші.
-	[Product]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Product.cs) – представляє товар.
-	[WarehouseItem]( https://github.com/vt231kso/kpz/blob/main/task/Classes/WarehouseItem.cs) – містить інформацію про товар на складі.
-	[Warehouse]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Warehouse.cs) – керує складом.
-	[Reporting]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Reporting.cs) – відповідає за генерацію звітів.
-	[Cart]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Cart.cs) – управляє кошиком покупок.

**O - Open/Closed Principle (OCP)**

Класи розширюються, але не змінюються. Наприклад, якщо потрібно додати нову валюту, достатньо створити новий клас(наприклад [USD]( https://github.com/vt231kso/kpz/blob/main/task/Classes/USD.cs)), що реалізує [ICurrency]( https://github.com/vt231kso/kpz/blob/main/task/Interfaces/ICurrency.cs).

**L - Liskov Substitution Principle (LSP)**

Об'єкти підкласів можуть використовуватись замість батьківського класу без змін у коді. Наприклад, [EUR]( https://github.com/vt231kso/kpz/blob/main/task/Classes/EUR.cs) та [USD]( https://github.com/vt231kso/kpz/blob/main/task/Classes/USD.cs) можуть замінювати [ICurrency]( https://github.com/vt231kso/kpz/blob/main/task/Interfaces/ICurrency.cs).

**I - Interface Segregation Principle (ISP)**

Кожен інтерфейс містить лише необхідні методи. Наприклад, замінювати [ICurrency]( https://github.com/vt231kso/kpz/blob/main/task/Interfaces/ICurrency.cs) має тільки властивості Symbol і Name, без зайвих методів.

**D - Dependency Inversion Principle (DIP)**

Використання ICurrency дозволяє коду працювати із будь-якими валютами без прив'язки до конкретних класів USD або EUR.

**2. DRY (Don't Repeat Yourself)**

В коді уникається дублювання логіки:

-	Money використовується у [Product]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Product.cs#L13) замість дублювання інформації про ціну.
-	[WarehouseItem](https://github.com/vt231kso/kpz/blob/main/task/Classes/WarehouseItem.cs#L11) і [Cart]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Cart.cs#L11) працюють із Product, не дублюючи атрибути товару.

**3. KISS (Keep It Simple, Stupid)**

Код простий і зрозумілий:

- Кожен клас має чітко визначену роль.
-	Мінімум складних конструкцій, методи логічно організовані.
-	Використано зрозумілі назви змінних і методів.

**4. YAGNI (You Ain't Gonna Need It)**

В коді немає зайвого функціоналу, лише те, що потрібно:

- Наприклад, у [Warehouse]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Warehouse.cs) відсутні складні логістичні функції, поки вони не знадобляться.
-	[Cart]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Cart.cs) реалізує лише базові операції додавання та видалення товару.

**5. Composition Over Inheritance**

Класи використовують композицію, а не наслідування:

-	[WarehouseItem містить]( https://github.com/vt231kso/kpz/blob/main/task/Classes/WarehouseItem.cs#L11) Product, а не наслідується від нього.
-	[Cart]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Cart.cs#L11) використовує Dictionary<Product, int> замість створення окремого класу для кожного типу товару.

**6. Program to Interfaces, not Implementations**

-	[Money]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Money.cs#L14) працює з ICurrency, а не з конкретними валютами (USD, EUR).
-	[Warehouse]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Warehouse.cs#L11) та [Reporting]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Reporting.cs#L14) використовують об'єкти класу WarehouseItem і Product, не залежачи від конкретних реалізацій.

**7. Fail Fast**

Код одразу перевіряє неправильні вхідні дані:

-	[Money]( https://github.com/vt231kso/kpz/blob/main/task/Classes/Money.cs#L18) перевіряє, чи wholePart і cents не є від’ємними.
-	[WarehouseItem.AddStock()](https://github.com/vt231kso/kpz/blob/main/task/Classes/WarehouseItem.cs#L24-L29) і [RemoveStock()](https://github.com/vt231kso/kpz/blob/main/task/Classes/WarehouseItem.cs#L31-L37) перевіряють, чи кількість товару коректна.
-	[WarehouseItem]( https://github.com/vt231kso/kpz/blob/main/task/Classes/WarehouseItem.cs#L18-L20) кидає ArgumentNullException, якщо передано null.
