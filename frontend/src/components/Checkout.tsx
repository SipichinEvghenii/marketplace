// src/components/Checkout.tsx
import React, { useState } from 'react';
import { CartItem } from '../types/CartItem';
import 'bootstrap/dist/css/bootstrap.min.css';

interface CheckoutProps {
    items: CartItem[];
    onOrder: (customerInfo: { name: string, address: string }) => void;
}

const Checkout: React.FC<CheckoutProps> = ({ items, onOrder }) => {
    const [name, setName] = useState('');
    const [address, setAddress] = useState('');

    const handleOrder = (e: React.FormEvent) => {
        e.preventDefault();
        onOrder({ name, address });
    };

    return (
        <form className="checkout" onSubmit={handleOrder}>
            <div className="mb-3">
                <label className="form-label">Name</label>
                <input
                    type="text"
                    className="form-control"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Address</label>
                <input
                    type="text"
                    className="form-control"
                    value={address}
                    onChange={(e) => setAddress(e.target.value)}
                    required
                />
            </div>
            <button type="submit" className="btn btn-primary">Place Order</button>
        </form>
    );
};

export default Checkout;