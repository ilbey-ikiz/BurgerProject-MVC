# Burger Orderin Website

An online food ordering platform is created using a robust tech stack, combining MVC architecture, Entity Framework, SQL Server, C#, Javascript, AJAX, CSS, Bootstrap, HTML, and Identity authentication. Users can conveniently access the system by registering and logging in. Once logged in, they can easily browse through the available menus and food items and add their desired selections to the shopping cart. The user-friendly interface allows seamless updates to personal information, and a comprehensive order history feature enables users to review their past orders.

The system also incorporates an admin interface with special privileges. Admins can log in to the system and efficiently manage the menus and products. This includes adding new items, removing outdated ones, and editing existing offerings, ensuring that the platform remains up-to-date and appealing to customers.

- Project developed with MVC ASP.NET Core 6, Identity and Code-First approach.
- Language : C# , Javascript
- Database : MS SQL Server
- ORM Tool : Entity Framework Core
- Front-End : CSS, Bootstrap, AJAX, HTML

<div align="center">
<h4>Website working video</h4>
<a href="https://youtu.be/90h5cqSFVzo" target="_blank">
 <img src="GitImages/youtube.png" alt="Watch the video" width="600" height="350"/>
</a>
</div>

### Home

The home page that welcomes the user. On this page, the user can view general information and learn about some menus.  
![Home](/GitImages/HomePage1.png)
![Home](/GitImages/HomePage2.png)

### Login

The user can add the products to the basket by logging in only from the login page.
![Login](/GitImages/Login.png)

### Register

User registration page. The user enters the site automatically after registering by entering the required information.  
![Register](/GitImages/Register.png)

### Prodcut (User)

The user can view all the products on the product page. The user can select the desired products and add them to his shopping cart. The user can go to the payment screen by clicking the view card button in the shopping cart window.  
![ProductUser](/GitImages/Products.png)  
![ProductUser](/GitImages/selectProduct.png)

### Prodcut – Add Menu (User)

The window where the user makes menu selections while adding a menu to his shopping cart on the product page. The bootstrap modal structure was used for this window.  
![ProductUserAddMenu](/GitImages/addBurger.png)  
![ProductUserAddMenu](/GitImages/addMenu.png)  
![ProductUserAddMenu](/GitImages/addProduct.png)

### Cart

On the cart page, we can see the products we have added to the cart, and if we want, we can delete them or place an order with a chekout.
![Cart](/GitImages/cart.png)

### Checkout

We can create our order by choosing one of our registered addresses on the chekout page, specifying the payment method and, if we wish, by writing a message about the order.
![Checkout](/GitImages/checkout.png)

### User Settings

We can update our information on the user settings page. We can add a new address, change and delete our old addresses. Ajax technology has been used extensively for this page.
![UserSettings](/GitImages/usersettings1.png)
![UserSettings](/GitImages/usersettings2.png)

### Order History

We can see the orders we have placed on the order history page and we can see the details of our order with the order detail modal that opens with the modal structure.
![OrderHistory](/GitImages/orderhistory.png)
![OrderDetail](/GitImages/orderdetail.png)

### Admin Page

In this window on the product page, the admin can create a new menu and new product.The admin can determine the products to be found in the menu and the side dishes to be found in the hamburger.
![Admin](/GitImages/admin1.png)
![Admin](/GitImages/admin2.png)
![Admin](/GitImages/admin3.png)

### Admin All Orders Page

By going to the admin all orders page, he can see all the orders and their details in the restaurant.
![AdminAllOrders](/GitImages/admin4.png)
![AdminAllOrders](/GitImages/admin5.png)

### Business Income Report Page

With the reports page, you can see the daily, weekly, monthly and total earnings of the business and reach the information of how many of the products were sold.
![AdminReportsPage](/GitImages/admin6.png)  
![AdminReportsPage](/GitImages/admin9.png)
