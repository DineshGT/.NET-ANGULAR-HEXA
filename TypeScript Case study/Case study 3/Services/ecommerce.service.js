"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EcommerceService = void 0;
const category_enum_1 = require("../Models/category.enum");
class EcommerceService {
    constructor() {
        this.products = [];
        this.cart = [];
        this.products = [
            { id: 1, name: "Laptop", price: 45000, stock: 3, category: category_enum_1.Category.Electronics },
            { id: 2, name: "Jeans", price: 1500, stock: 10, category: category_enum_1.Category.Clothing },
            { id: 3, name: "Rice Bag", price: 700, stock: 5, category: category_enum_1.Category.Grocery },
        ];
    }
    displayProducts() {
        console.log("\nAvailable Products:");
        for (let p of this.products) {
            console.log(`${p.name} | ₹${p.price} | In Stock: ${p.stock} | Category: ${p.category}`);
        }
    }
    addToCart(productId, quantity) {
        const product = this.products.find(p => p.id === productId);
        if (!product) {
            console.log("Product not found.");
            return;
        }
        if (product.stock < quantity) {
            console.log(`Only ${product.stock} units of ${product.name} left in stock.`);
            return;
        }
        product.stock -= quantity;
        const existingItem = this.cart.find(ci => ci.product.id === productId);
        if (existingItem) {
            existingItem.quantity += quantity;
        }
        else {
            this.cart.push({ product, quantity });
        }
        console.log(`${quantity} x ${product.name} added to cart.`);
    }
    removeFromCart(productId) {
        const index = this.cart.findIndex(ci => ci.product.id === productId);
        if (index !== -1) {
            const item = this.cart[index];
            item.product.stock += item.quantity;
            this.cart.splice(index, 1);
            console.log(`${item.product.name} removed from cart.`);
        }
        else {
            console.log("Product not found in cart.");
        }
    }
    displayCartSummary() {
        console.log("\nCart Summary:");
        let total = 0;
        for (let item of this.cart) {
            const itemTotal = item.product.price * item.quantity;
            console.log(`${item.product.name} - ₹${item.product.price} x ${item.quantity}`);
            total += itemTotal;
        }
        console.log(`Total: ₹${total}`);
        let discount = 0;
        if (total >= 10000) {
            discount = 0.15;
        }
        else if (total >= 5000) {
            discount = 0.10;
        }
        if (discount > 0) {
            const discountedTotal = total - total * discount;
            console.log(`Discounted Total: ₹${discountedTotal}`);
        }
    }
}
exports.EcommerceService = EcommerceService;
