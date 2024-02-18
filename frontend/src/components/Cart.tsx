// src/components/Cart.tsx
import React from 'react';
import { CartItem } from '../types/CartItem';
import 'bootstrap/dist/css/bootstrap.min.css';

interface CartProps {
    items: CartItem[];
    onRemove: (itemId: string) => void;
}

const Cart: React.FC<CartProps> = ({ items, onRemove }) => {
    const totalAmount = items.reduce((sum, item) => sum + item.price * item.quantity, 0).toFixed(2);

    return (
        <div className="cart mt-4">
            <h2>Your Cart</h2>
            {items.length > 0 ? (
                <ul className="list-group">
                    {items.map(item => (
                        <li key={item.id} className="list-group-item d-flex justify-content-between align-items-center">
                            {item.name} (x{item.quantity})
                            <span>{(item.price * item.quantity).toFixed(2)} €</span>
                            <button onClick={() => onRemove(item.id)} className="btn btn-danger btn-sm">Remove</button>
                        </li>
                    ))}
                </ul>
            ) : (
                <p>Your cart is empty.</p>
            )}
            <div className="mt-3">
                <strong>Total: {totalAmount} €</strong>
            </div>
        </div>
    );
};

export default Cart;