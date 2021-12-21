# AtYourDoor_TechCareer_Project
### ASP.Net 5 Restful API TeachCareer Camp Final Project
### This API is the backend of the MVC project, which includes the following features.
#### Thanks to Akın Karabulut for all &#128516;

# The Project The Immediate Door 
The aim of the project is that users can order the products on the application at the time they want, to the address they want in the fastest way. 
With the application, services will be provided to the provinces and regions determined beforehand. The application will send the products ordered by each member customer, depending on the business rules. Members will only be able to pay by credit card. The supply of products is out of scope. 
- Users will become a member of the system after completing the membership form and confirming their e-mails. • When members log in to the site, the home screen will appear. 
- Product categories will appear on the home screen, and members will be able to view the products and prices by clicking on the category they want. 
- Members will be able to add the products they want to their baskets, and as they add products, the amount will increase in the basket icon on the main screen. 
- When they go to the basket, they will be able to see the products, prices, quantities and total amount they have chosen. • There will be options to increase or decrease the amount of products in the basket, and the basket amount will change accordingly. 
- When members approve the cart, a payment screen will appear. On this screen, existing card information will appear if it is defined before, and if it is not, add card information button will appear. • When members click on the My Account tab, they will be able to see and edit their profile, past orders, address and card information if they wish. 
- The orders placed by the members will be entered into the system of the supply point officer, the officer will see and prepare the order from there and direct the courier when ready. 
- The courier will be able to see the orders forwarded to him through the system. 
- When the courier delivers the product, it will enter it into the system. 
- The system will keep order and delivery time information. 
- In the system, administrators and members will only be able to see their own pages.
## User Types 
UserUser is the DescriptionMember user who can see the products and place an order through the application.
- The Supply Point  
-Officer
is the person who displays and prepares the orders given over the application, reports that they are prepared, and directs the couriers.
- Cargo is 
the person who takes the orders from the supply point and takes them to the customer.
- Admin is the 
system administrator.



## Usage Scenarios 
- Signing 
Up On the page opened via the Sign Up link when the site is opened, there are fields for name, surname, e-mail address, password and password repeat. All of these fields are required. Password must be at least 8 characters and contain uppercase, lowercase and numbers. After the user enters the information, he completes the registration and completes the registration. 
- Member Login Login to the 
system via the login screen when the site is opened. Member, Supply Point Officer, Carrier and Admin type users click on the Login button after entering the mail and password information registered in the system.  
- Members log in with the e-mail and password information they provided during registration. Users of the Supply Point Officer and Carrier type log in with their e-mail addresses and the password assigned to them by the Admin user. At their first login, the system directs them to the password change screen and asks them to set a new password that consists of at least 8 characters and includes uppercase, lowercase letters and numbers. The admin user, on the other hand, logs into the system with the mail and password information created while the system was standing up. 
- Only one user account is defined for each e-mail address. 
- Product Operations The 
- Admin user carries out the operations related to the products and categories defined in the system through the menu presented to him. It handles adding, updating and removing categories. Adds, updates and removes products. 
- Categories have only names, and a name identifies only one category. 
- Products have name, price, discounted price, description and image. Each product has a category. There is only one product with the same name in the system. If the discount price field is left blank, itdiscountfor that product 
means that nocan be made. For products that do not have an image, a standard image is presented to users of the Member type as "Preparing Image". 
- “Are you sure?” in category and product removals. A warning screen appears. If confirmation is given on this screen, the process is completed. The information of the removed categories and products is not removed from the old orders. 
- Ordering If 
the users of the Member type who log into the system have at least one registered address, they will see the categories and products on the homepage. They can add the products they want to their baskets. If there is no registered address in the system, first of all, the necessary screen for adding addresses is displayed. 
The city list is presented on the address adding screen. According to the selection made here, the district list of the relevant city is presented. After the district selection, information such as neighborhood, street and address description is entered in the detailed address information field, and the address adding process is completed. 
- Member type users can add as many address information as they want to the system. Users with more than one address information, when they log in, first choose the address to order. 
- Members can see the products they have added when they click on their carts. If the basket is not empty, they complete the ordering process by saying confirm the order. Members can see the status of their orders. When the order is created successfully, the status will be "Preparing". When the order is prepared and the courier is assigned, it changes to "On the Road". In addition, the member can view the information of the courier who brought the order. 
- Order Preparation and Delivery 
- Orders successfully created by the Member are entered into the system of the Supply Center Officer type user. Displays pending orders for preparation when this user logs in to the system. After preparing the order, it directs the relevant courier for delivery by pressing the "Prepared" button and choosing from the courier list. 
- When the user of the type of Supply Center Officer directs the order he has prepared to the courier, it falls into the system of the user of the courier type. When the courier user logs in, it displays the orders directed to him. The courier goes to the relevant address and delivers the order. Then it marks the order as “Delivered” on its own screen. When it cannot deliver, it changes the order status by selecting the relevant one among the "Address Missing / Incorrect" or "Member Wasn't at Address" situations. The Member who placed the order also displays these order statuses on his own screen. 
- Employee Registration In the 
system, there are employees of the type of Supply Center Officer and Carrier. The Admin user adds these employees to the system by choosing from the menus presented to him. Admin can see all employees as well as remove those who quit from the system. 
- When adding employees, enter the relevant information in the name, surname, date of birth, phone number, e-mail and password fields and click the "Add" button. When the adding process is successful, an e-mail containing the login information is sent to the e-mail address of the employee.

