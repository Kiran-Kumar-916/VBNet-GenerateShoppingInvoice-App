# VBNet-GenerateShoppingInvoice-App

## Project Overview
This Project is designed to handle essential e-commerce functions, with a focus on flexibility in product and customer management, as well as sophisticated discount and tax handling. The modular approach of managing each aspect (products, categories, customers) through separate forms ensures scalability and maintainability of the application.

1. Home Window
   
      •	Features: The homepage serves as the control center for managing the core data of the application, including Products, Categories, and Customers.

      •	Actions Available:

	Create: Add new products, categories, or customers to the system.
	Update: Modify existing entries for products, categories, or customers.
	Delete: Remove products, categories, or customers from the system.
        Product has as attributes like:  
                name	description	category	price	quantity	discount rate
        Categoy has as attributes like:  
                name	description	tax rate
        Customer has as attributes like: 
                name	email	address	contact num

      •	Implementation: Each of these actions is managed via separate forms to keep the data handling clean and modular.

2. Cart Window
   
      •	Purpose: The cart window allows users to add products from the available stock to their shopping cart.
   
      •	Key Functionality:
	Displays the available products in stock.
	Allows the user to add selected products to the cart for purchase.

4. Payment Window
   
      •	Purpose: The payment window handles the final calculation of the order total, incorporating discounts and taxes. And shows option to proceed payment by selecting one of the payment option.
   
      •	Key Features:
	Percentage Discounts: Each product may have a percentage discount applied during calculation.
	Tax Application: Tax is applied based on the category of the product.
	Flat Discount: If a coupon code is entered and the total order amount is greater than Rs.500, a flat discount of Rs.500 is applied.
(Example coupen code considered here as ‘FLAT500‘)

6. Invoice Generation Window
   
      •	Purpose: Once the payment process is completed, an invoice is generated.
   
      •	Key Features:
	Customer Details: Displays the relevant customer information.
	Purchased Products: Lists all the products included in the order.
	Discount and Tax Breakdown: Shows the discounts (both percentage and flat) and the taxes applied to each product.
	Final Amount: The total payable amount after all discounts and taxes are factored in.





## Instruction to Run the Application :
The application is built using Visual Basic .NET and uses CSV files for data storage. To successfully run the application, please ensure the following:
1.	Required CSV Files:
	The following three CSV files should be present in the application directory (i.e., the directory where the executable file is located):
      1.	Products.csv
      2.	Categories.csv
      3.	Customers.csv
         
	Each of these file should contain the appropriate header row.

2.	Unique ID Column:
	In this project, the first column in all three tables (Products.csv, Categories.csv, Customers.csv) is considered a unique ID.
	"Name" is used as the unique ID in all three tables.

3.	Sample Files:
   
	1.  Empty Database: Sample CSV files with no data (only headers) are provided in the ‘Empty Database’ folder within the application directory.

	2.  Sample Database: Sample CSV files with data (headers and sample data) are available in the ‘Sample Database’ folder.

	You can use these sample files to run and test the functionality of the application.

5.	Icons:
	An ‘Icons’ folder is required to load icons for the application. This folder must also be placed in the application directory.
	The ‘Icons’ folder, containing 3 image files, is already provided in the application directory.

6.	Project Documentation:
	For a more detailed overview of the project, you can refer to the ‘Project Overview.docx’ file included in the application directory.
By following these instructions, you should be able to run the application and explore its features effectively.



## About Forms and Classes

Forms and Classes are organized as follows:

FormHome.vb: Homepage.

FormProducts.vb: Form used for adding, updating, and deleting products.

FormCategories.vb: Form used for adding, updating, and deleting categories.

FormCustomers.vb: Form used for adding, updating, and deleting customer details.

FormCart.vb: Form used for the shopping cart feature.

FormPayment.vb: Form used to show selected products and payment details with discounts and tax.

FormInvoice.vb: Form used to show the final invoice after payment.

CommonClasses.vb: All the commonly used reusable classes are placed here.

This setup ensures that each form and class is clearly defined with its respective functionality.


