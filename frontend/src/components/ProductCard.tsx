// src/components/ProductCard.tsx
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import {Product} from "../types/Product";

interface ProductCardProps {
    product: Product;
}

const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
    return (
        <div className="card">
            <img src={product.image} className="card-img-top" alt={product.name} />
            <div className="card-body">
                <h5 className="card-title">{product.name}</h5>
                <p className="card-text">${product.price}</p>
            </div>
        </div>
    );
};

export default ProductCard;