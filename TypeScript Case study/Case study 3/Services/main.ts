import { EcommerceService } from "./ecommerce.service";

// Instantiate
const ecommerce = new EcommerceService();

// Display initial products
ecommerce.displayProducts();

// Operations
ecommerce.addToCart(1, 1);  // 1 x Laptop
ecommerce.addToCart(2, 2);  // 2 x Jeans
ecommerce.addToCart(3, 1);  // 1 x Rice Bag

ecommerce.removeFromCart(2); 

// Final summary
ecommerce.displayCartSummary();

// Display updated products
ecommerce.displayProducts();
