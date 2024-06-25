MVC_APU_FlowerShop2023
Project Overview
MVC_APU_FlowerShop2023 is a web application designed for managing a flower shop. The application allows users to create and manage their accounts, browse and purchase products, and administrators to manage the inventory and user data. The project is built using the ASP.NET MVC framework.

Features
User Account Management: Users can create accounts, log in, and manage their profiles.
Product Browsing: Users can browse available flower products.
Purchasing: Users can add products to their cart and proceed to checkout.
Administrative Functions: Admins can manage inventory, user data, and other backend operations.

Screenshots
![Picture1](https://github.com/Ahmed144-develop/MVC_APU_FlowerShop/assets/135183754/655a9f5a-5deb-4aae-accf-506b4197c553)
![Screenshot 2024-06-25 181244](https://github.com/Ahmed144-develop/MVC_APU_FlowerShop/assets/135183754/0b71f2e8-a8b6-4c39-a7a2-007ae232e706)




Technologies Used
ASP.NET MVC: For building the web application framework.
Entity Framework: For database management.
Microsoft SQL Server: For database storage.
HTML/CSS: For front-end design and layout.
JavaScript: For front-end functionality and interactivity.
Getting Started
To get a local copy up and running follow these simple steps.

Prerequisites
Visual Studio 2019 or later
.NET 5.0 SDK or later
SQL Server
Installation
Clone the repository

sh
Copy code
git clone https://github.com/your_username/MVC_APU_FlowerShop2023.git
Navigate to the project directory

sh
Copy code
cd MVC_APU_FlowerShop2023
Open the project in Visual Studio

Restore NuGet packages

Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution
Click on Restore to install the required packages.
Update the database connection string

Open appsettings.json and update the connection string to point to your SQL Server instance.
Apply migrations and update the database

Open the Package Manager Console and run the following commands:
sh
Copy code
Update-Database
Run the application

Press F5 or click on the IIS Express button to start the application.
Usage
Register as a new user: Click on Register as a new user link on the login page.
Manage your account: After logging in, navigate to the Manage your account page to update your profile information.
Browse products: View the list of available products on the home page.
Add to cart: Add products to your cart and proceed to checkout.
Contributing
Contributions are what make the open-source community such an amazing place to be learn, inspire, and create. Any contributions you make are greatly appreciated.

Fork the Project
Create your Feature Branch (git checkout -b feature/AmazingFeature)
Commit your Changes (git commit -m 'Add some AmazingFeature')
Push to the Branch (git push origin feature/AmazingFeature)
Open a Pull Request
