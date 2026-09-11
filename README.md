# Arriba Eats

A console-based food-ordering system written in C# (.NET 8). It supports three
kinds of users — **Customers** who browse restaurants and place orders,
**Clients** who own a restaurant and manage its menu and orders, and
**Deliverers** who pick up and deliver orders. All data is held in memory for the
duration of a single run.

## Build & run

```bash
cd Arriba_Eats/app
dotnet run
```

> **Note on .NET version.** The project targets `net8.0`. If only a newer runtime
> is installed (this machine has .NET 10), `<RollForward>LatestMajor</RollForward>`
> in [`app.csproj`](app.csproj) lets it run on the newest installed major runtime
> without changing the target framework.

## Project layout

| Path | Contents |
|------|----------|
| `Program.cs` | Entry point: welcome menu, login, registration dispatch |
| `Classes/Users/` | `User` base class and `Customer` / `Client` / `Deliverer` |
| `Classes/` | `Restaurant`, `Order`, `OrderItem`, `Location`, `Ratings` |
| `Menus/` | Role-specific interactive menus |
| `Datas/` | In-memory stores for users, restaurants, orders, ratings |
| `assets/` | Screenshots used below |

## Classes

### `User` (abstract) — [Classes/Users/User.cs](Classes/Users/User.cs)
Base class for every account. Holds `Name`, `Age`, `Email`, `Mobile_Number`,
`Password`, and `IsLoggedin`, plus shared `Login`/`Logout` logic (a plain
email+password match). `SignUp()` and `Details()` are `abstract` — every
subclass must provide its own registration flow and detail summary.

- **`Customer`** — [Classes/Users/customer.cs](Classes/Users/customer.cs)
  Places orders. Adds a `Location` (`AddressCoordinates`, defaults to `(0,0)`)
  and a `CurrentOrder`. `SignUp()` asks for `X,Y` coordinates before
  registering.
- **`Client`** — [Classes/Users/client.cs](Classes/Users/client.cs)
  Owns exactly one `Restaurant` (`GetRestaurant`). `SignUp()` collects the
  restaurant's name, `CuisineType`, and `Location`, constructs the
  `Restaurant`, and registers both the restaurant and the client.
- **`Deliverer`** — [Classes/Users/deliverer.cs](Classes/Users/deliverer.cs)
  Delivers orders. Adds a `Location` (also defaults to `(0,0)`, and — unlike
  `Customer`'s — is settable, since a deliverer's position updates as they
  move), a `LicencePlate`, a `DelivererStatus` (`Free` / `AtRestaurant` /
  `HeadingToCustomer`), and the `Order` currently being carried.

### `Restaurant` — [Classes/Restaurant/Restaurant.cs](Classes/Restaurant/Restaurant.cs)
Owned by one `Client`; has a `Restaurant_Location`, a `CuisineType`, a `Menu`
(`List<MenuItem>`), and `Restaurant_Rating()`, which averages every `Rating`
left on its past orders (`0.0` if it has none).

### `MenuItem` — [Classes/Restaurant/MenuItem.cs](Classes/Restaurant/MenuItem.cs)
A `Name` + `Price` pair a client adds to their restaurant's menu.

### `Order` / `OrderItem` — [Classes/Order.cs](Classes/Order.cs), [Classes/OrderItem.cs](Classes/OrderItem.cs)
An `Order` links a `Customer`, a `Restaurant`, an optional `Deliverer`, and a
list of `OrderItem`s (`MenuItem` + quantity), and tracks an `OrderStatus`
(`Ordered → Cooking → Cooked → BeingDelivered → Delivered`). `TotalPrice`
sums each item's `Subtotal` (`Price * Quantity`).

### `Rating` — [Classes/Ratings.cs](Classes/Ratings.cs)
A score (+ optional comment) a `Customer` leaves on a `Restaurant` after an
order, used by `Restaurant.Restaurant_Rating()`.

### `Location` — [Classes/Location.cs](Classes/Location.cs)
A simple `(X, Y)` coordinate pair with one behaviour, `DistanceTo(other)`,
which returns the **Manhattan distance** (`|dx| + dy|`, not straight-line):

```csharp
public double DistanceTo(Location other) =>
    Math.Abs(this.X - other.X) + Math.Abs(this.Y - other.Y);
```

Every party in the system carries a `Location`:

| Type | Property | Set when |
|------|----------|----------|
| `Customer` | `Location` (read-only) | during sign-up; fixed for the account's lifetime |
| `Deliverer` | `Location` (read/write) | during sign-up, and updated whenever they report a new position while picking a delivery job |
| `Restaurant` | `Restaurant_Location` | set once by the owning `Client` during sign-up |

It's used in three places:
1. **Sorting restaurants for a customer** — [Menus/CustomerMenus/SortingMenu.cs](Menus/CustomerMenus/SortingMenu.cs)
   sorts the restaurant list by `restaurant.Restaurant_Location.DistanceTo(customer.Location)`
   when the customer chooses "sorted by distance".
2. **Matching a deliverer to jobs** — [Menus/DelivererMenu.cs](Menus/DelivererMenu.cs)
   asks the deliverer for their current `X,Y`, builds a `Location` from it, and
   computes `restaurant.Restaurant_Location.DistanceTo(delivererLocation)` for
   every unclaimed order so it can list pickup distance (and separately shows
   `restaurant → customer` distance for the delivery leg).
