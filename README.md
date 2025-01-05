# Supermarket Checkout

A simple command-line supermarket checkout system that calculates the total price of items in a shopping cart, taking into account special offers like "3 for 130" or "2 for 45". The system allows users to scan items by their SKU, apply relevant offers, and calculate the final total.

## Features

- **Scan Items**: Users can input product SKUs (e.g., `A99`, `B15`, etc.) to add items to their cart.
- **Special Offers**: Special offers like "3 for 130" for apples or "2 for 45" for biscuits are applied when multiple items are purchased.
- **Total Calculation**: The system calculates the final total based on the items scanned, considering both regular prices and any applicable special offers.
- **Invalid SKU Handling**: The system handles invalid SKUs by prompting the user to try again.

## Code Structure

### Classes

- **Program**: The main entry point for the checkout process.
- **SpecialOffer**: Represents a special offer with a quantity and price (e.g., "3 for 130").
- **ProductDB**: A mock database that holds product details, including prices and special offers.
- **Checkout**: The core class responsible for scanning items and calculating the total.

### Product Data

The mock database (`ProductDB`) contains the following products:

- **A99**: Apples - Price: 50, Offer: 3 for 130
- **B15**: Biscuits - Price: 30, Offer: 2 for 45
- **C40**: Product C - Price: 60, No offer
- **T34**: Product T - Price: 99, No offer


## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.


## Contact

If you have any questions or suggestions, feel free to reach out to me via GitHub or email.
