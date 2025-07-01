"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ecommerce_service_1 = require("./ecommerce.service");
// Instantiate
const ecommerce = new ecommerce_service_1.EcommerceService();
// Display initial products
ecommerce.displayProducts();
// Operations
ecommerce.addToCart(1, 1); // 1 x Laptop
ecommerce.addToCart(2, 2); // 2 x Jeans
ecommerce.addToCart(3, 1); // 1 x Rice Bag
ecommerce.removeFromCart(2);
// Final summary
ecommerce.displayCartSummary();
// Display updated products
ecommerce.displayProducts();