3. **Directions in status messages** — once a delivery is accepted, the menu
   prints the restaurant's and customer's raw `X,Y` coordinates so the
   deliverer knows where to go (see `Deliverer.Details()` and the "please head
   to..." messages), rather than recomputing distance again.

## Screenshots

### Main menu
![Main menu](assets/mainMenu.png)

### Registering a new user
![Registration entry](assets/register.png)

### Full registration flow (client + restaurant)
![Registration process](assets/registrationProcess.png)

### Client menu (restaurant owner)
![Client menu](assets/clientMenu.png)

### Customer menu
![Customer menu](assets/customerMenu.png)

### Selecting a restaurant
![Restaurant selection](assets/restaurantSelection.png)

### Restaurant list as seen by a customer
![Restaurant selection by customer](assets/restaurantSelectionbByCustomer.png)

## Sample session

Captured from `dotnet run`. Lines beginning with `>` are what the user typed.

### 1. Register a client and their restaurant

```
Welcome to Arriba Eats!
Please make a choice from the menu below:
1: Login as a registered user
2: Register as a new user
3: Exit
Please enter a choice between 1 and 3:
> 2
Which type of user would you like to register as?
1: Customer
2: Deliverer
3: Client
4: Return to the previous menu
Please enter a choice between 1 and 4:
> 3
Please enter your name:
> Maria Gonzalez
Please enter your age (18-100):
> 35
Please enter your email address:
> maria@arriba.com
Please enter your mobile phone number:
> 0412345678
Your password must:
- be at least 8 characters long
- contain a number
- contain a lowercase letter
- contain an uppercase letter
Please enter a password:
> Burrito99
Please confirm your password:
> Burrito99
Please enter your restaurant's name:
> Casa Maria
Please select your restaurant's style:
1: Italian
2: French
3: Chinese
4: Japanese
5: American
6: Australian
Please enter a choice between 1 and 6:
> 2
Please enter your location (in the form of X,Y):
> 5,7
You have been successfully registered as a client, Maria Gonzalez!
```

### 2. Register a customer

```
Please enter a choice between 1 and 3:
> 2
Which type of user would you like to register as?
1: Customer
2: Deliverer
3: Client
4: Return to the previous menu
Please enter a choice between 1 and 4:
> 1
Please enter your name:
> Sam Carter
Please enter your age (18-100):
> 28
Please enter your email address:
> sam@example.com
Please enter your mobile phone number:
> 0498765432
Your password must:
- be at least 8 characters long
- contain a number
- contain a lowercase letter
- contain an uppercase letter
Please enter a password:
> Delivery1
Please confirm your password:
> Delivery1
Please enter your location (in the form of X,Y):
> 10,10
You have been successfully registered as a customer, Sam Carter!
```

### 3. Log in as the client, view details, add a menu item

```
Please enter a choice between 1 and 3:
> 1
Email:
> maria@arriba.com
Password:
> Burrito99
Welcome back, Maria Gonzalez!
Please make a choice from the menu below:
1: Display your user information
2: Add item to restaurant menu
3: See current orders
4: Start cooking order
5: Finish cooking order
6: Handle deliverers who have arrived
7: Log out
Please enter a choice between 1 and 7:
> 1
Your user details are as follows:
Name: Maria Gonzalez
Age: 35
Email: maria@arriba.com
Mobile: 0412345678
Restaurant name: Casa Maria
Restaurant style: French
Restaurant location: 5,7
...
Please enter a choice between 1 and 7:
> 2
This is your restaurant's current menu:
Please enter the name of the new item (blank to cancel):
> Beef Burrito
Please enter the price of the new item (without the $):
> 12.50
Successfully added Beef Burrito ($12.50) to menu.
...
Please enter a choice between 1 and 7:
> 7
You are now logged out.
```

### 4. Log in as the customer and browse restaurants

```
Please enter a choice between 1 and 3:
> 1
Email:
> sam@example.com
Password:
> Delivery1
Welcome back, Sam Carter!
Please make a choice from the menu below:
1: Display your user information
2: Select a list of restaurants to order from
3: See the status of your orders
4: Rate a restaurant you've ordered from
5: Log out
Please enter a choice between 1 and 5:
> 1
Your user details are as follows:
Name: Sam Carter
Age: 28
Email: sam@example.com
Mobile: 0498765432
Location: 10,10
You've made 0 order(s) and spent a total of $0.00 here.

Please enter a choice between 1 and 5:
> 2
How would you like the list of restaurants ordered?
1: Sorted alphabetically by name
2: Sorted by distance
3: Sorted by style
4: Sorted by average rating
5: Return to the previous menu
Please enter a choice between 1 and 5:
> 1
You can order from the following restaurants:
   Restaurant Name        Loc       Dist   Style       Rating
 1: Casa Maria           5,7       8  French          -
2: Return to the previous menu
Please enter a choice between 1 and 2:
> 2

Please enter a choice between 1 and 5:
> 5
You are now logged out.
```

### 5. Exit

```
Please enter a choice between 1 and 3:
> 3
Thank you for using Arriba Eats!
```
